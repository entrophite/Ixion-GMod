using System.Reflection;
using BulwarkStudios.Stanford.SolarSystem.SpaceVehicles.Actions;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class ResourceExtractSpeedMiningShip
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(SpaceVehicleActionBehaviourMiningShip).GetMethod(nameof(SpaceVehicleActionBehaviourMiningShip.GetMiningSpeed), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref float __result)
	{
		__result *= GMod.Plugin.configResourceExtractSpeedMultiplier.Value;
	}
}

[HarmonyPatch]
public class ResourceExtractSpeedScienceShip
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(SpaceVehicleActionBehaviourScienceShip).GetMethod(nameof(SpaceVehicleActionBehaviourScienceShip.GetScienceExtractionSpeed), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref float __result)
	{
		__result *= GMod.Plugin.configResourceExtractSpeedMultiplier.Value;
	}
}