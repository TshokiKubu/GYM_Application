using AutoMapper;
using GYMAPI.Models;
using GYMAPI.Models.Dtos;
using GYMAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYMAPI.Controllers
{
    [Route("api/v{version:apiVersion}/payments")]
   // [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepo;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentRepository paymentRepo, IMapper mapper)
        {
            _paymentRepo = paymentRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Get list of payments.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Payment>))]
        public IActionResult GetPayments()
        {
            var objList = _paymentRepo.GetPayments();
            var objDto = new List<Payment>();
            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<Payment>(obj));
            }
            return Ok(objDto);
        }


        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Payment))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreatePayment([FromBody] Payment payment)
        {
            if (payment == null)
            {
                return BadRequest(ModelState);
            }           
            var paymentObj = _mapper.Map<Payment>(payment);
            if (!_paymentRepo.CreatePayment(paymentObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {paymentObj.PaymentId}");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }

    }
}
