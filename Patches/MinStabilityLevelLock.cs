using System.Reflection;
using BulwarkStudios.Stanford.Torus.Sectors;
using HarmonyLib;
using Il2CppSystem;

namespace GMod.Patches;

[HarmonyPatch]
public class MinStabilityLevelLock
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(TorusSectorStateStability).GetMethod(nameof(TorusSectorStateStability.RecalculateStability), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref int __result)
	{
		__result = Math.Max(GMod.Plugin.configMinStabilityLevel.Value, __result);
	}
}