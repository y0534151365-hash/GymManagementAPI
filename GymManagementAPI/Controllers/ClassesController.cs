using GymManagementAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private static List<Class> classes = new List<Class>
        {
            new Class { Id = 1, ClassName = "זומבה בוקר", TrainerId = 1, DayOfWeek = "ראשון", StartTime = new TimeSpan(8, 0, 0), Duration = 60, MaxParticipants = 20, CurrentParticipants = 15 },
            new Class { Id = 2, ClassName = "יוגה ערב", TrainerId = 2, DayOfWeek = "שני", StartTime = new TimeSpan(18, 30, 0), Duration = 75, MaxParticipants = 15, CurrentParticipants = 10 }
        };

        // GET: api/classes
        [HttpGet]
        public ActionResult<IEnumerable<Class>> GetAll()
        {
            return Ok(classes);
        }

        // GET: api/classes/5
        [HttpGet("{id}")]
        public ActionResult<Class> GetById(int id)
        {
            var classItem = classes.FirstOrDefault(c => c.Id == id);
            if (classItem == null)
            {
                return NotFound();
            }
            return Ok(classItem);
        }

        // POST: api/classes
        [HttpPost]
        public ActionResult<Class> Create(Class classItem)
        {
            classItem.Id = classes.Any() ? classes.Max(c => c.Id) + 1 : 1;
            classes.Add(classItem);
            return CreatedAtAction(nameof(GetById), new { id = classItem.Id }, classItem);
        }

        // PUT: api/classes/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, Class updatedClass)
        {
            var classItem = classes.FirstOrDefault(c => c.Id == id);
            if (classItem == null)
            {
                return NotFound();
            }

            classItem.ClassName = updatedClass.ClassName;
            classItem.TrainerId = updatedClass.TrainerId;
            classItem.DayOfWeek = updatedClass.DayOfWeek;
            classItem.StartTime = updatedClass.StartTime;
            classItem.Duration = updatedClass.Duration;
            classItem.MaxParticipants = updatedClass.MaxParticipants;
            classItem.CurrentParticipants = updatedClass.CurrentParticipants;

            return NoContent();
        }

        // DELETE: api/classes/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var classItem = classes.FirstOrDefault(c => c.Id == id);
            if (classItem == null)
            {
                return NotFound();
            }

            classes.Remove(classItem);
            return NoContent();
        }

        // GET: api/classes/day/ראשון
        [HttpGet("day/{dayOfWeek}")]
        public ActionResult<IEnumerable<Class>> GetByDay(string dayOfWeek)
        {
            var filtered = classes.Where(c => c.DayOfWeek.Equals(dayOfWeek, StringComparison.OrdinalIgnoreCase)).ToList();
            return Ok(filtered);
        }
    }
}
