using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace CodeJitsu.Entities.Fighter
{
    public class TrainingSession : Entity<int>
    {
        public string LevelDescription { get; set; }

        public int TotalSessionTime { get; set; }

        public DateTime TrainingDate { get; set; }

        public int? HowManyDifferentPairs { get; set; }

        public int PositionalSparringRounds { get; set; }
        public int PositionalSparringTime { get; set; } // in minutes

        public int FreeSparringRounds { get; set; }
        public int FreeSparringTime { get; set; }   // in minutes

        public List<Technique> Techniques { get; set; }

        [Required]
        public Guid InstructorId { get; set; }
        public Fighter Instructor { get; set; }

        [Required]
        public List<Fighter> Students { get; set; }
    }
}
