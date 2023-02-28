using System.ComponentModel.DataAnnotations;

namespace CodeJitsu.Services.Dtos
{
    public class FighterDtoBase
    {
        [Display(Name = "Fighter nickname")]
        public string? FighterName { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string FighterRole { get; set; }

        [Required]
        public int MaxWorkoutDuration { get; set; }

        [Required]
        public string BeltColor { get; set; }

        [Range(0, 4)]
        [Required]
        public int Stripe { get; set; }
    }
}
