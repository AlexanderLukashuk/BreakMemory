namespace BreakMemory.Domain.Models;

public class Word : BaseEntity
{
    public string Original { get; set; }
    public string Translation { get; set; }
}