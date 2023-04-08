using System.Reflection;
using BulwarkStudios.Stanford.Core.GameStates;
using BulwarkStudios.Stanford.Torus.Structure;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class LockHallIntegrity
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandHullConsumption).GetMethod(nameof(CommandHullConsumption.Tick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix()
	{
		if (GMod.Plugin.configLockHullIntegrity.Value)
			Game.Torus.torus.State.HullIntegrity = Game.Torus.torus.State.MaxHullIntegrity;
		return true;
	}
}