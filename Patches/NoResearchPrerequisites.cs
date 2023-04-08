using System.Reflection;
using BulwarkStudios.Stanford.Common.TechTree;
using BulwarkStudios.Stanford.Common.UI;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class NoResearchPrerequisitesInternal
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(TechnologyData).GetProperty(nameof(TechnologyData.IsLockByTier), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy)?.GetGetMethod();
	}

	[HarmonyPrefix]
	public static bool Prefix(ref TechnologyData __instance)
	{
		if (GMod.Plugin.configNoResearchPrerequisites.Value)
		{
			__instance.requiredTier = null;
			__instance.techDependencies.Clear();
		}
		return true;

	}
}

[HarmonyPatch]
public class NoResearchPrerequisitesButton
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(UITechnologyInfos).GetMethod(nameof(UITechnologyInfos.UpdateButtons), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref UITechnologyInfos __instance)
	{
		if (GMod.Plugin.configNoResearchPrerequisites.Value)
		{
			__instance.technologyData.requiredTier = null;
			__instance.technologyData.techDependencies.Clear();
		}
		return true;
	}
}