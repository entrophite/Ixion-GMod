using BepInEx;
using BepInEx.Unity.IL2CPP;
using BepInEx.Configuration;
using HarmonyLib;
using BepInEx.Logging;

namespace GMod
{
	[BepInPlugin("ixion-gmod", "GMod", "0.2")]
	public class Plugin : BasePlugin
	{
		internal static new ManualLogSource Log;

		// for patching method to use these values, the easiest way to make them static;
		// not sure if it's the *best* way, feel a little bit dirty.

		// GAME
		public static ConfigEntry<bool> configCanSkipChapter;
		// TIQQUN AND SECTORS
		public static ConfigEntry<int> configForceAddingWorkersTill;
		public static ConfigEntry<int> configMaxNonWorkers;
		public static ConfigEntry<float> configCrewQuarterCapacityMultiplier;
		public static ConfigEntry<float> configInjuryRecoverySpeedMultiplier;
		public static ConfigEntry<int> configSectorSpecBoostThreshold;
		public static ConfigEntry<float> configHullDegradationSpeedMultiplier;
		public static ConfigEntry<bool> configLockHullIntegrity;
		public static ConfigEntry<bool> configLockTrust;
		public static ConfigEntry<bool> configNoAccidents;
		public static ConfigEntry<bool> configNoPolicyCooldown;
		public static ConfigEntry<bool> configNoDestabilizingPolicy;
		public static ConfigEntry<int> configMinStabilityLevel;
		// PRODUCTION
		public static ConfigEntry<float> configStockpileCapacityMultiplier;
		public static ConfigEntry<float> configDockingBayCapacityMultiplier;
		public static ConfigEntry<float> configWorkshopBuildingSpeedMultiplier;
		public static ConfigEntry<float> configEVAAirlockBuildingSpeedMultiplier;
		public static ConfigEntry<float> configProbeAndShipBuildingSpeedMultiplier;
		public static ConfigEntry<float> configFactoryProductionSpeedMultiplier;
		public static ConfigEntry<bool> configUnlimitedInSectorTransporters;
		public static ConfigEntry<bool> configUnlimitedInterSectorTransporters;
		public static ConfigEntry<float> configTransporterMovementSpeedMultiplier;
		public static ConfigEntry<bool> configPerpectualNuclearPowerPlant;
		public static ConfigEntry<bool> configNoRefundOnBuildingDestory;
		// RESEARCH
		public static ConfigEntry<float> configResearchSpeedMultiplier;
		public static ConfigEntry<bool> configNoResearchPrerequisites;
		// SPACE AND RESOURCES
		public static ConfigEntry<bool> configShipStormImmunity;
		public static ConfigEntry<float> configResourceExtractSpeedMultiplier;
		public static ConfigEntry<float> configTechLabScienceAccuralMultiplier;
		public static ConfigEntry<float> configPOIScienceCurateMultiplier;
		public static ConfigEntry<bool> configInfShipAutonomy;
		public static ConfigEntry<float> configShipMovementSpeedMultiplier;
		public static ConfigEntry<float> configTiqqunTopMovementSpeedMultiplier;
		public static ConfigEntry<float> configShipExpGainMultiplier;
		public static ConfigEntry<float> configProbeScanRangeMultiplier;

		//public static ConfigEntry<int> configExtraCrossSectorTransporters;
		//public static ConfigEntry<float> configCrossSectorTransporterSpeedMultiplier;

