using System.Reflection;
using BulwarkStudios.Stanford.Torus.Buildings;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class NoAccidentsAtOptimalGauge
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandSectorAccidentManagement).GetMethod(nameof(CommandSectorAccidentManagement.BulwarkStudios_Stanford_Core_Commands_ICommandCustomTickable_OnCustomTick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref CommandSectorAccidentManagement __instance)
	{
		if (GMod.Plugin.configNoAccidents.Value)
		{
			__instance.ResetAccidentGauge();
		}
		return true;
	}
}

[HarmonyPatch]
public class NoAccidentsAtOptimalTremor
// by reverse engineering it seems that this chance is calcualted according to damage, the higher damage, higher chance of tremor (varying between 0%-50%)
// but what is chance of tremor? the chance of fatalities?
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandSectorAccidentManagement).GetMethod(nameof(CommandSectorAccidentManagement.GetTremorChance), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref CommandSectorAccidentManagement __instance, ref float __result)
	{
		if (GMod.Plugin.configNoAccidents.Value)
			__result = 0f;
	}
}

// below two mods disable accident effects completely; the accident events will
// still be generated internally, but their effects and DLS notifications will
// be killed before being applied
[HarmonyPatch]
public class NoAccidentsAllWorkingConditionsNotification
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandBuildingAccident).GetMethod(nameof(CommandBuildingAccident.BeforeSuccess), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref CommandBuildingAccident __instance)
	{
		return !GMod.Plugin.configNoAccidents.Value;
	}
}

[HarmonyPatch]
public class NoAccidentsAllWorkingConditionsExecute
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandBuildingAccident).GetMethod(nameof(CommandBuildingAccident.OnStart), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref CommandBuildingAccident __instance)
	{
		return !GMod.Plugin.configNoAccidents.Value;
	}
}