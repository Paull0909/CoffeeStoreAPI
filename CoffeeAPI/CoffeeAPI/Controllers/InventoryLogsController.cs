using Application.SeedWorks;
using AutoMapper;
using Data.DTO.InventoryLogs;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryLogsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public InventoryLogsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllInventoryLogs")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var il = await _unitOfWork.InventoryLogsRepository.GetAllAsync();
                return Ok(il);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(InventoryLogsCreateUpdateRequest request)
        {
            try
            {
                var i = _mapper.Map<InventoryLogs>(request);
                _unitOfWork.InventoryLogsRepository.Add(i);
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
                var il = await _unitOfWork.InventoryLogsRepository.GetByIdAsync(id);
                _unitOfWork.InventoryLogsRepository.Remove(il);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(InventoryLogsCreateUpdateRequest request)
        {
            try
            {
                var ex = await _unitOfWork.InventoryLogsRepository.GetByIdAsync(request.InventoryLogID);
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
