using System.Reflection;
using BulwarkStudios.Stanford.Torus.Buildings;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class PerpectualNuclearPowerPlant
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandBuildingNuclearPowerPlant).GetMethod(nameof(CommandBuildingNuclearPowerPlant.OnTick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref CommandBuildingNuclearPowerPlant __instance)
	{
		if (__instance.building.state.isRunning && GMod.Plugin.configPerpectualNuclearPowerPlant.Value)
		{
			var action_state = __instance.state;
			action_state.producingElectricity = true;
			action_state.generatedElectricity = action_state.targetHydrogenConsumption * __instance.action.generatedElectricity;
		}
	}
}