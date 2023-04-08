using System.Reflection;
using BulwarkStudios.Stanford.SolarSystem.SpaceVehicles;
using BulwarkStudios.Stanford.SolarSystem.SpaceVehicles.Actions;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class ShipExpGain
{
	// looks like SpaceVehicleActionBehaviourCargoShip, SpaceVehicleActionBehaviourMiningShip, and SpaceVehicleActionBehaviourScienceShip are static
	// use below flag variables to avoid repeated modding
	private static bool cargoShipModded = false;
	private static bool miningShipModded = false;
	private static bool scienceShipModded = false;

	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(SpaceVehicleInstance).GetMethod(nameof(SpaceVehicleInstance.Initialize), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref SpaceVehicleInstance __instance)
	{
		var multiplier = GMod.Plugin.configShipExpGainMultiplier.Value;
		if (__instance.Data.IsCargoShip && !cargoShipModded)
		{
			__instance.Data.spaceVehicleAction.Cast<SpaceVehicleActionBehaviourCargoShip>().expPerResourcesUnloaded *= multiplier;
			cargoShipModded = true;
		}
		if (__instance.Data.IsMiningShip && !miningShipModded)
		{
			__instance.Data.spaceVehicleAction.Cast<SpaceVehicleActionBehaviourMiningShip>().expGainPerResourceMined *= multiplier;
			miningShipModded = true;
		}
		if (__instance.Data.IsScienceShip && !scienceShipModded)
		{
			__instance.Data.spaceVehicleAction.Cast<SpaceVehicleActionBehaviourScienceShip>().expGainPerScienceCollected *= multiplier;
			scienceShipModded = true;
		}
	}
}