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
       private static List<Character> characters = new  List<Character>{
            new Character(),
            new Character{Id =1, Name ="Ivan"}
       };

       [HttpGet("GetAll")]
       public ActionResult<List<Character>> Get()
       {
            return Ok(characters);
       }

       [HttpGet("{id}")]
       public ActionResult<Character> GetSingle(int id)
       {
            return Ok(characters.FirstOrDefault(x => x.Id == id));
       }

       [HttpPost]
       public ActionResult<List<Character>> AddCharacter(Character character)
       {
        characters.Add(character);
        return Ok(characters);
       }
    }
}