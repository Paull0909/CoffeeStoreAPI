using Application.SeedWorks;
using AutoMapper;
using Data.DTO.Materials;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public MaterialsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cate = await _unitOfWork.MaterialsRepository.GetAllAsync();
                return Ok(cate);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetByCategory")]
        public async Task<IActionResult> GetByCategory(int id)
        {
            try
            {
                var cate = await _unitOfWork.MaterialsRepository.GetByCategory(id);
                return Ok(cate);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(MaterialsCreateUpdateRequest request)
        {
            try
            {
                var mate = _unitOfWork.MaterialsRepository.Find(t=>t.MaterialName == request.MaterialName);
                if (mate.Count()==0)
                {
                    var i = _mapper.Map<Materials>(request);
                    _unitOfWork.MaterialsRepository.Add(i);
                    await _unitOfWork.CompleteAsync();
                    return Ok();
                }
                else
                    return BadRequest($"Tên loại '{request.MaterialName}' đã tồn tại.");
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
                var mate = await _unitOfWork.MaterialsRepository.GetByIdAsync(id);
                _unitOfWork.MaterialsRepository.Remove(mate);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(MaterialsCreateUpdateRequest request)
        {
            try
            {
                var mate = await _unitOfWork.MaterialsRepository.GetByIdAsync(request.MaterialID);
                if (mate != null)
                {
                    var i = _mapper.Map(request,mate);
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
