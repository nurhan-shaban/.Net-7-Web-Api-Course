using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _Net_7_Web_Api_Course
{
    public class AutoMapperProfile :  Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character,GetCharacterDto>();
            CreateMap<AddCharatcterDto,Character>();
        }
    }
}