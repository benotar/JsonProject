using Sharp.Abstractions;

namespace Sharp.Entities;

public class Feedback : Entity
{
    public Guid UserId { get; set; }
    public string Text { get; set; }
    public uint Rating { get; set; }
    public override string ToString()
    {
        return $"\'{Text}\' ({Rating}) | User id: {UserId}";
    }
}
