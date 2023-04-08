using System.Reflection;
using BulwarkStudios.Stanford.Torus.Buildings;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class NoRefundOnBuildingDestory
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandBuildingDestroyAfterAllCollectablesAreEmpty).GetMethod(nameof(CommandBuildingDestroyAfterAllCollectablesAreEmpty.OnStart), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref CommandBuildingDestroyAfterAllCollectablesAreEmpty __instance)
	{
		if (GMod.Plugin.configNoRefundOnBuildingDestory.Value)
		{
			__instance.building.value.state.availableStock.RemoveAllResources();
			__instance.building.value.state.availableStockOutgoing.RemoveAllResources();
		}
	}
}
