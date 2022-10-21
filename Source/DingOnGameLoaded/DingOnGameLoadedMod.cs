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
    public static DingOnGameLoadedMod instance;

    private static string currentVersion;

    /// <summary>
    ///     The private dingOnGameLoadedSettings
    /// </summary>
    private DingOnGameLoadedSettings dingOnGameLoadedSettings;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public DingOnGameLoadedMod(ModContentPack content) : base(content)
    {
        instance = this;
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(
                ModLister.GetActiveModWithIdentifier("Mlie.DingOnGameLoaded"));
    }

    /// <summary>
    ///     The instance-dingOnGameLoadedSettings for the mod
    /// </summary>
    internal DingOnGameLoadedSettings DingOnGameLoadedSettings
    {
        get
        {
            if (dingOnGameLoadedSettings == null)
            {
                dingOnGameLoadedSettings = GetSettings<DingOnGameLoadedSettings>();
            }

            return dingOnGameLoadedSettings;
        }
        set => dingOnGameLoadedSettings = value;
    }

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
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.Gap();
        listing_Standard.CheckboxLabeled("DOGL.StartupWarning".Translate(),
            ref DingOnGameLoadedSettings.StartupWarnings,
            "DOGL.StartupWarningInfo".Translate());
        listing_Standard.CheckboxLabeled("DOGL.StartupError".Translate(),
            ref DingOnGameLoadedSettings.StartupErrors, "DOGL.StartupErrorInfo".Translate());
        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("DOGL.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
        DingOnGameLoadedSettings.Write();
    }
}