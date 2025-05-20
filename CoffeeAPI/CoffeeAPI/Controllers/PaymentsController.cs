using Application.SeedWorks;
using AutoMapper;
using Data.DTO.Payments;
using Data.DTO.Tables;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllPayments")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var eps = await _unitOfWork.PaymentsRepository.GetAllAsync();
                return Ok(eps);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(PaymentsCreateUpdateRequest request)
        {
            try
            {
                var i = _mapper.Map<Payments>(request);
                _unitOfWork.PaymentsRepository.Add(i);
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
                var tb = await _unitOfWork.PaymentsRepository.GetByIdAsync(id);
                _unitOfWork.PaymentsRepository.Remove(tb);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(PaymentsCreateUpdateRequest request)
        {
            try
            {
                var cate = await _unitOfWork.PaymentsRepository.GetByIdAsync(request.PaymentID);
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
