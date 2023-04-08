using System;
using System.Reflection;
using BulwarkStudios.Stanford.Common.Decrees;
using BulwarkStudios.Stanford.Common.DLS;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class NoDestabilizingPolicy
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(DecreeState).GetMethod(nameof(DecreeState.GetStabilityConsequence), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref DecreeState __instance)
	{
		if (GMod.Plugin.configNoDestabilizingPolicy.Value)
			foreach (var option in __instance.data.options)
			{
				if (option.stabilityConsequence < 0)
					option.stabilityConsequence = 0;
			}
		return true;
	}
}