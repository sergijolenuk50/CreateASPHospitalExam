namespace Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // ---- navigation properties
        public ICollection<Doctor>? Doctors { get; set; } // One to Many
    }
}
