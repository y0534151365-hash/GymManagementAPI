using GymManagementAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private static List<Member> members = new List<Member>
        {
            new Member { Id = 1, FirstName = "יוסי", LastName = "כהן", Email = "yossi@gmail.com", Phone = "050-1234567", MembershipType = "חודשי", StartDate = DateTime.Now.AddMonths(-3), IsActive = true },
            new Member { Id = 2, FirstName = "שרה", LastName = "לevi", Email = "sara@gmail.com", Phone = "052-9876543", MembershipType = "שנתי", StartDate = DateTime.Now.AddMonths(-6), IsActive = true }
        };

        // GET: api/members
        [HttpGet]
        public ActionResult<IEnumerable<Member>> GetAll()
        {
            return Ok(members);
        }

        // GET: api/members/5
        [HttpGet("{id}")]
        public ActionResult<Member> GetById(int id)
        {
            var member = members.FirstOrDefault(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }

        // POST: api/members
        [HttpPost]
        public ActionResult<Member> Create(Member member)
        {
            member.Id = members.Max(m => m.Id) + 1;
            members.Add(member);
            return CreatedAtAction(nameof(GetById), new { id = member.Id }, member);
        }

        // PUT: api/members/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, Member updatedMember)
        {
            var member = members.FirstOrDefault(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            member.FirstName = updatedMember.FirstName;
            member.LastName = updatedMember.LastName;
            member.Email = updatedMember.Email;
            member.Phone = updatedMember.Phone;
            member.MembershipType = updatedMember.MembershipType;
            member.IsActive = updatedMember.IsActive;

            return NoContent();
        }

        // DELETE: api/members/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var member = members.FirstOrDefault(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            members.Remove(member);
            return NoContent();
        }

        // GET: api/members/active
        [HttpGet("active")]
        public ActionResult<IEnumerable<Member>> GetActive()
        {
            var activeMembers = members.Where(m => m.IsActive).ToList();
            return Ok(activeMembers);
        }
    }
}
