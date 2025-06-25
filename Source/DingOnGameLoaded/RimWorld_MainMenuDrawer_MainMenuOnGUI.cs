using HarmonyLib;
using RimWorld;

namespace DingOnGameLoaded;

[HarmonyPatch(typeof(MainMenuDrawer), nameof(MainMenuDrawer.MainMenuOnGUI))]
public static class RimWorld_MainMenuDrawer_MainMenuOnGUI
{
    /// <summary>
    ///     This is the best place for games with the run in background is turned on.
    /// </summary>
    public static void Postfix()
    {
        DingOnGameLoaded.PlayDing();
    }
}