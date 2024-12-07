namespace EventManagement.Model
{
    public class Team
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string TeamName { get; set; } = string.Empty;
        
        public virtual Event Event { get; set; } = null!;
        public virtual ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
    }
}