namespace Session.Shared;
public record Employee : BaseEntity
{
    public string? Mobile { get; set; }
    public int Age { get; set; }
    public string? Telephone { get; set; }
    public DateTime BirthDate { get; set; }
}
