using BusinessLayer.Abstract;
using EntityLayer.Concrete.DTOs.BookingDTOs;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CrasProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("AllActive")]
        public IActionResult GetAllActive()
        {
            var result = _bookingService.GetAllActive();
            return Ok(result);
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var result = _bookingService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromForm] BookingCreateDto booking)
        {
            if (booking == null)
            {
                return BadRequest("Booking data is null");
            }

            var result = _bookingService.Add(booking);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromForm] BookingUpdateDto booking)
        {
            if (booking == null)
            {
                return BadRequest("Booking data is null");
            }

            var result = _bookingService.Update(booking);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult HardDelete(int id)
        {
            var result = _bookingService.HardDelete(id);
            return Ok(result);
        }

        [HttpPut("SoftDelete")]
        public IActionResult Delete(int id)
        {
            var result = _bookingService.Delete(id);
            return Ok(result);
        }

        [HttpGet("AllWaitingList")]
        public IActionResult GetAllWaitingList()
        {
            var result = _bookingService.GetConfirmationList();
            return Ok(result);
        }
        [HttpPut("ConfirmAll")]
        public IActionResult ConfirmAll()
        {
            var result = _bookingService.ConfirmationAll();
            return Ok(result);
        }
        [HttpPut("ConfirmById")]
        public IActionResult ConfirmById(int id)
        {
            var result = _bookingService.ConfirmationbyId(id);
            return Ok(result);
        }
    }
}
