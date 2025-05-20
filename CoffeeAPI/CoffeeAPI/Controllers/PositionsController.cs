using Application.SeedWorks;
using AutoMapper;
using Data.DTO.Employees;
using Data.DTO.Positions;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PositionsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllPositions")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cate = await _unitOfWork.PositionsRepository.GetAllAsync();
                return Ok(cate);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(PositionsCreateUpdateRequest request)
        {
            try
            {
                var ps = _unitOfWork.PositionsRepository.Find(t => t.PositionName == request.PositionName);
                if (ps.Count() == 0)
                {
                    var i = _mapper.Map<Positions>(request);
                    _unitOfWork.PositionsRepository.Add(i);
                    await _unitOfWork.CompleteAsync();
                    return Ok();
                }
                else return BadRequest("Chuc vu da ton tai trong he thong");
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
                var ep = await _unitOfWork.PositionsRepository.GetByIdAsync(id);
                _unitOfWork.PositionsRepository.Remove(ep);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(PositionsCreateUpdateRequest request)
        {
            try
            {
                var cate = await _unitOfWork.PositionsRepository.GetByIdAsync(request.PositionID);
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
