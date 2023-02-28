﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace CodeJitsu.Entities.Fighter
{
    public class Fighter : Entity<Guid>
    {
        public string FighterName { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public double BMI { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public FighterRole Role { get; set; }

        [Required]
        public int MaxWorkoutDuration { get; set; }

        public int BeltRankId { get; set; }
        [ForeignKey("BeltRankId")]
        public virtual BeltRank BeltRank { get; set; }
    }
}