using System.Text.Json.Serialization;

namespace SignalR_Interface_Argument_Deserialization_Issue;

public record W(III Data);

[JsonPolymorphic()]
[JsonDerivedType(typeof(C1), nameof(C1))]
[JsonDerivedType(typeof(C2), nameof(C2))]
public interface III
{
}

public class C1 : III
{
    public int A { get; set; }
}

public class C2 : III
{
    public int B { get; set; }
}
