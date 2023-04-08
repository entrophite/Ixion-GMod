using System.Reflection;
using BulwarkStudios.Stanford.Citizens;
using HarmonyLib;

namespace GMod.Patches;

[HarmonyPatch]
public class ForceAddingWorkers
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(ECSCitizenManager).GetMethod(nameof(ECSCitizenManager.AddNewCitizen), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref int sectorIndex, ref int quantity, ref ECSCitizenType.TYPE type, ref bool settler, ref bool isDog)
	{
		if ((ECSCitizenManager.AllWorker.GetCount() < Plugin.configForceAddingWorkersTill.Value) ||
			(ECSCitizenManager.AllSettlerCompatible.GetCount() >= Plugin.configMaxNonWorkers.Value))
			type = ECSCitizenType.TYPE.WORKER;
		return true;
	}
}
