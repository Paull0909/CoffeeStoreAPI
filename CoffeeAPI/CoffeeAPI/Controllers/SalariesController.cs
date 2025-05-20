using Application.SeedWorks;
using AutoMapper;
using Data.DTO.Positions;
using Data.DTO.Salaries;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalariesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SalariesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllSalaries")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var sl = await _unitOfWork.SalariesRepository.GetAllAsync();
                return Ok(sl);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(SalariesCreateUpdateRequest request)
        {
            try
            {
                var i = _mapper.Map<Salaries>(request);
                _unitOfWork.SalariesRepository.Add(i);
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
                var sl = await _unitOfWork.SalariesRepository.GetByIdAsync(id);
                _unitOfWork.SalariesRepository.Remove(sl);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(SalariesCreateUpdateRequest request)
        {
            try
            {
                var sl = await _unitOfWork.SalariesRepository.GetByIdAsync(request.SalaryID);
                if (sl != null)
                {
                    var i = _mapper.Map(request,sl);
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
