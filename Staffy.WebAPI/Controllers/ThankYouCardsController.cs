using Microsoft.AspNetCore.Mvc;
using Staffy.Bll.Models;
using Staffy.Bll.Services.Interfaces;
using StaffyWebAPI.DTOs;

namespace StaffyWebAPI.Controllers;

[ApiController]
[Route("thank-you-cards")]
public class ThankYouCardsController : ControllerBase
{
    private readonly IThankYouCardService _thankYouCardService;

    public ThankYouCardsController(IThankYouCardService thankYouCardService)
    {
        _thankYouCardService = thankYouCardService;
    }

    [HttpGet]
    public async Task<IActionResult> GetThankYouCards()
    {
        var thankYouCards = await _thankYouCardService.GetAllThankYouCardsAsync();
        return Ok(thankYouCards);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetThankYouCard(long id)
    {
        var thankYouCard = await _thankYouCardService.GetThankYouCardByIdAsync(id);
        if (thankYouCard == null)
            return NotFound();
            
        return Ok(thankYouCard);
    }

    [HttpPost]
    public async Task<IActionResult> CreateThankYouCard(ThankYouCardDto thankYouCardDto)
    {
        var thankYouCard = new ThankYouCard { 
            SenderId = thankYouCardDto.SenderId,
            ReceiverId = thankYouCardDto.ReceiverId,
            Message = thankYouCardDto.Message,
            SendDate = DateTimeOffset.UtcNow
        };
        var id = await _thankYouCardService.AddThankYouCardAsync(thankYouCard);
        
        return Ok(id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteThankYouCard(long id)
    {
        await _thankYouCardService.DeleteThankYouCardAsync(id);
        return NoContent();
    }
}