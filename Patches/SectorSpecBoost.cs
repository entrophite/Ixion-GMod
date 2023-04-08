using System.Reflection;
using BulwarkStudios.Stanford.Common.Specialization;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class SectorSpecBoost
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(SpecializationState).GetMethod(nameof(SpecializationState.CalculateHighestTierUnlocked), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref SpecializationState __instance)
	{
		if (__instance.score > GMod.Plugin.configSectorSpecBoostThreshold.Value)
			__instance.score = 2000; // 1680 should be enough? sector size is 56x30
		return true;
	}
}