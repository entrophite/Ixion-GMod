using System.Reflection;
using BulwarkStudios.Stanford.SolarSystem.SpaceVehicles.Actions;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class ProbeScanRange
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(SpaceVehicleActionBehaviourProbe).GetMethod(nameof(SpaceVehicleActionBehaviourProbe.GetScanRange), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref float __result)
	{
		__result *= GMod.Plugin.configProbeScanRangeMultiplier.Value;
	}
}