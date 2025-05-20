using Application.SeedWorks;
using AutoMapper;
using Data.DTO.OrderDetails;
using Data.DTO.Orders;
using Data.DTO.Tables;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OrdersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllOrder")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var eps = await _unitOfWork.OrdersRepository.GetAllAsync();
                return Ok(eps);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrdersCreateUpdateRequest request)
        {
            try
            {
                if (request == null || request.orderDetails == null) return BadRequest();
                var i = _mapper.Map<Orders>(request);
                _unitOfWork.OrdersRepository.Add(i);
                foreach(var j in request.orderDetails)
                {
                    var ord = _mapper.Map<OrderDetails>(j);
                    ord.OrderID = i.OrderID;
                    _unitOfWork.OrderDetailsRepository.Add(ord);
                }
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
                var or = await _unitOfWork.OrdersRepository.GetByIdAsync(id);
                var list = await _unitOfWork.OrderDetailsRepository.GetByOrderID(id);
                foreach (var item in list)
                {
                    _unitOfWork.OrderDetailsRepository.Remove(item);
                }
                _unitOfWork.OrdersRepository.Remove(or);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(OrdersCreateUpdateRequest request)
        {
            try
            {
                var cate = await _unitOfWork.OrdersRepository.GetByIdAsync(request.OrderID);
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
