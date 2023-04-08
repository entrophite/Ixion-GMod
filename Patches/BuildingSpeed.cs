using System.Reflection;
using BulwarkStudios.Stanford.Torus.Buildings;
using BulwarkStudios.Stanford.Core.Instances.Commands;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class BuildSpeedWorkshopBuilding
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandBuildableBuild).GetMethod(nameof(CommandBuildableBuild.OnTick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref CommandBuildableBuild __instance, ref float deltaTime)
	{
		deltaTime *= GMod.Plugin.configWorkshopBuildingSpeedMultiplier.Value;
		return true;
	}
}

[HarmonyPatch]
public class BuildSpeedWorkshopRoad
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandBuildableBuildRoad).GetMethod(nameof(CommandBuildableBuildRoad.OnTick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref CommandBuildableBuildRoad __instance, ref float deltaTime)
	{
		deltaTime *= GMod.Plugin.configWorkshopBuildingSpeedMultiplier.Value;
		return true;
	}
}

[HarmonyPatch]
public class BuildSpeedWorkshopRepair
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandBuildingWorkshop).GetMethod(nameof(CommandBuildingWorkshop.CustomTick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref float deltaTime)
	{
		deltaTime *= GMod.Plugin.configWorkshopBuildingSpeedMultiplier.Value;
		return true;
	}
}

[HarmonyPatch]
public class BuildSpeedEVAAirlockBuilding
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandBuildObjectGetEffortFromEVABuilders).GetMethod(nameof(CommandBuildObjectGetEffortFromEVABuilders.OnCustomTick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref float deltaTime)
	{
		deltaTime *= GMod.Plugin.configEVAAirlockBuildingSpeedMultiplier.Value;
		return true;
	}
}

[HarmonyPatch]
public class BuildSpeedEVAAirlockSolarPanelRepair
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandSolarPanelsRepair).GetMethod(nameof(CommandSolarPanelsRepair.BulwarkStudios_Stanford_Core_Commands_ICommandCustomTickable_OnCustomTick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref float deltaTime)
	{
		deltaTime *= GMod.Plugin.configEVAAirlockBuildingSpeedMultiplier.Value;
		return true;
	}
}

[HarmonyPatch]
public class BuildSpeedProbeAndShip
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandBuildObjectGetEffortFromBuilding).GetMethod(nameof(CommandBuildObjectGetEffortFromBuilding.OnCustomTick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref float deltaTime)
	{
		deltaTime *= GMod.Plugin.configProbeAndShipBuildingSpeedMultiplier.Value;
		return true;
	}
}