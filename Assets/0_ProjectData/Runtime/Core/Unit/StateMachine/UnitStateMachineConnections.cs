using System.Collections.Generic;

namespace OPR
{
    public static class UnitStateMachineConnections
    {
        static readonly Dictionary<(UnitState, UnitInput), UnitState> s_connections = new()
        {
            { (UnitState.Idle, UnitInput.FriendlyTurnStarted), UnitState.Activable },
            { (UnitState.Activable, UnitInput.AnyEnemiesInShootRange), UnitState.CanShoot },
            { (UnitState.Activable, UnitInput.AnyEnemiesInChargeRange), UnitState.CanCharge },
            { (UnitState.Activable, UnitInput.AnyEnemiesInShootAndChargeRange), UnitState.CanShootOrCharge },
            { (UnitState.Activable, UnitInput.Advance), UnitState.Advancing },
            { (UnitState.Activable, UnitInput.Rush), UnitState.Rushing },
            { (UnitState.Activable, UnitInput.FriendlyTurnEnded), UnitState.Idle },
            { (UnitState.CanShoot, UnitInput.Shoot), UnitState.Shooting },
            { (UnitState.CanShoot, UnitInput.Advance), UnitState.Advancing },
            { (UnitState.CanShoot, UnitInput.Rush), UnitState.Rushing },
            { (UnitState.CanCharge, UnitInput.Charge), UnitState.Charging },
            { (UnitState.CanCharge, UnitInput.Advance), UnitState.Advancing },
            { (UnitState.CanCharge, UnitInput.Rush), UnitState.Rushing },
            { (UnitState.CanShootOrCharge, UnitInput.Shoot), UnitState.Shooting },
            { (UnitState.CanShootOrCharge, UnitInput.Charge), UnitState.Charging },
            { (UnitState.CanShootOrCharge, UnitInput.Advance), UnitState.Advancing },
            { (UnitState.CanShootOrCharge, UnitInput.Rush), UnitState.Rushing },
            { (UnitState.Shooting, UnitInput.AnyModelsCanShootWithMoreThanOneWeapon), UnitState.PickWeapon },
            { (UnitState.Shooting, UnitInput.NoModelsCanShootWithMoreThanOneWeapon), UnitState.PickTarget },
            { (UnitState.PickWeapon, UnitInput.WeaponPicked), UnitState.PickTarget },
            { (UnitState.PickTarget, UnitInput.TargetPicked), UnitState.ResolveShooting },
            { (UnitState.ResolveShooting, UnitInput.AnyModelsCanShootWithMoreThanOneWeapon), UnitState.PickWeapon },
            { (UnitState.ResolveShooting, UnitInput.NoModelsCanShootWithMoreThanOneWeapon), UnitState.Activated },
            { (UnitState.Charging, UnitInput.MovementsDone), UnitState.ResolveMelee },
            { (UnitState.ResolveMelee, UnitInput.ChargedUnitDestroyed), UnitState.Activated },
            { (UnitState.ResolveMelee, UnitInput.ChargedUnitDefeatedButNotDestroyed), UnitState.Activated },
            { (UnitState.ResolveMelee, UnitInput.ChargeLostButWithMoreThanHalfModels), UnitState.Weavering },
            { (UnitState.ResolveMelee, UnitInput.ChargeLostButWithLessThanHalfModels), UnitState.Routed },
            { (UnitState.ResolveMelee, UnitInput.ChargingUnitDestroyed), UnitState.Destroyed },
            { (UnitState.Advancing, UnitInput.MovementsDone), UnitState.Advanced },
            { (UnitState.Advanced, UnitInput.AnyEnemiesInShootRange), UnitState.CanShootAfterAdvanced },
            { (UnitState.Advanced, UnitInput.NoEnemiesInShootRange), UnitState.Activated },
            { (UnitState.CanShootAfterAdvanced, UnitInput.Shoot), UnitState.Shooting },
            { (UnitState.CanShootAfterAdvanced, UnitInput.EndTurn), UnitState.Activated },
            { (UnitState.Rushing, UnitInput.MovementsDone), UnitState.Activated },
            { (UnitState.Weavering, UnitInput.EndTurn), UnitState.Activated },
            { (UnitState.Activated, UnitInput.FriendlyTurnEnded), UnitState.Idle },
        };

        public static bool TryProcessInput(UnitState currentState, UnitInput input, out UnitState newState)
        {
            return s_connections.TryGetValue((currentState, input), out newState);
        }
    }
}