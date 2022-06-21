using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public virtual Organization Organization { get; set; }
    }
}