using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Models;

namespace WebApi1.AppointmentData
{
    public class MockAppointmentData : IAppointmentData
    {
        private List<Appointment> appointments = new List<Appointment>()
        {
            new Appointment()
            {
                Id = Guid.NewGuid(),
                PetName = "Pet One"
            },

            new Appointment()
            {
                Id = Guid.NewGuid(),
                PetName = "Pet two"
            }
        };

        public Appointment AddAppointment(Appointment appointment)
        {
            appointment.Id = new Guid();
            appointments.Add(appointment);
            return appointment;
        }

        public void DeleteAppointment(Appointment appointment)
        {
            appointments.Remove(appointment);
        }

        public Appointment EditAppointment(Appointment appointment)
        {
            var existingAppointment = GetAppointment(appointment.Id);
            existingAppointment.PetName = appointment.PetName;
            return existingAppointment;
        }

        public Appointment GetAppointment(Guid id)
        {
            return appointments.SingleOrDefault(x => x.Id == id);
        }


        public List<Appointment> GetAppointments()
        {
            return appointments;
        }
    }
}
