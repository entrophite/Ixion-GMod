using System.Reflection;
using BulwarkStudios.Stanford.Torus.Buildings;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class StockpileCapacity
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(BuildingActionTotalCapacity).GetMethod(nameof(BuildingActionTotalCapacity.GetTotalCapacityStockpile), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref int __result)
	{
		__result = (int)(__result * GMod.Plugin.configStockpileCapacityMultiplier.Value);
	}
}

[HarmonyPatch]
public class DockingBayCapacity
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(DockingBayAvailableStock).GetMethod(nameof(DockingBayAvailableStock.GetTotalCapacity), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref int __result)
	{
		__result = (int)(__result * GMod.Plugin.configDockingBayCapacityMultiplier.Value);
	}
}