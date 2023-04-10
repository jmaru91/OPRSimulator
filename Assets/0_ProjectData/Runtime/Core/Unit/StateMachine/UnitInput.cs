namespace OPR
{
    public enum UnitInput
    {
        AnyEnemiesInShootRange,
        NoEnemiesInShootRange,
        AnyEnemiesInChargeRange,
        AnyEnemiesInShootAndChargeRange,
        Advance,
        Rush,
        Shoot,
        Charge,
        FriendlyTurnStarted,
        FriendlyTurnEnded,
        AnyModelsCanShootWithMoreThanOneWeapon,
        NoModelsCanShootWithMoreThanOneWeapon,
        WeaponPicked,
        TargetPicked,
        MovementsDone,
        ChargedUnitDestroyed,
        ChargedUnitDefeatedButNotDestroyed,
        ChargeLostButWithMoreThanHalfModels,
        ChargeLostButWithLessThanHalfModels,
        ChargingUnitDestroyed,
        EndTurn
    }
}