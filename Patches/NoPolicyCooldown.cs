using System.Reflection;
using BulwarkStudios.Stanford.Common.Decrees;
using HarmonyLib;

namespace GMod.Patches;

/*[HarmonyPatch]
public class NoPolicyCooldown
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(TorusSectorStateDecrees).GetProperty(nameof(TorusSectorStateDecrees.DecreeCooldownRemaining), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy)?.GetSetMethod();
	}

	[HarmonyPrefix]
	public static bool Prefix(ref float value)
	{
		if (GMod.Plugin.configNoPolicyCooldown.Value)
			value = 0f;
		return true;
	}
}*/

[HarmonyPatch]
public class NoPolicyCooldown
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandDecreeCooldown).GetMethod(nameof(CommandDecreeCooldown.OnStart), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref CommandDecreeCooldown __instance)
	{
		if (GMod.Plugin.configNoPolicyCooldown.Value)
			__instance.GetSectorDecrees().decreeCooldownRemaining = 0f;
	}
}