using Adjustable_Ability_Cooldowns.Utilities;
using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace Adjustable_Ability_Cooldowns
{
    public class Adjustable_Ability_Cooldowns_Settings : ModSettings
    {
        public override void ExposeData()
        {
            Ideology_Setting.ExposeDataIdeology();
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.biotech") != null)
            {
                Biotech_Setting.ExposeDataBiotech();
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.anomaly") != null)
            {
                Anomaly_Settings.ExposeDataAnomaly();
            }
            if (ModLister.GetActiveModWithIdentifier("sarg.alphagenes") != null)
            {
                AlphaGene_Settings.ExposeDataAlphaGenes();
            }
            if (ModLister.GetActiveModWithIdentifier("oskarpotocki.vfe.tribals") != null)
            {
                VFETribals_Settings.ExposeDataVFETribals();
            }
            if (ModLister.GetActiveModWithIdentifier("vanillaexpanded.vmemese") != null)
            {
                VME_Settings.ExposeDataVME();
            }
            base.ExposeData();
        }
    }

    public class Adjustable_Ability_Cooldowns : Mod
    {
        public static Adjustable_Ability_Cooldowns_Settings settings;
        private Vector2 scrollPosition = new Vector2(0f, 0f);
        public float scrollViewHeight;
        public static Tab selectedTab = Tab.ideology;
        public enum Tab { ideology, biotech, anomaly, alphagenes, vfe };

        public Adjustable_Ability_Cooldowns(ModContentPack content) : base(content)
        {
            settings = GetSettings<Adjustable_Ability_Cooldowns_Settings>();

        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            List<TabRecord> tabs = new List<TabRecord>
            {
                new TabRecord("Ideology", delegate { selectedTab = Tab.ideology; }, selectedTab == Tab.ideology)
            };
            //DLCs and Mods tabs
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.biotech") != null)
            {
                tabs.Add(new TabRecord("Biotech", delegate { selectedTab = Tab.biotech; }, selectedTab == Tab.biotech));
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.anomaly") != null)
            {
                tabs.Add(new TabRecord("Anomaly", delegate { selectedTab = Tab.anomaly; }, selectedTab == Tab.anomaly));
            }
            if (ModLister.GetActiveModWithIdentifier("sarg.alphagenes") != null)
            {
                tabs.Add(new TabRecord("AlphaGenes", delegate { selectedTab = Tab.alphagenes; }, selectedTab == Tab.alphagenes));
            }
            if (ModLister.GetActiveModWithIdentifier("oskarpotocki.vanillafactionsexpanded.core") != null)
            {
                tabs.Add(new TabRecord("VFE", delegate { selectedTab = Tab.vfe; }, selectedTab == Tab.vfe));
            }

            GUI.BeginGroup(inRect);
            Listing_Standard options = new Listing_Standard();
            Rect viewRect = new Rect(0f, 0f, inRect.width - 16f, scrollViewHeight + 50f);

            TabDrawer.DrawTabs(new Rect(0f, 32f, viewRect.width, Text.LineHeight), tabs);
            options.BeginScrollViewEx(inRect, ref scrollPosition, viewRect);

            if (selectedTab == Tab.biotech)
            {
                Biotech_Setting.DrawBiotech(options);
            }
            else if (selectedTab == Tab.anomaly)
            {
                Anomaly_Settings.DrawAnomaly(options);
            }
            else if (selectedTab == Tab.alphagenes)
            {
                AlphaGene_Settings.DrawAlphaGenes(options);
            }
            else if (selectedTab == Tab.vfe)
            {
                if (ModLister.GetActiveModWithIdentifier("oskarpotocki.vfe.tribals") != null)
                {
                    VFETribals_Settings.DrawVFETribals(options);

                }
                if (ModLister.GetActiveModWithIdentifier("vanillaexpanded.vmemese") != null)
                {
                    VME_Settings.DrawVME(options);
                }
            }
            else
            {
                Ideology_Setting.DrawIdeology(options);
            }

            options.EndScrollView(ref viewRect);
            scrollViewHeight = viewRect.height;
            GUI.EndGroup();

            //Save settings
            Rect applyButton = inRect.BottomPart(0.1f).LeftPart(0.1f);
            bool apply = Widgets.ButtonText(applyButton, "Apply Settings", true, true, true);
            if (apply)
            {
                Adjustable_Ability_Cooldowns.ApplySettings();
            }
            //Reset settings
            Rect resetButton = inRect.BottomPart(0.1f).RightPart(0.1f);
            bool reset = Widgets.ButtonText(resetButton, "Reset Settings", true, true, true);
            if (reset)
            {
                Adjustable_Ability_Cooldowns.ResetSettings();
            }

            base.DoSettingsWindowContents(inRect);
        }

        private static void ApplySettings()
        {
            Ideology_Setting.ApplySettingIdeology();
            //DLCs and Mods
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.biotech") != null)
            {
                Biotech_Setting.ApplySettingBiotech();
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.anomaly") != null)
            {
                Anomaly_Settings.ApplySettingAnomaly();
            }
            if (ModLister.GetActiveModWithIdentifier("sarg.alphagenes") != null)
            {
                AlphaGene_Settings.ApplySettingAlphaGenes();
            }
            if (ModLister.GetActiveModWithIdentifier("oskarpotocki.vfe.tribals") != null)
            {
                VFETribals_Settings.ApplySettingVFETribals();
            }
            if (ModLister.GetActiveModWithIdentifier("vanillaexpanded.vmemese") != null)
            {
                VME_Settings.ApplySettingVME();
            }
        }

        private static void ResetSettings()
        {
            Ideology_Setting.ResetSettingsIdeology();
            //DLCs and Mods
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.biotech") != null)
            {
                Biotech_Setting.ResetSettingsBiotech();
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.anomaly") != null)
            {
                Anomaly_Settings.ResetSettingsAnomaly();
            }
            if (ModLister.GetActiveModWithIdentifier("sarg.alphagenes") != null)
            {
                AlphaGene_Settings.ResetSettingsAlphaGenes();
            }
            if (ModLister.GetActiveModWithIdentifier("oskarpotocki.vfe.tribals") != null)
            {
                VFETribals_Settings.ResetSettingsVFETribals();
            }
            if (ModLister.GetActiveModWithIdentifier("vanillaexpanded.vmemese") != null)
            {
                VME_Settings.ResetSettingsVME();
            }
            ApplySettings();
        }

        public override string SettingsCategory()
        {
            return "Adjustable_Ability_Cooldowns".Translate();
        }

        [StaticConstructorOnStartup]
        internal static class StartupAdjustable_Ability_Cooldowns
        {
            static StartupAdjustable_Ability_Cooldowns()
            {
                ApplySettings();
                Harmony harmony = new Harmony("KipsMods.AdjustableAbilityCooldowns");
                harmony.PatchAll();
            }
        }
    }

}