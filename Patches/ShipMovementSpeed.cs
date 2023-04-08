using System.Reflection;
using BulwarkStudios.Stanford.SolarSystem.SpaceVehicles;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class ShipMovementSpeed
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(SpaceVehicleData).GetMethod(nameof(SpaceVehicleData.GetSpeed), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref SpaceVehicleData __instance, ref float __result)
	{
		// TODO: test if Piranesi, Piranesi missle and Piranesi swarm are incorrectly boosted
		if (__instance.IsCargoShip || __instance.IsMiningShip || __instance.IsProbe || __instance.IsScienceShip)
			__result *= GMod.Plugin.configShipMovementSpeedMultiplier.Value;
	}
}