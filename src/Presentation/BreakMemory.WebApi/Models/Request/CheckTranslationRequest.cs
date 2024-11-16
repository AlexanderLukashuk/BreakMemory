namespace BreakMemory.WebApi.Models.Request;

public class CheckTranslationRequest
{
    public Guid WordId { get; set; }
    public string UserTranslation { get; set; }
}