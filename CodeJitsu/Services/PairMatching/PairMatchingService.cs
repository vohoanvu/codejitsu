using CodeJitsu.Entities.Fighter;

namespace CodeJitsu.Services.PairMatching
{
    public class PairMatchingService
    {
        private readonly List<Fighter> _fighters;
        private Fighter? _fighter1 = null;
        private Fighter? _fighter2 = null;

        public PairMatchingService(List<Fighter> fighters)
        {
            _fighters = fighters;
        }

        public List<Tuple<Fighter, Fighter>> GenerateFighterPairs()
        {
            List<Tuple<Fighter, Fighter>> pairs = new List<Tuple<Fighter, Fighter>>();

            if (_fighters.Count % 2 != 0)
            {
                // If there is an odd number of fighters in the list, create a new fighter of FighterRole.Instructor role and pair up with one of them.
                Fighter instructor = CreateInstructor();
                Tuple<Fighter, Fighter> instructorPair = PairUpOddFighter(instructor);
                pairs.Add(instructorPair);
            }

            while (_fighters.Count > 0)
            {
                // Find the closest matching pair among the remaining fighters and add it to the list of pairs.
                Tuple<Fighter, Fighter> pair = FindMatchingPair();
                pairs.Add(pair);
            }

            return pairs;
        }

        private Tuple<Fighter, Fighter> PairUpOddFighter(Fighter instructor)
        {
            var bestFighter = FindTheHighestRankFighter();
            return new Tuple<Fighter, Fighter>(instructor, bestFighter);
        }

        private Fighter FindTheHighestRankFighter()
        {
            Fighter highestRankFighter = _fighters[0];

            for (int i = 1; i < _fighters.Count; i++)
            {
                Fighter currentFighter = _fighters[i];

                int beltComparison = CompareTo(highestRankFighter.BeltRank, currentFighter.BeltRank);

                if (beltComparison < 0)
                {
                    // Current fighter has a higher belt rank than highest ranking fighter. Update highest ranking fighter.
                    highestRankFighter = currentFighter;

                }
                else if (beltComparison == 0)
                {

                    // Current fighter has an equal belt rank as highest ranking fighter. Compare max workout duration and BMI.

                    if (currentFighter.MaxWorkoutDuration > highestRankFighter.MaxWorkoutDuration)
                    {

                        // Current fighter has a higher max workout duration than highest ranking fighter. Update highest ranking fighter.

                        highestRankFighter = currentFighter;

                    }
                    else if (currentFighter.MaxWorkoutDuration == highestRankFighter.MaxWorkoutDuration)
                    {

                        // Current fighter has an equal max workout duration as highest ranking fighter. Compare BMI.

                        if (currentFighter.BMI > highestRankFighter.BMI)
                        {

                            // Current fighter has a higher BMI than highest ranking fighter. Update highest ranking fighter.

                            highestRankFighter = currentFighter;

                        }

                    }

                }

            }

            return highestRankFighter;
        }

        private Fighter CreateInstructor()
        {
            return new Fighter
            {
                Role = FighterRole.Instructor
            };
        }

        public Tuple<Fighter, Fighter> FindMatchingPair()
        {
            double closestDifference = double.MaxValue;

            for (int i = 0; i < _fighters.Count; i++)
            {
                for (int j = i + 1; j < _fighters.Count; j++)
                {
                    double currentDifference = Math.Abs(_fighters[i].Weight - _fighters[j].Weight) + 
                                               Math.Abs(_fighters[i].BMI - _fighters[j].BMI) + 
                                               Math.Abs(_fighters[i].BeltRank.Stripe - _fighters[j].BeltRank.Stripe) + 
                                               Math.Abs(_fighters[i].MaxWorkoutDuration - _fighters[j].MaxWorkoutDuration);
                    // Calculate the difference in FavoriteTechniqueToBeDrilled rankings
                    //double favoriteTechniqueDifference = CalculateFavoriteTechniqueDifference(_fighters[i], _fighters[j]);
                    //currentDifference += favoriteTechniqueDifference;

                    if (currentDifference < closestDifference)
                    {
                        closestDifference = currentDifference;
                        _fighter1 = _fighters[i];
                        _fighter2 = _fighters[j];
                    }
                }
            }

            if (_fighter1 == null || _fighter2 == null)
            {
                throw new ApplicationException("There is a problem in the pairing process, one of the 2 fighters is NULL");
            }

            return new Tuple<Fighter, Fighter>(_fighter1, _fighter2);
        }   

        //private double CalculateFavoriteTechniqueDifference(Fighter fighter1, Fighter fighter2)
        //{
        //    double favoriteTechniqueDifference = 0;
        //    foreach (var technique in fighter1.FavoriteTechniqueToBeDrilled)
        //    {
        //        if (fighter2.FavoriteTechniqueToBeDrilled.ContainsKey(technique.Key))
        //        {
        //            favoriteTechniqueDifference += Math.Abs(technique.Value - fighter2.FavoriteTechniqueToBeDrilled[technique.Key]);
        //        }
        //        else
        //        {
        //            favoriteTechniqueDifference += technique.Value;
        //        }
        //    }
        //    foreach (var technique in fighter2.FavoriteTechniqueToBeDrilled)
        //    {
        //        if (!fighter1.FavoriteTechniqueToBeDrilled.ContainsKey(technique.Key))
        //        {
        //            favoriteTechniqueDifference += technique.Value;
        //        }
        //    }
        //    return favoriteTechniqueDifference;
        //}


        // TODO: add a method to compare two belt ranks based on their color and stripe. Return -1 if this rank is lower than the other rank, 
        // return +1 if this rank is higher than the other rank, return zero if they are equal.
        private static int CompareTo(BeltRank source, BeltRank other)
        {
            // Define an order of colors from lowest to highest as white, blue, purple, brown, black.
            string[] colors = { "white", "blue", "purple", "brown", "black" };

            // Find the index of this color and the other color in the array.
            int thisIndex = Array.IndexOf(colors, source.Color);
            int otherIndex = Array.IndexOf(colors, other.Color);

            if (thisIndex < otherIndex)
            {
                // This color is lower than the other color.
                return -1;
            }

            if (thisIndex > otherIndex)
            {
                // This color is higher than the other color.
                return +1;
            }
            // The colors are equal. Compare the stripes.
            if (source.Stripe < other.Stripe)
            {
                // This stripe is lower than the other stripe.
                return -1;
            }
            if (source.Stripe > other.Stripe)
            {
                // This stripe is higher than the other stripe.
                return +1;
            }
            // The stripes are equal. The ranks are equal.
            return 0;
        }
    }
}
