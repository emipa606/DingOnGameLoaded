using System.Reflection;
using HarmonyLib;
using Verse;
using Verse.Sound;

namespace DingOnGameLoaded
{
    public class DingOnGameLoaded : Mod
    {
        private static bool HavePlayedDing;

        public DingOnGameLoaded(ModContentPack content) : base(content)
        {
            var harmony = new Harmony("Mlie.DingOnGameLoaded");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public static void PlayDing()
        {
            if (HavePlayedDing)
            {
                return;
            }

            var soundDef = DefDatabase<SoundDef>.GetNamedSilentFail("DingOnGameLoaded");
            if (soundDef == null)
            {
                Log.Message("[DingOnGameLoaded]: No sound-file found");
                return;
            }

            //Log.Message("[DingOnGameLoaded]: Playing sound");
            soundDef.PlayOneShot(SoundInfo.OnCamera());
            HavePlayedDing = true;
        }
    }
}