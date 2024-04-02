using HarmonyLib;
using Verse;

namespace DingOnGameLoaded;

[HarmonyPatch(typeof(Log), nameof(Log.Error), typeof(string))]
public static class Log_Error
{
    /// <summary>
    ///     Error has happended
    /// </summary>
    [HarmonyPostfix]
    public static void Postfix()
    {
        DingOnGameLoaded.ErrorOccured = true;
    }
}