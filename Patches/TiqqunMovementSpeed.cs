using System.Reflection;
using BulwarkStudios.Stanford.Torus.Torus.Structure;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class TiqqunMovementSpeed
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(TorusInstance).GetMethod(nameof(TorusInstance.Initialize), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref TorusInstance __instance)
	{
		__instance.Data.peakSpeed *= GMod.Plugin.configTiqqunTopMovementSpeedMultiplier.Value;
	}
}