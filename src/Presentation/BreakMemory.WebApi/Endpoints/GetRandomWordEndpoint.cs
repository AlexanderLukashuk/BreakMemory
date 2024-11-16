using BreakMemory.Application.Services;
using BreakMemory.Infrastructure.Models.Responses;
using FastEndpoints;

namespace BreakMemory.WebApi.Endpoints;

public class GetRandomWordEndpoint : EndpointWithoutRequest<WordResponse>
{
    private readonly WordService wordService;

    public GetRandomWordEndpoint(WordService wordService)
    {
        this.wordService = wordService;
    }

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("/words/random");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Trying to get a random word...");
        var word = await wordService.GetRandomWord();
        Console.WriteLine($"Word retrieved: {word?.Original}");
        if (word == null)
        {
            await SendNotFoundAsync();
            return;
        }

        var response = new WordResponse { Original = word.Original };
        await SendOkAsync(response);
    }
}