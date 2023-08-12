using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniverseLib;
using UserInterface.MainMenu;

namespace BattleMod;

[BepInPlugin("link.ryhn.battlemod.eacskip", "EAC Skip", "1.0.0.0")]
public class Plugin : BasePlugin
{
	public static Plugin Instance;

	public override void Load()
	{
		Instance = this;
		Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
		var h = new Harmony(MyPluginInfo.PLUGIN_GUID);
		h.PatchAll();
	}
}

[HarmonyPatch(typeof(UserInterface.MainMenu.MainMenu), "Start")]
public class MainMenu_Start
{
	[HarmonyPostfix]
	public static void Postfix(UserInterface.MainMenu.MainMenu __instance)
	{
		__instance.IntroParent.gameObject.active = false;
	}
}

[HarmonyPatch(typeof(UserInterface.MainMenu.MainMenu), "Update")]
public class MainMenu_Update
{
	[HarmonyPostfix]
	public static void Postfix(UserInterface.MainMenu.MainMenu __instance)
	{
		__instance.ConnectingToServerLabel.text = "BattleMod by Ryhon";
		__instance.MenuParent.alpha = 1f;
	}
}