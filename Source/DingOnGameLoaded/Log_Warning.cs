using HarmonyLib;
using Verse;

namespace DingOnGameLoaded;

[HarmonyPatch(typeof(Log), nameof(Log.Warning), typeof(string))]
public static class Log_Warning
{
    /// <summary>
    ///     Warning has happended
    /// </summary>
    [HarmonyPostfix]
    public static void Postfix()
    {
        DingOnGameLoaded.WarningOccured = true;
    }
}