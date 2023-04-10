namespace OPR
{
    public enum UnitState
    {
        Idle,
        Activable,
        CanShoot,
        CanCharge,
        CanShootOrCharge,
        Shooting,
        PickWeapon,
        PickTarget,
        ResolveShooting,
        Charging,
        ResolveMelee,
        Advancing,
        Advanced,
        CanShootAfterAdvanced,
        Rushing,
        Weavering,
        Activated,
        Destroyed,
        Routed,
    }
}