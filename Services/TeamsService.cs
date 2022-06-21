using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2.Services
{
    public class TeamsService : ITeamsService
    {
        public readonly TeamsContext _context;
        public void AddMember(Member member, Team team)
        {
            _context.Memberships.Add(new Membership { MemberID = member.MemberID, TeamID = team.TeamID, DateFrom = DateTime.Now });
        }

        public ICollection<Member> GetMembers(Team team)
        {
            return _context.Memberships.Where(x => x.TeamID == team.TeamID).OrderBy(x => x.DateFrom).Select(x => x.member).ToList();
        }

        public Task<string> GetOrganizationName(Team team)
        {
            return _context.Organizations.Where(x => x.OrganizationID == team.OrganizationID).Select(x => x.OrganizationName).FirstOrDefaultAsync();
        }

        public Task<Team> GetTeam(int id)
        {
            return _context.Teams.Where(x => x.TeamID == id).FirstOrDefaultAsync();
        }
        public Task<Membership> GetMembership(Member member, Team team)
        {
            return _context.Memberships.Where(x => x.MemberID == member.MemberID && x.TeamID == team.TeamID).FirstOrDefaultAsync();
        }
        public Task<string> GetOrganizationName(Member member)
        {
            return _context.Organizations.Where(x => x.OrganizationID == member.Organization.OrganizationID).Select(x => x.OrganizationName).FirstOrDefaultAsync();
        }
        public Task<Member> GetMember(int id)
        {
            return _context.Members.Where(x => x.MemberID == id).FirstOrDefaultAsync();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}