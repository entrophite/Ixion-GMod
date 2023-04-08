using System.Reflection;
using BulwarkStudios.Stanford.Torus.Buildings;
using BulwarkStudios.Stanford.Torus.Buildings.Actions;
using BulwarkStudios.Stanford.Torus.Buildings.Commands;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class UnlimitedInSectorTransportersBringResrouces
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandBuildingStockpile).GetMethod(nameof(CommandBuildingStockpile.BringResources), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref CommandBuildingStockpile __instance)
	{
		if (GMod.Plugin.configUnlimitedInSectorTransporters.Value)
			__instance.nbTransporter = 0;
	}
}

[HarmonyPatch]
public class UnlimitedInSectorTransportersCollectResrouces
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandBuildingStockpile).GetMethod(nameof(CommandBuildingStockpile.CollectResources), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref CommandBuildingStockpile __instance)
	{
		if (GMod.Plugin.configUnlimitedInSectorTransporters.Value)
			__instance.nbTransporter = 0;
	}
}

// OK, reverse engineering shows that the 5 inter-sector transporters per
// resource per sector is hard-code in ManageSpecialTransporters(),
// unfortunately; the only way to mod it out is to remove its limit completely.
[HarmonyPatch]
public class UnlimitedInterSectorTransporters
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandTransporterTransferResourcesToSector).GetMethod(nameof(CommandTransporterTransferResourcesToSector.Added), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref CommandTransporterTransferResourcesToSector __instance)
	{
		if (GMod.Plugin.configUnlimitedInterSectorTransporters.Value)
			__instance.fromSector.value.state.availableSpecialTransporters[__instance.resource] = 0;
	}
}
