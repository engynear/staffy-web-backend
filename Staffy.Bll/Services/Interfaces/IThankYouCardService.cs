using Staffy.Bll.Models;

namespace Staffy.Bll.Services.Interfaces;

public interface IThankYouCardService
{
    Task<IEnumerable<ThankYouCard>> GetAllThankYouCardsAsync();
    Task<ThankYouCard?> GetThankYouCardByIdAsync(long id);
    Task<long> AddThankYouCardAsync(ThankYouCard thankYouCard);
    Task DeleteThankYouCardAsync(long id);
}