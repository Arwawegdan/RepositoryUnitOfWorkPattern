namespace Session.Shared;
public record BaseEntity
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
}