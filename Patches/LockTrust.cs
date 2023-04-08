using System.Reflection;
using BulwarkStudios.Stanford.Core.GameStates;
using BulwarkStudios.Stanford.Torus.Buildings;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class LockTrust
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandTorusTrustManagement).GetMethod(nameof(CommandTorusTrustManagement.DayChanged), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix()
	{
		if (GMod.Plugin.configLockTrust.Value)
			Game.Torus.torus.State.torusTrust.trust = 100f;
	}
}