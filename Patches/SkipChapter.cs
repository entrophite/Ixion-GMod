using System.Reflection;
using BulwarkStudios.Stanford.Games.Chapters;
using HarmonyLib;


[HarmonyPatch]
public class SkipChapter0
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(GameChapter0).GetMethod(nameof(GameChapter0.CanStartVohleJump), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref bool __result)
	{
		__result |= GMod.Plugin.configCanSkipChapter.Value;
	}
}

[HarmonyPatch]
public class SkipChapter1
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(GameChapter1).GetMethod(nameof(GameChapter1.CanStartVohleJump), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref bool __result)
	{
		__result |= GMod.Plugin.configCanSkipChapter.Value;
	}
}

[HarmonyPatch]
public class SkipChapter2
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(GameChapter2).GetMethod(nameof(GameChapter2.CanStartVohleJump), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref bool __result)
	{
		__result |= GMod.Plugin.configCanSkipChapter.Value;
	}
}

[HarmonyPatch]
public class SkipChapter3
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(GameChapter3).GetMethod(nameof(GameChapter3.CanStartVohleJump), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref bool __result)
	{
		__result |= GMod.Plugin.configCanSkipChapter.Value;
	}
}

[HarmonyPatch]
public class SkipChapter4
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(GameChapter4).GetMethod(nameof(GameChapter4.CanStartVohleJump), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref bool __result)
	{
		__result |= GMod.Plugin.configCanSkipChapter.Value;
	}
}
