using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int DoctorId { get; set; }

        // ---- navigation properties
        public Doctor? Doctor { get; set; }
        public User? User { get; set; }
    }
}
