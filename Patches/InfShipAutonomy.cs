﻿using System.Reflection;
using BulwarkStudios.Stanford.SolarSystem.SpaceVehicles.Commands;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class InfShipAutonomy
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandAutonomousSpaceVehicle).GetMethod(nameof(CommandAutonomousSpaceVehicle.BulwarkStudios_Stanford_Core_Commands_ICommandCustomTickable_OnCustomTick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref CommandAutonomousSpaceVehicle __instance)
	{
		if (GMod.Plugin.configInfShipAutonomy.Value)
			__instance.spaceVehicle.State.AutonomyLeft = 10f * 60f; // 60 == 1 cycle.
		return true;
	}
}