using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController: ControllerBase
    {
     private readonly ICharacterService _charaterService;
     public CharacterController(ICharacterService charaterService)
     {
          _charaterService = charaterService;
     }
     
     [HttpGet("GetAll")]
       public async Task<ActionResult<ServiceResponse<List<Character>>>> Get()
       {
            return Ok( await _charaterService.GetAllCharacters());
       }

       [HttpGet("{id}")]
       public async Task<ActionResult<ServiceResponse<Character>>> GetSingle(int id)
       {
            return Ok(await _charaterService.GetCharacterById(id));
       }

       [HttpPost]
       public async Task<ActionResult<ServiceResponse<List<Character>>>> AddCharacter(Character character)
       {
          return Ok(await _charaterService.AddCharatcter(character));
       }
    }
}