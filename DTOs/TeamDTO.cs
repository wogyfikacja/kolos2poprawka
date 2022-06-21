using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.DTOs
{
    public class TeamDTO
    {
        public string TeamName { get; set; }
        public string OrganizationName { get; set; }
        public string TeamDescription { get; set; }
        public ICollection<MemberDTO> TeamMembers { get; set; }   
    }
}