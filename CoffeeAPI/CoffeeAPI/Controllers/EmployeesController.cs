using Application.SeedWorks;
using AutoMapper;
using Data.DTO.Categories_Material;
using Data.DTO.Employees;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public EmployeesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cate = await _unitOfWork.EmployeesRepository.GetAllAsync();
                return Ok(cate);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeesCreateUpdateRequest request)
        {
            try
            {
                var i = _mapper.Map<Employees>(request);
                _unitOfWork.EmployeesRepository.Add(i);
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
                var ep = await _unitOfWork.EmployeesRepository.GetByIdAsync(id);
                _unitOfWork.EmployeesRepository.Remove(ep);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(EmployeesCreateUpdateRequest request)
        {
            try
            {
                var cate = await _unitOfWork.EmployeesRepository.GetByIdAsync(request.EmployeeID);
                if (cate != null)
                {
                    var i = _mapper.Map(request, cate);
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
