using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Models
{
    public class Membership
    {
        public int MembershipID { get; set; }
        public int? TeamID { get; set; }
        public int? MemberID { get; set; }
        public virtual Team Team { get; set; }
        public virtual Member member{ get; set; }
        public DateTime DateFrom { get; set; }
    }
}