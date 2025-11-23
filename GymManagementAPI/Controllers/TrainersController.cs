using GymManagementAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private static List<Trainer> trainers = new List<Trainer>
        {
            new Trainer { Id = 1, FirstName = "דני", LastName = "אברהם", Email = "danny@gym.com", Phone = "054-1111111", Specialization = "כושר", YearsOfExperience = 5, IsAvailable = true },
            new Trainer { Id = 2, FirstName = "מיכל", LastName = "דוד", Email = "michal@gym.com", Phone = "053-2222222", Specialization = "יוגה", YearsOfExperience = 3, IsAvailable = true }
        };

        // GET: api/trainers
        [HttpGet]
        public ActionResult<IEnumerable<Trainer>> GetAll()
        {
            return Ok(trainers);
        }

        // GET: api/trainers/5
        [HttpGet("{id}")]
        public ActionResult<Trainer> GetById(int id)
        {
            var trainer = trainers.FirstOrDefault(t => t.Id == id);
            if (trainer == null)
            {
                return NotFound();
            }
            return Ok(trainer);
        }

        // POST: api/trainers
        [HttpPost]
        public ActionResult<Trainer> Create(Trainer trainer)
        {
            trainer.Id = trainers.Any() ? trainers.Max(t => t.Id) + 1 : 1;
            trainers.Add(trainer);
            return CreatedAtAction(nameof(GetById), new { id = trainer.Id }, trainer);
        }

        // PUT: api/trainers/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, Trainer updatedTrainer)
        {
            var trainer = trainers.FirstOrDefault(t => t.Id == id);
            if (trainer == null)
            {
                return NotFound();
            }

            trainer.FirstName = updatedTrainer.FirstName;
            trainer.LastName = updatedTrainer.LastName;
            trainer.Email = updatedTrainer.Email;
            trainer.Phone = updatedTrainer.Phone;
            trainer.Specialization = updatedTrainer.Specialization;
            trainer.YearsOfExperience = updatedTrainer.YearsOfExperience;
            trainer.IsAvailable = updatedTrainer.IsAvailable;

            return NoContent();
        }

        // DELETE: api/trainers/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var trainer = trainers.FirstOrDefault(t => t.Id == id);
            if (trainer == null)
            {
                return NotFound();
            }

            trainers.Remove(trainer);
            return NoContent();
        }

        // GET: api/trainers/specialization/יוגה
        [HttpGet("specialization/{type}")]
        public ActionResult<IEnumerable<Trainer>> GetBySpecialization(string type)
        {
            var filtered = trainers.Where(t => t.Specialization.Contains(type, StringComparison.OrdinalIgnoreCase)).ToList();
            return Ok(filtered);
        }
    }
}
