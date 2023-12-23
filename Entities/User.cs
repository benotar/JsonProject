using Sharp.Abstractions;

namespace Sharp.Entities;

public class User : Entity
{
    public string UserName { get; set; }   
    public string? RealName { get; set; }
    public override string ToString()
    {
        return $"User: {UserName} ({RealName ?? "None"} | {Id})";
    }
}
