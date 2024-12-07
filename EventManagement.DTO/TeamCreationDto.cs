namespace EventManagement.DTO
{
    public class TeamCreationDto
    {
        public int EventId { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public List<string> MemberNames { get; set; } = new List<string>();
    }
}