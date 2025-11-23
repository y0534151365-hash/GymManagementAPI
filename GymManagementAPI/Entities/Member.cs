namespace GymManagementAPI.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MembershipType { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }
    }
}
