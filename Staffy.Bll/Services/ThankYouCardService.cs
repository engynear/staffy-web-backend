using Staffy.Bll.Models;
using Staffy.Bll.Services.Interfaces;
using Staffy.Dal.Repositories.Interfaces;

namespace Staffy.Bll.Services;

public class ThankYouCardService : IThankYouCardService
{
    private readonly IThankYouCardRepository _repository;
    
    public ThankYouCardService(IThankYouCardRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<ThankYouCard>> GetAllThankYouCardsAsync()
    {
        var thankYouCards = await _repository.GetAllThankYouCardsAsync();
        return thankYouCards.Select(t => new ThankYouCard { 
            Id = t.Id,
            SenderId = t.SenderId,
            ReceiverId = t.ReceiverId,
            Message = t.Message,
            SendDate = t.SendDate
        });
    }

    public async Task<ThankYouCard?> GetThankYouCardByIdAsync(long id)
    {
        var thankYouCard = await _repository.GetThankYouCardByIdAsync(id);
        if (thankYouCard == null)
            return null;

        return await Task.FromResult(new ThankYouCard { 
            Id = thankYouCard.Id,
            SenderId = thankYouCard.SenderId,
            ReceiverId = thankYouCard.ReceiverId,
            Message = thankYouCard.Message,
            SendDate = thankYouCard.SendDate
        });
    }

    public async Task<long> AddThankYouCardAsync(ThankYouCard thankYouCard)
    {
        var id = await _repository.AddThankYouCardAsync(new Dal.Entitites.ThankYouCardEntity
        {
            SenderId = thankYouCard.SenderId,
            ReceiverId = thankYouCard.ReceiverId,
            Message = thankYouCard.Message,
            SendDate = thankYouCard.SendDate
        });
        return id;
    }

    public async Task DeleteThankYouCardAsync(long id)
    {
        await _repository.DeleteThankYouCardAsync(id);
    }
}