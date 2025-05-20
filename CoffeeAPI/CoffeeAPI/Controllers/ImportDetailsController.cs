using Application.SeedWorks;
using AutoMapper;
using Data.DTO.ImportDetails;
using Data.DTO.ImportReceipts;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportDetailsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ImportDetailsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllImport")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var ip = await _unitOfWork.ImportDetailsRepository.GetAllAsync();
                return Ok(ip);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetImportDetailByReceipID")]
        public async Task<IActionResult> GetByExportReceipt(int id)
        {
            try
            {
                var ip = await _unitOfWork.ImportDetailsRepository.GetByImportReceipt(id);
                return Ok(ip);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ImportDetailsCreateUpdateRequest request)
        {
            try
            {
                var i = _mapper.Map<ImportDetails>(request);
                _unitOfWork.ImportDetailsRepository.Add(i);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var ip = await _unitOfWork.ImportDetailsRepository.GetByIdAsync(id);
                _unitOfWork.ImportDetailsRepository.Remove(ip);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ImportDetailsCreateUpdateRequest request)
        {
            try
            {
                var ex = await _unitOfWork.ImportDetailsRepository.GetByIdAsync(request.ImportDetailID);
                if (ex != null)
                {
                    var i = _mapper.Map(request,ex);
                    await _unitOfWork.CompleteAsync();
                    return Ok();
                }
                else
                    return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
