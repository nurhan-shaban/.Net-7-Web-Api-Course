using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharatcter(AddCharatcterDto newChratacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharatcter(UpdateCharacterDto UpdateChratacter);
    }
}