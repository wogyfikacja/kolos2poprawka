using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using kolokwium2.Services;
using kolokwium2.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace kolokwium2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService _teamsService;
        public TeamsController(ITeamsService teamsService)
        {
            _teamsService = teamsService;
        }
        [HttpGet("{idTeam}")]
        public async Task<IActionResult> GetTeamWithOrganizationNameAndMemberList(int idTeam)
        {
            var team = await _teamsService.GetTeam(idTeam);
            if (team == null)
            {
                return NotFound();
            }
            var organizationName = await _teamsService.GetOrganizationName(team);
            var members = _teamsService.GetMembers(team);
            var membersDTO = new List<MemberDTO>();

            foreach (var member in members)
            {
                var membership = await _teamsService.GetMembership(member, team);
                membersDTO.Add(new MemberDTO{
                    Name = member.FirstName,
                    Surname = member.Surname,
                    Nickname = member.Nickname,
                    MembershipDate = membership.DateFrom
                });
            }

            var TeamDTO = new TeamDTO
            {
                TeamName = team.TeamName,
                OrganizationName = organizationName,
                TeamDescription = team.TeamDescription,
                TeamMembers = membersDTO
            };
            return Ok(TeamDTO);
        }
        [HttpPost("{idTeam}/{idMember}")]
        //add member to a team if the organization is the same for both of them
        public async Task<IActionResult> AddMember(int idTeam, int idMember)
        {
            var team = await _teamsService.GetTeam(idTeam);
            var member = await _teamsService.GetMember(idMember);
            if (team == null || member == null)
            {
                return NotFound();
            }
            var organizationName = await _teamsService.GetOrganizationName(member);
            var teamOrganizationName = await _teamsService.GetOrganizationName(team);
            if (teamOrganizationName != organizationName)
            {
                return BadRequest("Organization name is not the same");
            }
            _teamsService.AddMember(member, team);
            await _teamsService.SaveChangesAsync();
            return Ok();
        }
    }
}