using GestorDeTurnos.Domain.Common;

namespace GestorDeTurnos.Domain.Entities
{
    public class Establishment : EntityBase
    {
        public string UserId { get; set; }
        public string BusinessName { get; set; }
        public string Location { get; set; }
        public string WorkingHours { get; set; }
        public string Description { get; set; }
        public string ProfileImage { get; set; }

        public ICollection<Service> Services { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}