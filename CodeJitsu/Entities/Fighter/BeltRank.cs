using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace CodeJitsu.Entities.Fighter
{
    public class BeltRank : Entity<int>
    {
        public BeltColor Color { get; set; }

        [Range(0, 4)]
        public int Stripe { get; set; }

        public List<Fighter> Fighters { get; set; }
    }
}
