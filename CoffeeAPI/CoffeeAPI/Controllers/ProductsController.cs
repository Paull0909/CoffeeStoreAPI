using Application.SeedWorks;
using AutoMapper;
using Data.DTO.Materials;
using Data.DTO.Products;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var pr = await _unitOfWork.ProductsRepository.GetAllAsync();
                return Ok(pr);
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
                var cate = await _unitOfWork.ProductsRepository.GetByCategory(id);
                return Ok(cate);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductsCreateUpdateRequest request)
        {
            try
            {
                var pr = _unitOfWork.ProductsRepository.Find(t=>t.ProductName == request.ProductName);
                if (pr.Count() == 0)
                {
                    var i = _mapper.Map<Products>(request);
                    _unitOfWork.ProductsRepository.Add(i);
                    await _unitOfWork.CompleteAsync();
                    return Ok();
                }
                else
                    return BadRequest($"Tên mon '{request.ProductName}' đã tồn tại.");
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
                var pr = await _unitOfWork.ProductsRepository.GetByIdAsync(id);
                _unitOfWork.ProductsRepository.Remove(pr);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductsCreateUpdateRequest request)
        {
            try
            {
                var mate = await _unitOfWork.ProductsRepository.GetByIdAsync(request.ProductID);
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
