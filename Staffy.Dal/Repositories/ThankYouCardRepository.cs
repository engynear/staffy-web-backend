using Dapper;
using Microsoft.Extensions.Options;
using Staffy.Dal.Entitites;
using Staffy.Dal.Repositories.Interfaces;
using Staffy.Dal.Settings;

namespace Staffy.Dal.Repositories;

public class ThankYouCardRepository : PgRepository, IThankYouCardRepository
{
    public ThankYouCardRepository(
        IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }

    public async Task<IEnumerable<ThankYouCardEntity>> GetAllThankYouCardsAsync()
    {
        const string sqlQuery = @"
SELECT t.id as Id
     , t.SenderId as SenderId
     , t.ReceiverId as ReceiverId
     , t.message as Message
FROM thank_you_cards t
";
        await using var connection = await GetConnection();
        var thankYouCards = await connection.QueryAsync<ThankYouCardEntity>(sqlQuery);
        return thankYouCards;
    }

    public async Task<ThankYouCardEntity?> GetThankYouCardByIdAsync(long id)
    {
        const string sqlQuery = @"
SELECT t.id as Id
     , t.SenderId as SenderId
     , t.ReceiverId as ReceiverId
     , t.message as Message
FROM thank_you_cards t
WHERE t.id = @Id
";
        await using var connection = await GetConnection();
        var thankYouCard = await connection.QueryFirstOrDefaultAsync<ThankYouCardEntity>(
            new CommandDefinition(
                sqlQuery,
                new
                {
                    Id = id
                }));
        return thankYouCard;
    }

    public async Task<long> AddThankYouCardAsync(ThankYouCardEntity thankYouCard)
    {
        const string sqlQuery = @"
INSERT INTO thank_you_cards (SenderId, ReceiverId, Message)
VALUES (@SenderId, @ReceiverId, @Message)
RETURNING id
";
        await using var connection = await GetConnection();
        var id = await connection.ExecuteScalarAsync<long>(
            new CommandDefinition(
                sqlQuery,
                new
                {
                    SenderId = thankYouCard.SenderId,
                    ReceiverId = thankYouCard.ReceiverId,
                    Message = thankYouCard.Message
                }));
        return id;
    }

    public async Task DeleteThankYouCardAsync(long id)
    {
        const string sqlQuery = @"
DELETE FROM thank_you_cards
WHERE id = @Id
";
        await using var connection = await GetConnection();
        await connection.ExecuteAsync(
            new CommandDefinition(
                sqlQuery,
                new
                {
                    Id = id
                }));
    }
}