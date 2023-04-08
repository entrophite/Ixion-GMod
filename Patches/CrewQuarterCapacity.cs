using System.Reflection;
using BulwarkStudios.Stanford.Torus.Buildings.Actions;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class CrewQuarterCapacity
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(BuildingActionBehaviourQuarter).GetMethod(nameof(BuildingActionBehaviourQuarter.GetMaxCitizen), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref BuildingActionBehaviourQuarter __instance, ref int __result)
	{
		__result = (int)(__result * GMod.Plugin.configCrewQuarterCapacityMultiplier.Value);
	}
}