using Application.SeedWorks;
using AutoMapper;
using Data.DTO.ExportDetails;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportDetailsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ExportDetailsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllExportDetail")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var ex = await _unitOfWork.ExportDetailsRepository.GetAllAsync();
                return Ok(ex);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetExportDetailByReceipID")]
        public async Task<IActionResult> GetByExportReceipt(int id)
        {
            try
            {
                var ex = await _unitOfWork.ExportDetailsRepository.GetByExportReceipt(id);
                return Ok(ex);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExportDetailsCreateUpdateRequest request)
        {
            try
            {
                var i = _mapper.Map<ExportDetails>(request);
                _unitOfWork.ExportDetailsRepository.Add(i);
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
                var ex = await _unitOfWork.ExportDetailsRepository.GetByIdAsync(id);
                _unitOfWork.ExportDetailsRepository.Remove(ex);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ExportDetailsCreateUpdateRequest request)
        {
            try
            {
                var ex = await _unitOfWork.ExportDetailsRepository.GetByIdAsync(request.ExportDetailID);
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
