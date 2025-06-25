using HarmonyLib;
using Verse;

namespace DingOnGameLoaded;

[HarmonyPatch(typeof(UIRoot_Entry), nameof(UIRoot_Entry.Init))]
public static class Verse_UIRoot_Entry_Init
{
    /// <summary>
    ///     This is the best place for games with the run in background is turned off.
    ///     It will however trigger the ding early for those who use Better Loading.
    /// </summary>
    public static void Postfix()
    {
        if (Prefs.RunInBackground)
        {
            return;
        }

        if (ModLister.GetActiveModWithIdentifier("me.samboycoding.betterloading", true) != null)
        {
            Log.Message(
                $"[DingOnGameLoaded]: {"DOGL.StartupInfo".Translate()}");
        }

        DingOnGameLoaded.PlayDing();
    }
}