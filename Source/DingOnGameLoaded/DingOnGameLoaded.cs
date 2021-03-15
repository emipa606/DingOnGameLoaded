using System.Reflection;
using HarmonyLib;
using Verse;

namespace DingOnGameLoaded
{
    internal class DingOnGameLoaded : Mod
    {
        public DingOnGameLoaded(ModContentPack content) : base(content)
        {
            var harmony = new Harmony("Mlie.DingOnGameLoaded");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}