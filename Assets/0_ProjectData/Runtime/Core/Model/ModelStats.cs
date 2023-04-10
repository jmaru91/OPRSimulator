using System.Collections.Generic;
using UnityEngine;

namespace OPR
{
    public struct ModelStats
    {
        public Vector2 BaseSize { get; }
        public int Quality { get; }
        public int Defence { get; }
        public IReadOnlyList<Weapon> Weapons { get; }
        public IReadOnlyList<ISpecialRule> SpecialRules { get; }
        
        public ModelStats(Vector2 baseSize, int quality, int defence, IReadOnlyList<Weapon> weapons, IReadOnlyList<ISpecialRule> specialRules)
        {
            BaseSize = baseSize;
            Quality = quality;
            Defence = defence;
            Weapons = weapons;
            SpecialRules = specialRules;
        }
    }
}