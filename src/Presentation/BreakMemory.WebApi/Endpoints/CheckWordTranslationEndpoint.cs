using BreakMemory.Application.Services;
using BreakMemory.WebApi.Models.Request;
using BreakMemory.WebApi.Models.Response;
using FastEndpoints;

namespace BreakMemory.WebApi.Endpoints;

public class CheckWordTranslationEndpoint : Endpoint<CheckTranslationRequest, CheckTranslationResponse>
{
    private readonly WordService wordService;

    public CheckWordTranslationEndpoint(WordService wordService)
    {
        this.wordService = wordService;
    }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("/words/check");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CheckTranslationRequest request, CancellationToken cancellationToken)
    {
        var word = await wordService.GetEntryById(request.WordId);

        if (word == null)
        {
            await SendNotFoundAsync();
            return;
        }

        var isCorrect = string.Equals(word.Translation, request.UserTranslation, StringComparison.OrdinalIgnoreCase);

        var response = new CheckTranslationResponse { IsCorrect = isCorrect };
        await SendOkAsync(response);
    }
}