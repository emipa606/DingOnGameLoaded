using HarmonyLib;
using RimWorld;

namespace DingOnGameLoaded
{
    [HarmonyPatch(typeof(MainMenuDrawer), "MainMenuOnGUI")]
    public static class RimWorld_MainMenuDrawer_MainMenuOnGUI
    {
        /// <summary>
        ///     This is the best place for games with the run in background is turned on.
        /// </summary>
        [HarmonyPostfix]
        public static void MainMenuOnGUI()
        {
            //Log.Message("[DingOnGameLoaded]: Last try to play sound");
            DingOnGameLoaded.PlayDing();
        }
    }
}