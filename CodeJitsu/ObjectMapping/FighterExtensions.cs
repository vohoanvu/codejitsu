using CodeJitsu.Controllers.Dtos;
using CodeJitsu.Entities.Fighter;

namespace CodeJitsu.ObjectMapping
{
    public static class FighterExtensions
    {
        public static void Update(this Fighter destination, UpdateFighterDto source)
        {
            destination.FighterName = source.FighterName;
            destination.Gender = Enum.Parse<Gender>(source.Gender);
            destination.Role = Enum.Parse<FighterRole>(source.FighterRole);
            destination.BMI = source.Weight / (source.Height * source.Weight);
            destination.Height = source.Height;
            destination.Weight = source.Weight;
            destination.MaxWorkoutDuration = source.MaxWorkoutDuration;
        }
    }
}
