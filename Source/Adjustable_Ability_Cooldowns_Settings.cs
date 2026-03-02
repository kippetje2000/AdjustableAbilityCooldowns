using Adjustable_Ability_Cooldowns.Utilities;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace Adjustable_Ability_Cooldowns
{
    public class Adjustable_Ability_Cooldowns_Settings : ModSettings
    {
        //Add DLC and Mods here
        public override void ExposeData()
        {
            Ideology_Setting.ExposeData();
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.biotech") != null)
            {
                Biotech_Setting.ExposeData();
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.anomaly") != null)
            {
                Anomaly_Settings.ExposeData();
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.odyssey") != null)
            {
                Odyssey_Settings.ExposeData();
            }
            if (ModLister.GetActiveModWithIdentifier("sarg.alphagenes") != null)
            {
                AlphaGene_Settings.ExposeData();
            }
            if (ModLister.GetActiveModWithIdentifier("oskarpotocki.vfe.tribals") != null)
            {
                VFETribals_Settings.ExposeData();
            }
            if (ModLister.GetActiveModWithIdentifier("vanillaexpanded.vmemese") != null)
            {
                VME_Settings.ExposeData();
            }
            if (ModLister.GetActiveModWithIdentifier("redmattis.bigsmall.core") != null)
            {
                BigSmallGenesMore_Settings.ExposeData();
            }
            base.ExposeData();
        }
    }

    public class Adjustable_Ability_Cooldowns : Mod
    {
        public static Adjustable_Ability_Cooldowns_Settings settings;
        private Vector2 scrollPosition = new Vector2(0f, 0f);
        public float scrollViewHeight;

        //Add DLC and Mods here
        //DLC
        public static bool SectionIdeology = false;
        public static bool SectionBiotech = false;
        public static bool SectionAnomaly = false;
        public static bool SectionOdyssey = false;
        //Mods
        public static bool SectionAlphaGenes = false;
        public static bool SectionVFETribals = false;
        public static bool SectionVME = false;
        public static bool SectionBigSmallGenesMore = false;

        public Adjustable_Ability_Cooldowns(ModContentPack content) : base(content)
        {
            settings = GetSettings<Adjustable_Ability_Cooldowns_Settings>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            GUI.BeginGroup(inRect);
            Listing_Standard options = new Listing_Standard();
            Rect viewRect = new Rect(0f, 0f, inRect.width - 16f, scrollViewHeight + 50f);

            options.BeginScrollViewEx(inRect, ref scrollPosition, viewRect);

            //Add DLC and Mods here
            //DLC
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.ideology") != null)
            {
                if (SectionIdeology)
                    GUI.color = Color.gray;
                else
                    GUI.color = Color.white;

                if (options.ButtonText("Ideology"))
                {
                    SectionIdeology = !SectionIdeology;
                }
                GUI.color = Color.white;

                if (SectionIdeology)
                {
                    Ideology_Setting.Draw(options);
                }
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.biotech") != null)
            {
                if (SectionBiotech)
                    GUI.color = Color.gray;
                else
                    GUI.color = Color.white;
                if (options.ButtonText("Biotech"))
                {
                    SectionBiotech = !SectionBiotech;
                }
                GUI.color = Color.white;

                if (SectionBiotech)
                {
                    Biotech_Setting.Draw(options);
                }
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.anomaly") != null)
            {
                if (SectionAnomaly)
                    GUI.color = Color.gray;
                else
                    GUI.color = Color.white;
                if (options.ButtonText("Anomaly"))
                {
                    SectionAnomaly = !SectionAnomaly;
                }
                GUI.color = Color.white;

                if (SectionAnomaly)
                {
                    Anomaly_Settings.Draw(options);
                }
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.odyssey") != null)
            {
                if (SectionOdyssey)
                    GUI.color = Color.gray;
                else
                    GUI.color = Color.white;
                if (options.ButtonText("Odyssey"))
                {
                    SectionOdyssey = !SectionOdyssey;
                }
                GUI.color = Color.white;

                if (SectionOdyssey)
                {
                    Odyssey_Settings.Draw(options);
                }
            }
            //Mods
            if (ModLister.GetActiveModWithIdentifier("sarg.alphagenes") != null)
            {
                if (SectionAlphaGenes)
                    GUI.color = Color.gray;
                else
                    GUI.color = Color.white;
                if (options.ButtonText("AlphaGenes"))
                {
                    SectionAlphaGenes = !SectionAlphaGenes;
                }
                GUI.color = Color.white;

                if (SectionAlphaGenes)
                {
                    AlphaGene_Settings.Draw(options);
                }
            }
            if (ModLister.GetActiveModWithIdentifier("oskarpotocki.vfe.tribals") != null)
            {
                if (SectionVFETribals)
                    GUI.color = Color.gray;
                else
                    GUI.color = Color.white;
                if (options.ButtonText("Vanilla Factions Expanded - Tribals"))
                {
                    SectionVFETribals = !SectionVFETribals;
                }
                GUI.color = Color.white;

                if (SectionVFETribals)
                {
                    VFETribals_Settings.Draw(options);
                }
            }
            if (ModLister.GetActiveModWithIdentifier("vanillaexpanded.vmemese") != null)
            {
                if (SectionVME)
                    GUI.color = Color.gray;
                else
                    GUI.color = Color.white;
                if (options.ButtonText("Vanilla Ideology Expanded - Memes and Structures"))
                {
                    SectionVME = !SectionVME;
                }
                GUI.color = Color.white;

                if (SectionVME)
                {
                    VME_Settings.Draw(options);
                }
            }
            if (ModLister.GetActiveModWithIdentifier("redmattis.bigsmall.core") != null)
            {
                if (SectionBigSmallGenesMore)
                    GUI.color = Color.gray;
                else
                    GUI.color = Color.white;
                if (options.ButtonText("Big and Small - Genes & More"))
                {
                    SectionBigSmallGenesMore = !SectionBigSmallGenesMore;
                }
                GUI.color = Color.white;

                if (SectionBigSmallGenesMore)
                {
                    BigSmallGenesMore_Settings.Draw(options);
                }
            }

            options.EndScrollView(ref viewRect);
            scrollViewHeight = viewRect.height;
            GUI.EndGroup();

            //Save settings
            GUI.color = Color.green;
            if (Widgets.ButtonText(inRect.BottomPart(0.1f).LeftPart(0.1f), "Apply All Settings", true, true, true))
            {
                Adjustable_Ability_Cooldowns.ApplySettings();
                Messages.Message("Applied all settings", MessageTypeDefOf.NeutralEvent);

            }
            //Reset settings
            GUI.color = Color.red;
            if (Widgets.ButtonText(inRect.BottomPart(0.1f).RightPart(0.1f), "Reset All Settings", true, true, true))
            {
                Adjustable_Ability_Cooldowns.ResetSettings();
                Messages.Message("Reset all settings", MessageTypeDefOf.NeutralEvent);
            }
            GUI.color = Color.white;

        }

        private static void ApplySettings()
        {
            //Add DLC and Mods here
            Ideology_Setting.ApplySettings();
            //DLC
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.biotech") != null)
            {
                Biotech_Setting.ApplySettings();
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.anomaly") != null)
            {
                Anomaly_Settings.ApplySettings();
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.odyssey") != null)
            {
                Odyssey_Settings.ApplySettings();
            }

            //Mods
            if (ModLister.GetActiveModWithIdentifier("sarg.alphagenes") != null)
            {
                AlphaGene_Settings.ApplySettings();
            }
            if (ModLister.GetActiveModWithIdentifier("oskarpotocki.vfe.tribals") != null)
            {
                VFETribals_Settings.ApplySettings();
            }
            if (ModLister.GetActiveModWithIdentifier("vanillaexpanded.vmemese") != null)
            {
                VME_Settings.ApplySettings();
            }
            if (ModLister.GetActiveModWithIdentifier("redmattis.bigsmall.core") != null)
            {
                BigSmallGenesMore_Settings.ApplySettings();
            }
        }

        private static void ResetSettings()
        {
            //Add DLC and Mods here
            Ideology_Setting.ResetSettings();
            //DLC
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.biotech") != null)
            {
                Biotech_Setting.ResetSettings();
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.anomaly") != null)
            {
                Anomaly_Settings.ResetSettings();
            }
            if (ModLister.GetActiveModWithIdentifier("ludeon.rimworld.odyssey") != null)
            {
                Odyssey_Settings.ResetSettings();
            }

            //Mods
            if (ModLister.GetActiveModWithIdentifier("sarg.alphagenes") != null)
            {
                AlphaGene_Settings.ResetSettings();
            }
            if (ModLister.GetActiveModWithIdentifier("oskarpotocki.vfe.tribals") != null)
            {
                VFETribals_Settings.ResetSettings();
            }
            if (ModLister.GetActiveModWithIdentifier("vanillaexpanded.vmemese") != null)
            {
                VME_Settings.ResetSettings();
            }
            if (ModLister.GetActiveModWithIdentifier("redmattis.bigsmall.core") != null)
            {
                BigSmallGenesMore_Settings.ResetSettings();
            }
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