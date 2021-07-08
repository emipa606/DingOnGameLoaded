using HarmonyLib;
using Verse;

namespace DingOnGameLoaded
{
    [HarmonyPatch(typeof(UIRoot_Entry), "Init")]
    public static class Verse_UIRoot_Entry_Init
    {
        /// <summary>
        ///     This is the best place for games with the run in background is turned off.
        ///     It will however trigger the ding early for those who use Better Loading.
        /// </summary>
        [HarmonyPostfix]
        public static void Init()
        {
            if (Prefs.RunInBackground)
            {
                return;
            }

            if (ModLister.GetActiveModWithIdentifier("me.samboycoding.betterloading") != null)
            {
                Log.Message(
                    "[DingOnGameLoaded]: Better loading is active and run in background is turned off, sound will be a bit early");
            }

            //Log.Message("[DingOnGameLoaded]: Run in background is turned off");
            DingOnGameLoaded.PlayDing();
        }
    }
}