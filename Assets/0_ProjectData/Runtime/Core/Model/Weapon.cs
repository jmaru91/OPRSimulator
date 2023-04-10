using System.Collections.Generic;

namespace OPR
{
    public struct Weapon
    {
        public int Attacks { get; }
        public int Range { get; }
        public IReadOnlyList<ISpecialRule> SpecialRules { get; }

        public Weapon(int attacks, int range, IReadOnlyList<ISpecialRule> specialRules)
        {
            Attacks = attacks;
            Range = range;
            SpecialRules = specialRules;
        }
    }
}