using System.Reflection;
using BulwarkStudios.Stanford.Torus.Pathfinding;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class TransporterMovementSpeed
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(PathfindingUnit).GetProperty(nameof(PathfindingUnit.ScaledSpeed), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy)?.GetGetMethod();
	}

	[HarmonyPostfix]
	public static void Postfix(ref float __result)
	{
		__result *= GMod.Plugin.configTransporterMovementSpeedMultiplier.Value;
	}
}
