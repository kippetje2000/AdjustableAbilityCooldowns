using RimWorld;
using SettingsHelper;
using System;
using UnityEngine;
using Verse;

namespace Adjustable_Ability_Cooldowns.Utilities
{
    public static class BigSmallGenesMore_Settings
    {
        //60000 ticks = 1 Days
        //60 ticks = 1 Seconds
        //2500 ticks = 1 Hours
        public static float abilityVU_Hermaphromorph = 5; //Seconds
        public static float abilityBS_FoamSpray = 3; //Hours
        public static float abilityBS_StickyAcidSpray = 1; //Hours
        public static float abilityBS_SnekEngulf_New = 20; //Seconds
        public static float abilityVU_Pounce = 2; //Seconds
        public static float abilityBS_ReleaseMiniDeadlifeDust = 2; //Hours
        public static float abilityBS_Incorporate_Abillity = 2; //Days
        public static float abilityBS_Mimic_Abillity = 4; //Hours
        public static float abilityBS_Parasite = 30; //Seconds
        public static void ExposeDataBigSmallGenesMore()
        {
            Scribe_Values.Look(ref abilityVU_Hermaphromorph, "abilityVU_Hermaphromorph");
            Scribe_Values.Look(ref abilityBS_FoamSpray, "abilityBS_FoamSpray");
            Scribe_Values.Look(ref abilityBS_StickyAcidSpray, "abilityBS_StickyAcidSpray");
            Scribe_Values.Look(ref abilityBS_SnekEngulf_New, "abilityBS_SnekEngulf_New");
            Scribe_Values.Look(ref abilityVU_Pounce, "abilityVU_Pounce");
            Scribe_Values.Look(ref abilityBS_ReleaseMiniDeadlifeDust, "abilityBS_ReleaseMiniDeadlifeDust");
            Scribe_Values.Look(ref abilityBS_Incorporate_Abillity, "abilityBS_Incorporate_Abillity");
            Scribe_Values.Look(ref abilityBS_Mimic_Abillity, "abilityBS_Mimic_Abillity");
            Scribe_Values.Look(ref abilityBS_Parasite, "abilityBS_Parasite");
        }
        public static void DrawBigSmallGenesMore(Listing_Standard listing_Standard)
        {
            listing_Standard.Label("Big and Small - Genes & More abilities");
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Hermaphromorph (" + abilityVU_Hermaphromorph + ") Seconds", ref abilityVU_Hermaphromorph, 0, 60, "0", "60", 1f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: FoamSpray (" + abilityBS_FoamSpray + ") Hours", ref abilityBS_FoamSpray, 0, 24, "0", "24", 0.25f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: StickyAcidSpray (" + abilityBS_StickyAcidSpray + ") Hours", ref abilityBS_StickyAcidSpray, 0, 24, "0", "24", 0.25f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Engulf (" + abilityBS_SnekEngulf_New + ") Seconds", ref abilityBS_SnekEngulf_New, 0, 60, "0", "60", 1f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Pounce (" + abilityVU_Pounce + ") Seconds", ref abilityVU_Pounce, 0, 60, "0", "60", 1f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: ReleaseMiniDeadlifeDust (" + abilityBS_ReleaseMiniDeadlifeDust + ") Hours", ref abilityBS_ReleaseMiniDeadlifeDust, 0, 24, "0", "24", 0.25f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Incorporate (" + abilityBS_Incorporate_Abillity + ") Days", ref abilityBS_Incorporate_Abillity, 0, 15, "0", "15", 0.25f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Mimic (" + abilityBS_Mimic_Abillity + ") Hours", ref abilityBS_Mimic_Abillity, 0, 24, "0", "24", 0.25f);
            listing_Standard.AddLabeledSlider("Cooldown for the ability: Parasite (" + abilityBS_Parasite + ") Seconds", ref abilityBS_Parasite, 0, 60, "0", "60", 1f);
            listing_Standard.AddHorizontalLine();

            listing_Standard.Gap(10);

