using Application.SeedWorks;
using AutoMapper;
using Data.DTO.ExportReceipts;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportReceiptsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ExportReceiptsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllExport")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var ex = await _unitOfWork.ExportReceiptsRepository.GetAllAsync();
                return Ok(ex);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExportReceiptsCreateUpdateRequest request)
        {
            try
            {
                var i = _mapper.Map<ExportReceipts>(request);
                _unitOfWork.ExportReceiptsRepository.Add(i);
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
                var ex = await _unitOfWork.ExportReceiptsRepository.GetByIdAsync(id);
                _unitOfWork.ExportReceiptsRepository.Remove(ex);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ExportReceiptsCreateUpdateRequest request)
        {
            try
            {
                var ex = await _unitOfWork.ExportReceiptsRepository.GetByIdAsync(request.ExportID);
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
