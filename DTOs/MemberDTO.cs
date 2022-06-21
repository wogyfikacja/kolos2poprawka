using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.DTOs
{
    public class MemberDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public DateTime MembershipDate { get; set; }

    }
}