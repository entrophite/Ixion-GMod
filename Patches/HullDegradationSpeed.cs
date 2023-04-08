using System.Reflection;
using BulwarkStudios.Stanford.Torus.Torus.Structure;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class HullDegradationSpeed
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(TorusInstance).GetMethod(nameof(TorusInstance.DegradationPerCycle), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref float __result)
	{
		__result *= GMod.Plugin.configHullDegradationSpeedMultiplier.Value;
	}
}