using CodeJitsu.Entities.Fighter;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace CodeJitsu.Data.Seeding
{
    public class FighterSeed : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Fighter, Guid> _fighterRepo;
        private readonly IRepository<BeltRank, int> _rankRepo;

        public FighterSeed(IRepository<Fighter, Guid> fighterRepo, IRepository<BeltRank, int> rankRepo)
        {
            _fighterRepo = fighterRepo;
            _rankRepo = rankRepo;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _rankRepo.CountAsync() == 0)
            {
                var bjjBelts = new List<BeltRank>
                {
                    new BeltRank { Color = BeltColor.White, Stripe = 0 },
                    new BeltRank { Color = BeltColor.White, Stripe = 1 },
                    new BeltRank { Color = BeltColor.White, Stripe = 2 },
                    new BeltRank { Color = BeltColor.White, Stripe = 3 },
                    new BeltRank { Color = BeltColor.White, Stripe = 4 },
                    new BeltRank { Color = BeltColor.Blue, Stripe = 0 },
                    new BeltRank { Color = BeltColor.Blue, Stripe = 1 },
                    new BeltRank { Color = BeltColor.Blue, Stripe = 2 },
                    new BeltRank { Color = BeltColor.Blue, Stripe = 3 },
                    new BeltRank { Color = BeltColor.Blue, Stripe = 4 },
                    new BeltRank { Color = BeltColor.Purple, Stripe = 0 },
                    new BeltRank { Color = BeltColor.Purple, Stripe = 1 },
                    new BeltRank { Color = BeltColor.Purple, Stripe = 2 },
                    new BeltRank { Color = BeltColor.Purple, Stripe = 3 },
                    new BeltRank { Color = BeltColor.Purple, Stripe = 4 },
                    new BeltRank { Color = BeltColor.Brown, Stripe = 0 },
                    new BeltRank { Color = BeltColor.Brown, Stripe = 1 },
                    new BeltRank { Color = BeltColor.Brown, Stripe = 2 },
                    new BeltRank { Color = BeltColor.Brown, Stripe = 3 },
                    new BeltRank { Color = BeltColor.Brown, Stripe = 4 },
                    new BeltRank { Color = BeltColor.Black, Stripe = 0 },
                    new BeltRank { Color = BeltColor.Black, Stripe = 1 },
                    new BeltRank { Color = BeltColor.Black, Stripe = 2 },
                    new BeltRank { Color = BeltColor.Black, Stripe = 3 },
                    new BeltRank { Color = BeltColor.Black, Stripe = 4 }
                };

                await _rankRepo.InsertManyAsync(bjjBelts);
            }

            var isAnyFighterExisting = await _fighterRepo.AnyAsync();
            if (!isAnyFighterExisting)
            {
                var mockedData = new List<Fighter>
                {
                    new Fighter
                    {
                        FighterName = "John Doe",
                        Height = 180,
                        Weight = 80,
                        BeltRankId = 3,
                        BMI = 25,
                        Gender = Gender.Male,
                        MaxWorkoutDuration = 5,
                        Role = FighterRole.Student
                    },
                    new Fighter
                    {
                        FighterName = "Jane Doe",
                        Height = 170,
                        Weight = 70,
                        BeltRankId = 12,
                        BMI = 24,
                        Gender = Gender.Female,
                        MaxWorkoutDuration = 5,
                        Role = FighterRole.Student
                    },
                    new Fighter
                    {
                        FighterName = "Bob Smith",
                        Height = 190,
                        Weight = 90,
                        BeltRankId = 9,
                        BMI = 27,
                        Gender = Gender.Male,
                        MaxWorkoutDuration = 5,
                        Role = FighterRole.Student
                    },
                    new Fighter
                    {
                        FighterName = "Sara Lee",
                        Height = 165,
                        Weight = 65,
                        BeltRankId = 1,
                        BMI = 24,
                        Gender = Gender.Female,
                        MaxWorkoutDuration = 5,
                        Role = FighterRole.Student
                    },
                    new Fighter
                    {
                        FighterName = "Peter Parker",
                        Height = 185,
                        Weight = 75,
                        BeltRankId = 24,
                        BMI = 24,
                        Gender = Gender.Male,
                        MaxWorkoutDuration = 5,
                        Role = FighterRole.Instructor
                    },
                    new Fighter
                    {
                        FighterName = "Mary Jane",
                        Height = 167,
                        Weight = 68,
                        BeltRankId = 12,
                        BMI = 22,
                        Gender = Gender.Female,
                        MaxWorkoutDuration = 5,
                        Role = FighterRole.Student
                    },
                    new Fighter
                    {
                        FighterName = "Harry Potter",
                        Height = 178,
                        Weight = 77,
                        BeltRankId = 8,
                        BMI = 24,
                        Gender = Gender.Male,
                        MaxWorkoutDuration = 5,
                        Role = FighterRole.Student
                    },
                    new Fighter
                    {
                        FighterName = "Hermione Granger",
                        Height = 170,
                        Weight = 71,
                        BeltRankId = 4,
                        BMI = 25,
                        Gender = Gender.Female,
                        MaxWorkoutDuration = 5,
                        Role = FighterRole.Student
                    },
                    new Fighter
                    {
                        FighterName = "Ron Weasley",
                        Height = 183,
                        Weight = 78,
                        BeltRankId = 2,
                        BMI = 26,
                        Gender = Gender.Male,
                        MaxWorkoutDuration = 5,
                        Role = FighterRole.Student
                    },
                    new Fighter
                    {
                        FighterName = "Vo Hoan Vu",
                        Height = 161,
                        Weight = 55,
                        BeltRankId = 2,
                        BMI = 26,
                        Gender = Gender.Male,
                        MaxWorkoutDuration = 5,
                        Role = FighterRole.Student
                    }
                };

                await _fighterRepo.InsertManyAsync(mockedData);
            }
        }
    }
}
