using BreakMemory.Domain.Models;
using BreakMemory.Infrastructure.Models.Requests;
using BreakMemory.Infrastructure.Models.Responses;

namespace BreakMemory.Application.Mappers;

public static class WordMapper
{
    public static Word ToDomain(WordRequest request)
    {
        return new Word
        {
            Id = Guid.NewGuid(),
            Original = request.Original,
            Translation = request.Translation
        };
    }

    public static WordResponse ToResponse(Word word)
    {
        return new WordResponse
        {
            Original = word.Original,
            Translation = word.Translation
        };
    }
}