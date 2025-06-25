using Mlie;
using UnityEngine;
using Verse;

namespace DingOnGameLoaded;

[StaticConstructorOnStartup]
internal class DingOnGameLoadedMod : Mod
{
    /// <summary>
    ///     The instance of the dingOnGameLoadedSettings to be read by the mod
    /// </summary>
    public static DingOnGameLoadedMod Instance;

    private static string currentVersion;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public DingOnGameLoadedMod(ModContentPack content) : base(content)
    {
        Instance = this;
        DingOnGameLoadedSettings = GetSettings<DingOnGameLoadedSettings>();
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    /// <summary>
    ///     The instance-dingOnGameLoadedSettings for the mod
    /// </summary>
    internal DingOnGameLoadedSettings DingOnGameLoadedSettings { get; }

    /// <summary>
    ///     The title for the mod-dingOnGameLoadedSettings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Ding On Game Loaded";
    }

    /// <summary>
    ///     The dingOnGameLoadedSettings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(rect);
        listingStandard.Gap();
        listingStandard.CheckboxLabeled("DOGL.StartupWarning".Translate(),
            ref DingOnGameLoadedSettings.StartupWarnings,
            "DOGL.StartupWarningInfo".Translate());
        listingStandard.CheckboxLabeled("DOGL.StartupError".Translate(),
            ref DingOnGameLoadedSettings.StartupErrors, "DOGL.StartupErrorInfo".Translate());
        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("DOGL.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }
}