using Volo.Abp.Domain.Entities;

namespace CodeJitsu.Entities.Fighter
{
    public class Technique : Entity<int>
    {
        public string Description { get; set; }
        public string StartingPosition { get; set; }
        public string DemoVideoLink { get; set; }

        public Guid? FighterId { get; set; }
        public Fighter Fighter { get; set; }
    }
}
