using HarmonyLib;
using RimWorld;
using Verse;
using Verse.Sound;

namespace DingOnGameLoaded
{
    [HarmonyPatch(typeof(MainMenuDrawer), "Init")]
    public static class RimWorld_MainMenuDrawer_Init
    {
        private static bool playedOnce;

        [HarmonyPostfix]
        public static void Init()
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