using System.Reflection;
using BulwarkStudios.Stanford.Torus.Buildings.Actions;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class FactoryProductionSpeed
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(BuildingActionBehaviourTransformation).GetMethod(nameof(BuildingActionBehaviourTransformation.GetTransformationSpeedMultiplier), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref float __result)
	{
		__result *= GMod.Plugin.configFactoryProductionSpeedMultiplier.Value;
	}
}