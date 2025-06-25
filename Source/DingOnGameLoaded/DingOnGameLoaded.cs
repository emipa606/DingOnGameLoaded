using System.Reflection;
using HarmonyLib;
using Verse;
using Verse.Sound;

namespace DingOnGameLoaded;

public class DingOnGameLoaded : Mod
{
    public static bool ErrorOccured;

    public static bool WarningOccured;

    private static Harmony harmony;

    public DingOnGameLoaded(ModContentPack content) : base(content)
    {
        harmony = new Harmony("Mlie.DingOnGameLoaded");
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }

    public static void PlayDing()
    {
        var soundName = "DingOnGameLoaded";

        if (ErrorOccured && DingOnGameLoadedMod.Instance.DingOnGameLoadedSettings.StartupErrors)
        {
            soundName = "ErrorOnGameLoaded";
        }
        else if (WarningOccured && DingOnGameLoadedMod.Instance.DingOnGameLoadedSettings.StartupWarnings)
        {
            soundName = "WarningOnGameLoaded";
            Log.TryOpenLogWindow();
        }

        var soundDef = DefDatabase<SoundDef>.GetNamedSilentFail(soundName);
        if (soundDef == null)
        {
            Log.Message("[DingOnGameLoaded]: No sound-file found");
            return;
        }

        soundDef.PlayOneShot(SoundInfo.OnCamera());
        harmony.UnpatchAll("Mlie.DingOnGameLoaded");
    }
}