namespace BreakMemory.Domain.Models;

public class Phrase : BaseEntity
{
    public string Original { get; set; }
    public string Translation { get; set; }
}