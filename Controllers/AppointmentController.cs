using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Models;
using WebApi1.AppointmentData;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IAppointmentData _appointmentData;

        public AppointmentController(IAppointmentData appointmentData)
        {
            _appointmentData = appointmentData;

        }
        [HttpGet]
        [Route("api/[controller]")]

        public IActionResult GetAppointments()
        {
            return Ok(_appointmentData.GetAppointments());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]

        public IActionResult GetAppointment(Guid Id)
        {
            var appointment = _appointmentData.GetAppointment(Id);

            if (appointment != null)
            {
                return Ok(appointment);
            }

            return NotFound($"No appointment with Id : {Id}");

        }

        [HttpPost]
        [Route("api/[controller]")]

        public IActionResult GetAppointment(Appointment appointment)
        {
             _appointmentData.AddAppointment(appointment);
            return Created(HttpContext.Request.Scheme + "//" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + appointment.Id, appointment);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]

        public IActionResult DeleteAppointment(Guid id)
        {
            var appointment = _appointmentData.GetAppointment(id);

            if (appointment != null)
            {
                _appointmentData.DeleteAppointment(appointment);
                return Ok();
            }

            return NotFound($"Appointment with Id : {id} cannot be found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]

        public IActionResult EditAppointment(Guid id, Appointment appointment)
        {
            var existingAppintment = _appointmentData.GetAppointment(id);

            if (existingAppintment != null)
            {
                appointment.Id = existingAppintment.Id;
                _appointmentData.EditAppointment(appointment);
            }
            return Ok(appointment);
        }
    }
}

