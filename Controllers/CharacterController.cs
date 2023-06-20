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
       public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
       {
            return Ok( await _charaterService.GetAllCharacters());
       }

       [HttpGet("{id}")]
       public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
       {
          var response = await _charaterService.GetCharacterById(id);
          if(response.Data is null)
          {
              return NotFound(response);
          }
          return Ok(response);
       }

       [HttpPost]
       public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharatcterDto character)
       {
          return Ok(await _charaterService.AddCharatcter(character));
       }

       [HttpPut]
       public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto character)
       {
          var response = await _charaterService.UpdateCharatcter(character);
          if(response.Data is null)
          {
               return NotFound(response);
          }
          return Ok(response);
       }
       [HttpDelete("{id}")]
       public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> DeleteCharacter(int id)
       {
            var response = await _charaterService.DeleteCharacters(id);
            if(response.Data is null)
            {
               return NotFound(response);
            }
            return Ok(response);
       }
    }
}