		public void ReadGModConfigs()
		{
			// GAME
			configCanSkipChapter = Config.Bind("GAME",
				"can_skip_chapter",
				false,
				"allow VOHLE jump dispite the storyline progress during Chapter 0-4 (may cause unpredictable results)");
			// TIQQUN AND SECTORS
			configForceAddingWorkersTill = Config.Bind("TIQQUN AND SECTORS",
				"force_adding_workers_till",
				0,
				"force adding crews as workers till total workers hit this amount; 0 will disable this tweak");
			configMaxNonWorkers = Config.Bind("TIQQUN AND SECTORS",
				"max_non_workers",
				10000,
				"maximum of non-worker crews, after which all crews will be added as workers; a vary large value will disable this tweak");
			configCrewQuarterCapacityMultiplier = Config.Bind("TIQQUN AND SECTORS",
				"crew_quarter_capacity_multiplier",
				1f,
				"multiply capacity of crew quarters by this value, 1 means unchanged");
			configInjuryRecoverySpeedMultiplier = Config.Bind("TIQQUN AND SECTORS",
				"injury_recovery_speed_multiplier",
				1f,
				"multiply crew recovery speed from injury by this value, 1 means unchanged");
			configSectorSpecBoostThreshold = Config.Bind("TIQQUN AND SECTORS",
				"sector_specialization_boost_threshold",
				2000,
				"boost sector specialization progress to maximum (T2) after surpassing this threshold;\nspecifically, 0 mean a single building will result in T2 of that category, and a value high enough (e.g. 2000) will disable this tweak;\nmore readings regarding the game's original settings: https://steamcommunity.com/sharedfiles/filedetails/?id=2900017241");
			configHullDegradationSpeedMultiplier = Config.Bind("TIQQUN AND SECTORS",
				"hull_degradation_speed_multiplier",
				1.0f,
				"multiply hull degradation speed by this value, 1 means unchanged");
			configLockHullIntegrity = Config.Bind("TIQQUN AND SECTORS",
				"lock_hull_integrity",
				false,
				"lock hull at the maximum integrity, overriding hull degradation speed tweak");
			configLockTrust = Config.Bind("TIQQUN AND SECTORS",
				"lock_trust",
				false,
				"lock trust at full");
			configNoAccidents = Config.Bind("TIQQUN AND SECTORS",
				"no_accidents",
				false,
				"completely disable accidents at all working conditions");
			configNoPolicyCooldown = Config.Bind("TIQQUN AND SECTORS",
				"no_policy_cooldown",
				false,
				"remove cooldown between setting DLS policies");
			configNoDestabilizingPolicy = Config.Bind("TIQQUN AND SECTORS",
				"no_destabilizing_policy",
				false,
				"remove negative stability effects from policies");
			configMinStabilityLevel = Config.Bind("TIQQUN AND SECTORS",
				"min_stability_level",
				-100,
				"reset stability to this value when dropping below it; a large negative value will disable this tweak");
			// PRODUCTION
			configStockpileCapacityMultiplier = Config.Bind("PRODUCTION",
				"stockpile_capacity_multiplier",
				1f,
				"multiply Stockpile capacity by this value, 1 means unchanged");
			configDockingBayCapacityMultiplier = Config.Bind("PRODUCTION",
				"docking_bay_capacity_multiplier",
				1f,
				"multiply Docking Bay capacity by this value, 1 means unchanged");
			configWorkshopBuildingSpeedMultiplier = Config.Bind("PRODUCTION",
				"workshop_building_speed_multiplier",
				1f,
				"multiply building speed of Workshop by this value, 1 means unchanged");
			configEVAAirlockBuildingSpeedMultiplier = Config.Bind("PRODUCTION",
				"eva_airlock_building_speed_multiplier",
				1f,
				"multiply building speed of EVA Airlock by this value, 1 means unchanged");
			configProbeAndShipBuildingSpeedMultiplier = Config.Bind("PRODUCTION",
				"probe_and_ship_building_speed_multiplier",
				1f,
				"multiply building speed of Probe Launcher and Docking Bay by this value, 1 means unchanged");
			configFactoryProductionSpeedMultiplier = Config.Bind("PRODUCTION",
				"factory_production_speed_multiplier",
				1f,
				"multiply factory production speed by this value, 1 means unchanged");
			configUnlimitedInSectorTransporters = Config.Bind("PRODUCTION",
				"unlimited_in_sector_transporters",
				false,
				"remove number limit of in-sector transporters");
			configUnlimitedInterSectorTransporters = Config.Bind("PRODUCTION",
				"unlimited_inter_sector_transporters",
				false,
				"remove number of inter-sector transporters (hard-coded by game as 5)");
			configTransporterMovementSpeedMultiplier = Config.Bind("PRODUCTION",
				"transporter_movement_speed_multiplier",
				1f,
				"multiply Stockpile transporter/Workshop builder movement speed by this value, 1 means unchanged");
			configPerpectualNuclearPowerPlant = Config.Bind("PRODUCTION",
				"perpectual_nuclear_power_plant",
				false,
				"Nuclear Power Plants no longer require hydrogen to activate or stay on; it will keep consuming hydrogen if provided");
			configNoRefundOnBuildingDestory = Config.Bind("PRODUCTION",
				"no_refund_on_building_destory",
				false,
				"free-destroy building without resource refund (when you want to get rid of some buildings but Stockpiles are full)");
			// RESEARCH
			configResearchSpeedMultiplier = Config.Bind("RESEARCH",
				"research_speed_multiplier",
				1f,
				"multiply research speed by this value, 1 means unchanged");
			configNoResearchPrerequisites = Config.Bind("RESEARCH",
				"no_research_prerequisites",
				false,
				"remove all prerequisites from researching techs and upgrades");
			// SPACE AND RESOURCES
			configShipStormImmunity = Config.Bind("SPACE AND RESOURCES",
				"ship_storm_immunity",
				false,
				"space vehicles immune to space weather/storms (Tiqqun & colonies are under testing)");
			configResourceExtractSpeedMultiplier = Config.Bind("SPACE AND RESOURCES",
				"resource_extract_speed_multiplier",
				1f,
				"multiply resource extract of mining ship and science ship by this value, 1 means unchanged");
			configTechLabScienceAccuralMultiplier = Config.Bind("SPACE AND RESOURCES",
				"tech_lab_science_accural_multiplier",
				1f,
				"multiply science accrual from Tech Lab by this value, 1 means unchanged");
			configPOIScienceCurateMultiplier = Config.Bind("SPACE AND RESOURCES",
				"poi_science_curate_multiplier",
				1f,
				"multiply science accrual from exploring objectives by this value, 1 means unchanged");
			configInfShipAutonomy = Config.Bind("SPACE AND RESOURCES",
				"inf_ship_autonomy",
				false,
				"space vehicles will never return to Tiqqun for maintenance");
			configTiqqunTopMovementSpeedMultiplier = Config.Bind("SPACE AND RESOURCES",
				"tiqqun_movement_speed_multiplier",
				1f,
				"multiply Tiqqun top movement speed by this value, 1 means unchanged;\nnote that due to acceleration/deceleration, the actual travel time reduction will not be as significant");
			configShipMovementSpeedMultiplier = Config.Bind("SPACE AND RESOURCES",
				"ship_movement_speed_multiplier",
				1f,
				"multiply space vehicle movement speed by this value, 1 means unchanged");
			configShipExpGainMultiplier = Config.Bind("SPACE AND RESOURCES",
				"ship_exp_gain_multiplier",
				1f,
				"multiply exp gain by cargo/mining/science ship by this value, 1 means unchanged");
			configProbeScanRangeMultiplier = Config.Bind("SPACE AND RESOURCES",
				"probe_scan_range_multiplier",
				1f,
				"multiply Probe scan range by this value, 1 means unchanged");
		}

		public override void Load()
		{
			Plugin.Log = base.Log;
			Log.LogInfo("GMod loaded.");

			ReadGModConfigs();

			var harmony = new Harmony("ixion-gmod.harmony");
			harmony.PatchAll();

			Log.LogInfo("GMod patched.");

			foreach (var patchedMethod in harmony.GetPatchedMethods())
			{
				Log.LogInfo($"Patched: {patchedMethod.DeclaringType?.FullName}:{patchedMethod}");
			}
		}
	}
}
