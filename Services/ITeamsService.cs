using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium2.Models;

namespace kolokwium2.Services
{
    public interface ITeamsService
    {
        public Task<Team> GetTeam(int id);
        public Task<Member> GetMember(int id);
        public Task<String> GetOrganizationName(Team team);
        public Task<String> GetOrganizationName(Member member);
        public ICollection<Member> GetMembers(Team team);
        public void AddMember(Member member, Team team);
        public Task<Membership> GetMembership(Member member, Team team);
        public Task SaveChangesAsync();
    }
}