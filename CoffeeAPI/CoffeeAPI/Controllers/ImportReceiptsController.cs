using Application.SeedWorks;
using AutoMapper;
using Data.DTO.ImportReceipts;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportReceiptsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ImportReceiptsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllImport")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var ip = await _unitOfWork.ImportReceiptsRepository.GetAllAsync();
                return Ok(ip);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ImportReceiptsCreateUpdateRequest request)
        {
            try
            {
                var i = _mapper.Map<ImportReceipts>(request);
                _unitOfWork.ImportReceiptsRepository.Add(i);
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
                var ip = await _unitOfWork.ImportReceiptsRepository.GetByIdAsync(id);
                _unitOfWork.ImportReceiptsRepository.Remove(ip);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ImportReceiptsCreateUpdateRequest request)
        {
            try
            {
                var ex = await _unitOfWork.ImportReceiptsRepository.GetByIdAsync(request.ImportID);
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
