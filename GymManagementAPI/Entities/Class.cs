namespace GymManagementAPI.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public int TrainerId { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public int Duration { get; set; }
        public int MaxParticipants { get; set; }
        public int CurrentParticipants { get; set; }
    }
}
