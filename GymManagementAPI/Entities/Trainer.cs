namespace GymManagementAPI.Entities
{
    public class Trainer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Specialization { get; set; }
        public int YearsOfExperience { get; set; }
        public bool IsAvailable { get; set; }
    }
}
