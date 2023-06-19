using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new  List<Character>{
            new Character(),
            new Character{Id =1, Name ="Ivan"}
            };
        public async Task<ServiceResponse<List<Character>>> AddCharatcter(Character newChratacter)
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            characters.Add(newChratacter);
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<Character>();

            var chrackter = characters.FirstOrDefault(x => x.Id == id);
            if(chrackter is null)
            {
                //throw new Exception("Chracter not found");
                serviceResponse.Success = false;
                serviceResponse.Message = "Chracter not found";
                return serviceResponse;
            }
            else
            {
                serviceResponse.Data = chrackter;
                return serviceResponse;
            }
        }
    }
}