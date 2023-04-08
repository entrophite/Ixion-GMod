using System.Reflection;
using BulwarkStudios.Stanford.Common.Players;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class SciencePassiveAccrualTechLab
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandAddScience).GetMethod(nameof(CommandAddScience.OnStart), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(CommandAddScience __instance)
	{
		__instance.scienceAmountToAdd = (int)(__instance.scienceAmountToAdd * GMod.Plugin.configTechLabScienceAccuralMultiplier.Value);
		return true;
	}
}


[HarmonyPatch]
public class ScienceAccrualStellarObject
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandAddScienceOnStellarObject).GetMethod(nameof(CommandAddScienceOnStellarObject.OnStart), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(CommandAddScienceOnStellarObject __instance)
	{
		__instance.scienceAmountToAdd = (int)(__instance.scienceAmountToAdd * GMod.Plugin.configPOIScienceCurateMultiplier.Value);
		return true;
	}
}