            //Save settings
            GUI.color = Color.green;
            if (listing_Standard.ButtonText("Apply Big and Small - Genes & More Settings"))
            {
                ApplySettingBigSmallGenesMore();
                Messages.Message("Applied Big and Small - Genes & More Settings", MessageTypeDefOf.NeutralEvent);

            }
            //Reset settings
            GUI.color = Color.red;
            if (listing_Standard.ButtonText("Reset Big and Small - Genes & More Settings"))
            {
                ResetSettingsBigSmallGenesMore();
                Messages.Message("Reset Big and Small - Genes & More Settings", MessageTypeDefOf.NeutralEvent);

            }
            listing_Standard.Gap(10);

        }
        public static void ApplySettingBigSmallGenesMore()
        {
            int tickabilityVU_Hermaphromorph = Convert.ToInt32(abilityVU_Hermaphromorph * 60 + 1);
            DefDatabase<AbilityDef>.GetNamed("VU_Hermaphromorph").cooldownTicksRange = new IntRange(tickabilityVU_Hermaphromorph, tickabilityVU_Hermaphromorph);
            int tickabilityBS_FoamSpray = Convert.ToInt32(abilityBS_FoamSpray * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("BS_FoamSpray").cooldownTicksRange = new IntRange(tickabilityBS_FoamSpray, tickabilityBS_FoamSpray);
            int tickabilityBS_StickyAcidSpray = Convert.ToInt32(abilityBS_StickyAcidSpray * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("BS_StickyAcidSpray").cooldownTicksRange = new IntRange(tickabilityBS_StickyAcidSpray, tickabilityBS_StickyAcidSpray);
            int tickabilityBS_SnekEngulf_New = Convert.ToInt32(abilityBS_SnekEngulf_New * 60 + 1);
            DefDatabase<AbilityDef>.GetNamed("BS_SnekEngulf_New").cooldownTicksRange = new IntRange(tickabilityBS_SnekEngulf_New, tickabilityBS_SnekEngulf_New);
            int tickabilityVU_Pounce = Convert.ToInt32(abilityVU_Pounce * 60 + 1);
            DefDatabase<AbilityDef>.GetNamed("VU_Pounce").cooldownTicksRange = new IntRange(tickabilityVU_Pounce, tickabilityVU_Pounce);
            int tickabilityBS_ReleaseMiniDeadlifeDust = Convert.ToInt32(abilityBS_ReleaseMiniDeadlifeDust * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("BS_ReleaseMiniDeadlifeDust").cooldownTicksRange = new IntRange(tickabilityBS_ReleaseMiniDeadlifeDust, tickabilityBS_ReleaseMiniDeadlifeDust);
            int tickabilityBS_Incorporate_Abillity = Convert.ToInt32(abilityBS_Incorporate_Abillity * 60000 + 1);
            DefDatabase<AbilityDef>.GetNamed("BS_Incorporate_Abillity").cooldownTicksRange = new IntRange(tickabilityBS_Incorporate_Abillity, tickabilityBS_Incorporate_Abillity);
            int tickabilityBS_Mimic_Abillity = Convert.ToInt32(abilityBS_Mimic_Abillity * 2500 + 1);
            DefDatabase<AbilityDef>.GetNamed("BS_Mimic_Abillity").cooldownTicksRange = new IntRange(tickabilityBS_Mimic_Abillity, tickabilityBS_Mimic_Abillity);
            int tickabilityBS_Parasite = Convert.ToInt32(abilityBS_Parasite * 60 + 1);
            DefDatabase<AbilityDef>.GetNamed("BS_Parasite").cooldownTicksRange = new IntRange(tickabilityBS_Parasite, tickabilityBS_Parasite);
        }
        public static void ResetSettingsBigSmallGenesMore()
        {
            abilityVU_Hermaphromorph = 5; //Seconds
            abilityBS_FoamSpray = 3; //Hours
            abilityBS_StickyAcidSpray = 1; //Hours
            abilityBS_SnekEngulf_New = 20; //Seconds
            abilityVU_Pounce = 2; //Seconds
            abilityBS_ReleaseMiniDeadlifeDust = 2; //Hours
            abilityBS_Incorporate_Abillity = 2; //Days
            abilityBS_Mimic_Abillity = 4; //Hours
            abilityBS_Parasite = 30; //Seconds

            ApplySettingBigSmallGenesMore();
        }
    }
}
