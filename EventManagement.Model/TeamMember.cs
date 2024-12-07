namespace EventManagement.Model;

public class TeamMember
{
    public int Id { get; set; }
    public int TeamId { get; set; }
    public string MemberName { get; set; } = string.Empty;

    public virtual Team Team { get; set; } = null!;



}