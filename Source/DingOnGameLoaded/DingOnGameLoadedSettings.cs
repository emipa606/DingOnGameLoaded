using Verse;

namespace DingOnGameLoaded;

/// <summary>
///     Definition of the dingOnGameLoadedSettings for the mod
/// </summary>
internal class DingOnGameLoadedSettings : ModSettings
{
    public bool StartupErrors;
    public bool StartupWarnings;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref StartupWarnings, "StartupWarnings", true);
        Scribe_Values.Look(ref StartupErrors, "StartupErrors", true);
    }
}