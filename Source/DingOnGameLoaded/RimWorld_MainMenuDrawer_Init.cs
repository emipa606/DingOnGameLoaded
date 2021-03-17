using HarmonyLib;
using RimWorld;
using Verse;
using Verse.Sound;

namespace DingOnGameLoaded
{
    [HarmonyPatch(typeof(MainMenuDrawer), "MainMenuOnGUI")]
    public static class RimWorld_MainMenuDrawer_MainMenuOnGUI
    {
        private static bool playedOnce;

        [HarmonyPostfix]
        public static void MainMenuOnGUI()
        {
            if (playedOnce)
            {
                return;
            }

            playedOnce = true;
            var soundDef = DefDatabase<SoundDef>.GetNamedSilentFail("DingOnGameLoaded");
            if (soundDef == null)
            {
                Log.Message("[DingOnGameLoaded]: No sound-file found");
                return;
            }

            soundDef.PlayOneShot(SoundInfo.OnCamera());
        }
    }
}