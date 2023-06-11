using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Identity;

namespace CodeJitsu.Entities.Fighter
{
    public class AppUser : IdentityUser
    {
        public Guid FighterId { get; set; }
        [ForeignKey("FighterId")]
        public virtual Fighter Fighter { get; set; }
    }
}
