using System.Reflection;
using BulwarkStudios.Stanford.Common.Weather;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class ShipStormImmunity1
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandWeather).GetMethod(nameof(CommandWeather.AddSpaceVehicleStateToInside), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref CommandWeather __instance)
	{
		if (GMod.Plugin.configShipStormImmunity.Value)
			__instance.spaceVehiclesInside.Clear();
		return false;
	}
}

[HarmonyPatch]
public class ShipStormImmunity2
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(WeatherBehaviour).GetMethod(nameof(WeatherBehaviour.IsPointInsidePattern), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref bool __result)
	{
		if (GMod.Plugin.configShipStormImmunity.Value)
			__result = false;
		return false;
	}
}

[HarmonyPatch]
public class ShipStormImmunity3
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CommandWeather).GetMethod(nameof(CommandWeather.OnTick), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref CommandWeather __instance)
	{
		if (GMod.Plugin.configShipStormImmunity.Value)
		{
			__instance.spaceVehiclesInside.Clear();
			__instance.RefreshDefaultTickCycleTime();
		}
		return true;
	}
}