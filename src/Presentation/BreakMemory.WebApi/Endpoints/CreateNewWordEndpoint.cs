using BreakMemory.Application.Mappers;
using BreakMemory.Application.Services;
using BreakMemory.Infrastructure.Models.Requests;
using BreakMemory.Infrastructure.Models.Responses;
using FastEndpoints;

namespace BreakMemory.WebApi.Endpoints;

public class CreateNewWordEndpoint : Endpoint<WordRequest, WordResponse>
{
    private readonly WordService wordService;

    public CreateNewWordEndpoint(WordService wordService)
    {
        this.wordService = wordService;
    }

    public override void Configure()
    {
        Post("/api/word/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(WordRequest request, CancellationToken cancellationToken)
    {
        // await wordService.CreateEntry(request)
        // if (string.IsNullOrWhiteSpace(request.Original) || string.IsNullOrWhiteSpace(request.Translation))
        // {
            
        // }

        var newWord = WordMapper.ToDomain(request);

        await wordService.CreateEntry(newWord);

        var response = WordMapper.ToResponse(newWord);

        await SendOkAsync(response, cancellationToken);
    }
}