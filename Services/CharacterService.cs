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
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharatcter(AddCharatcterDto newChratacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(newChratacter);
            character.Id = characters.Max(x => x.Id) + 1;
            characters.Add(character);
            serviceResponse.Data = characters.Select(x => _mapper.Map<GetCharacterDto>(x)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = characters.Select(x => _mapper.Map<GetCharacterDto>(x)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();

            var chrackter = characters.FirstOrDefault(x => x.Id == id);
            if(chrackter is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Chracter not found";
                return serviceResponse;
            }
            else
            {
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(chrackter);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharatcter(UpdateCharacterDto updateCharacterDto)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                

            var character = characters.FirstOrDefault(x => x.Id == updateCharacterDto.Id);
            if(character is null)
            {
                throw new Exception($"Character Id:{updateCharacterDto.Id} is not found");
            }


            character.Name = updateCharacterDto.Name;
            character.HitPoints = updateCharacterDto.HitPoints;
            character.Strenght = updateCharacterDto.Strenght;
            character.Defense = updateCharacterDto.Defense;
            character.Intelligence = updateCharacterDto.Intelligence;
            character.Class = updateCharacterDto.Class;

            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            

            return serviceResponse;
        }
    }
}