using Microsoft.AspNetCore.Identity;

namespace Data.Entities
{
    public class User : IdentityUser
    {
        //public int Id { get; set; }
      //  public string Name { get; set; }
       // public string LastName { get; set; }
     //   public string FirstName { get; set; }
        public DateTime? Birthdate { get; set; }
        // public string Email { get; set; }
        // public string Password { get; set; }
        //public string PhoneNumber { get; set; }
        // public string City { get; set; }
        //public int DoctorId { get; set; }

        //public Doctor? Doctors { get; set; }
        public ICollection<Order>? Orders { get; set; }
     

    }
}
