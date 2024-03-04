using Staffy.Dal.Entitites;

namespace Staffy.Dal.Repositories.Interfaces;

public interface IThankYouCardRepository
{
    Task<IEnumerable<ThankYouCardEntity>> GetAllThankYouCardsAsync();
    Task<ThankYouCardEntity?> GetThankYouCardByIdAsync(long id);
    Task<long> AddThankYouCardAsync(ThankYouCardEntity thankYouCard);
    Task DeleteThankYouCardAsync(long id);
}