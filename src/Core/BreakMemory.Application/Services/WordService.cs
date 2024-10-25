using BreakMemory.Domain.Models;
using BreakMemory.Domain.Models.Database;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BreakMemory.Application.Services;

public class WordService
{
    public readonly IMongoCollection<Word> wordCollection;

    public WordService(IOptions<MongoDBSettings> wordServiceDdSettings)
    {
        var mongoClient = new MongoClient(wordServiceDdSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(wordServiceDdSettings.Value.DatabaseName);
        wordServiceDdSettings = mongoDatabase.GetCollection<Word>(wordServiceDdSettings.Value.CollectionName);
    }

    public async Task<List<Word>> GetAllEntries() =>
        await wordCollection.Find(_ => true).ToListAsync();

    public async Task<Word?> GetEntryById(Guid id) =>
        await wordCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateEntry(Word newWord) =>
        await wordCollection.InsertOneAsync(newWord);
    
    public async Task UpdateEntry(Guid id, Word updatedWord) =>
        await wordCollection.ReplaceOneAsync(x => x.Id == id, updatedWord);

    public async Task RemoveEntry(Guid id) =>
        await wordCollection.DeleteOneAsync(x => x.Id == id);
}