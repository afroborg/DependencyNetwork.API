using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DpcNtwk.API.Data.Repos;
using DpcNtwk.API.Models;
using DpcNtwk.API.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DpcNtwk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IMainRepository _repo;
        private readonly IMapper _mapper;
        public CardsController(IMainRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            var cards = await _repo.GetAll<Card>();
            return Ok(cards);
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetCardAsync(int id)
        {
            return Ok((await _repo.GetAll<Card>()).Where(x => x.ColumnId == id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard(CardForCreateDto cardData)
        {
            var card = _mapper.Map<Card>(cardData);
            _repo.Add(card);
            if (await _repo.SaveAll())
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}