using System.Reflection;
using BulwarkStudios.Stanford.Common.TechTree;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class ResearchSpeed
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandResearchTechnology).GetMethod(nameof(CommandResearchTechnology.BulwarkStudios_Stanford_Core_Commands_ICommandCustomTickable_OnCustomTick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref float deltaTime)
	{
		deltaTime *= GMod.Plugin.configResearchSpeedMultiplier.Value;
		return true;
	}
}