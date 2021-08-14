using HarmonyLib;
using RimWorld;
using SettingsHelper;
using System;
using UnityEngine;
using Verse;

namespace Adjustable_Ability_Cooldowns
{
    public class Adjustable_Ability_Cooldowns_Settings : ModSettings
    {
        public float ritualPenalty = 95;
        public float ritualCooldown = 20;

        //Leader
        public float abilityTrial = 10;
        public float abilityWorkDrive = 10;
        public float abilityCombatCommand = 10;

        //Moral Guide
        public float abilityConvert = 8;
        public float abilityPreachHealth = 8;
        public float abilityReassure = 8;
        public float abilityCounsel = 8;

        //Animal Specialist
        public float abilityAnimalCalm = 20;

        //Medical Specialist
        public float abilityImmunityDrive = 3;

        //Melee Specialist
        public float abilityBerserkTrance = 3;

        //Mining Specialist
        public float abilityMiningCommand = 3;

        //Plants Specialist
        public float abilityFarmingCommand = 3;

        //Production Specialist
        public float abilityProductionCommand = 3;

        //Research Specialist
        public float abilityResearchCommand = 3;

        //Shooting Specialist
        public float abilityMarksmanCommand = 3;

        public override void ExposeData()
        {
            //Ritual penalty
            Scribe_Values.Look(ref ritualPenalty, "ritualPenalty", 95);
            Scribe_Values.Look(ref ritualCooldown, "ritualCooldown", 20);

            //Leader abilities
            Scribe_Values.Look(ref abilityTrial, "abilityTrial", 10);
            Scribe_Values.Look(ref abilityWorkDrive, "abilityWorkDrive", 10);
            Scribe_Values.Look(ref abilityCombatCommand, "abilityCombatCommand", 10);

            //Moral Guide abilities
            Scribe_Values.Look(ref abilityConvert, "abilityConvert", 8);
            Scribe_Values.Look(ref abilityPreachHealth, "abilityPreachHealth", 8);
            Scribe_Values.Look(ref abilityReassure, "abilityReassure", 8);
            Scribe_Values.Look(ref abilityCounsel, "abilityCounsel", 8);

            //Specialist abilities
            Scribe_Values.Look(ref abilityAnimalCalm, "abilityAnimalCalm", 20);
            Scribe_Values.Look(ref abilityImmunityDrive, "abilityImmunityDrive", 3);
            Scribe_Values.Look(ref abilityBerserkTrance, "abilityBerserkTrance", 3);
            Scribe_Values.Look(ref abilityMiningCommand, "abilityMiningCommand", 3);
            Scribe_Values.Look(ref abilityFarmingCommand, "abilityFarmingCommand", 3);
            Scribe_Values.Look(ref abilityProductionCommand, "abilityProductionCommand", 3);
            Scribe_Values.Look(ref abilityResearchCommand, "abilityResearchCommand", 3);
            Scribe_Values.Look(ref abilityMarksmanCommand, "abilityMarksmanCommand", 3);


            base.ExposeData();
        }

    }

    public class Adjustable_Ability_Cooldowns : Mod
    {
        public static Adjustable_Ability_Cooldowns_Settings settings;
        private Vector2 scrollPosition;
        private static float totalContentHeight = 780f;
        private const float scrollBarWidthMargin = 18f;

        public Adjustable_Ability_Cooldowns(ModContentPack content) : base(content)
        {
            settings = GetSettings<Adjustable_Ability_Cooldowns_Settings>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Rect rectWeCanSee = inRect.ContractedBy(10f);
            rectWeCanSee.height -= 50f; // "close" button
            bool scrollBarVisible = totalContentHeight > rectWeCanSee.height;
            Rect rectThatHasEverything = new Rect(0f, 0f, rectWeCanSee.width - (scrollBarVisible ? scrollBarWidthMargin : 0), totalContentHeight);

            Widgets.BeginScrollView(rectWeCanSee, ref scrollPosition, rectThatHasEverything);
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(rectThatHasEverything);

            //ritual penalty
            listingStandard.Label("\nRitual");
            listingStandard.AddLabeledSlider("Percentage for the Ritual Penalty (" + settings.ritualPenalty + ") %", ref settings.ritualPenalty, 0, 100, "0", "100", 1f);
            listingStandard.AddLabeledSlider("Cooldown for the Rituals (" + settings.ritualCooldown + ") %", ref settings.ritualCooldown, 0, 20, "0", "20", 1f);
            //Abilities
            listingStandard.AddHorizontalLine();
            //Leader abilities
            listingStandard.Label("\nLeader abilities");
            listingStandard.AddLabeledSlider("Cooldown for the ability: Trial (" + settings.abilityTrial + ") Days", ref settings.abilityTrial, 0, 20, "0", "20", 1);
            listingStandard.AddLabeledSlider("Cooldown for the ability: WorkDrive (" + settings.abilityWorkDrive + ") Days", ref settings.abilityWorkDrive, 0, 20, "0", "20", 1);
            listingStandard.AddLabeledSlider("Cooldown for the ability: CombatCommand (" + settings.abilityCombatCommand + ") Days", ref settings.abilityCombatCommand, 0, 20, "0", "20", 1);
            listingStandard.AddHorizontalLine();
            //Moral Guide abilities
            listingStandard.Label("\nMoral Guide abilities");
            listingStandard.AddLabeledSlider("Cooldown for the ability: Convert (" + settings.abilityConvert + ") Days", ref settings.abilityConvert, 0, 20, "0", "20", 1);
            listingStandard.AddLabeledSlider("Cooldown for the ability: PreachHealth (" + settings.abilityPreachHealth + ") Days", ref settings.abilityPreachHealth, 0, 20, "0", "20", 1);
            listingStandard.AddLabeledSlider("Cooldown for the ability: Reassure (" + settings.abilityReassure + ") Days", ref settings.abilityReassure, 0, 20, "0", "20", 1);
            listingStandard.AddLabeledSlider("Cooldown for the ability: Counsel (" + settings.abilityCounsel + ") Days", ref settings.abilityCounsel, 0, 20, "0", "20", 1);
            listingStandard.AddHorizontalLine();
            //Specialist abilities
            listingStandard.Label("\nSpecialist abilities");
            listingStandard.AddLabeledSlider("Cooldown for the ability: AnimalCalm (" + settings.abilityAnimalCalm + ") Days", ref settings.abilityAnimalCalm, 0, 20, "0", "20", 1);
            listingStandard.AddLabeledSlider("Cooldown for the ability: ImmunityDrive (" + settings.abilityImmunityDrive + ") Days", ref settings.abilityImmunityDrive, 0, 20, "0", "20", 1);
            listingStandard.AddLabeledSlider("Cooldown for the ability: BerserkTrance (" + settings.abilityBerserkTrance + ") Days", ref settings.abilityBerserkTrance, 0, 20, "0", "20", 1);
            listingStandard.AddLabeledSlider("Cooldown for the ability: MiningCommand (" + settings.abilityMiningCommand + ") Days", ref settings.abilityMiningCommand, 0, 20, "0", "20", 1);
            listingStandard.AddLabeledSlider("Cooldown for the ability: FarmingCommand (" + settings.abilityFarmingCommand + ") Days", ref settings.abilityFarmingCommand, 0, 20, "0", "20", 1);
            listingStandard.AddLabeledSlider("Cooldown for the ability: ProductionCommand (" + settings.abilityProductionCommand + ") Days", ref settings.abilityProductionCommand, 0, 20, "0", "20", 1);
            listingStandard.AddLabeledSlider("Cooldown for the ability: ResearchCommand (" + settings.abilityResearchCommand + ") Days", ref settings.abilityResearchCommand, 0, 20, "0", "20", 1);
            listingStandard.AddLabeledSlider("Cooldown for the ability: MarksmanCommand (" + settings.abilityMarksmanCommand + ") Days", ref settings.abilityMarksmanCommand, 0, 20, "0", "20", 1);
            listingStandard.AddHorizontalLine();

            listingStandard.End();
            Widgets.EndScrollView();


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
            //Leader abilities
            int tickTrial = Convert.ToInt32(settings.abilityTrial * 60000);
            DefDatabase<AbilityDef>.GetNamed("Trial").cooldownTicksRange = new IntRange(tickTrial, tickTrial);
            int tickWorkDrive = Convert.ToInt32(settings.abilityWorkDrive * 60000);
            DefDatabase<AbilityDef>.GetNamed("WorkDrive").cooldownTicksRange = new IntRange(tickWorkDrive, tickWorkDrive);
            int tickCombatCommand = Convert.ToInt32(settings.abilityCombatCommand * 60000);
            DefDatabase<AbilityDef>.GetNamed("CombatCommand").cooldownTicksRange = new IntRange(tickCombatCommand, tickCombatCommand);
            //Moral Guide abilities
            int tickConvert = Convert.ToInt32(settings.abilityConvert * 60000);
            DefDatabase<AbilityDef>.GetNamed("Convert").cooldownTicksRange = new IntRange(tickConvert, tickConvert);
            int tickPreachHealth = Convert.ToInt32(settings.abilityPreachHealth * 60000);
            DefDatabase<AbilityDef>.GetNamed("PreachHealth").cooldownTicksRange = new IntRange(tickPreachHealth, tickPreachHealth);
            int tickReassure = Convert.ToInt32(settings.abilityReassure * 60000);
            DefDatabase<AbilityDef>.GetNamed("Reassure").cooldownTicksRange = new IntRange(tickReassure, tickReassure);
            int tickCounsel = Convert.ToInt32(settings.abilityCounsel * 60000);
            DefDatabase<AbilityDef>.GetNamed("Counsel").cooldownTicksRange = new IntRange(tickCounsel, tickCounsel);
            //Specialist abilities
            int tickAnimalCalm = Convert.ToInt32(settings.abilityAnimalCalm * 60000);
            DefDatabase<AbilityDef>.GetNamed("AnimalCalm").cooldownTicksRange = new IntRange(tickAnimalCalm, tickAnimalCalm);
            int tickImmunityDrive = Convert.ToInt32(settings.abilityImmunityDrive * 60000);
            DefDatabase<AbilityDef>.GetNamed("ImmunityDrive").cooldownTicksRange = new IntRange(tickImmunityDrive, tickImmunityDrive);
            int tickBerserkTrance = Convert.ToInt32(settings.abilityBerserkTrance * 60000);
            DefDatabase<AbilityDef>.GetNamed("BerserkTrance").cooldownTicksRange = new IntRange(tickBerserkTrance, tickBerserkTrance);
            int tickMiningCommand = Convert.ToInt32(settings.abilityMiningCommand * 60000);
            DefDatabase<AbilityDef>.GetNamed("MiningCommand").cooldownTicksRange = new IntRange(tickMiningCommand, tickMiningCommand);
            int tickFarmingCommand = Convert.ToInt32(settings.abilityFarmingCommand * 60000);
            DefDatabase<AbilityDef>.GetNamed("FarmingCommand").cooldownTicksRange = new IntRange(tickFarmingCommand, tickFarmingCommand);
            int tickProductionCommand = Convert.ToInt32(settings.abilityProductionCommand * 60000);
            DefDatabase<AbilityDef>.GetNamed("ProductionCommand").cooldownTicksRange = new IntRange(tickProductionCommand, tickProductionCommand);
            int tickResearchCommand = Convert.ToInt32(settings.abilityResearchCommand * 60000);
            DefDatabase<AbilityDef>.GetNamed("ResearchCommand").cooldownTicksRange = new IntRange(tickResearchCommand, tickResearchCommand);
            int tickMarksmanCommand = Convert.ToInt32(settings.abilityMarksmanCommand * 60000);
            DefDatabase<AbilityDef>.GetNamed("MarksmanCommand").cooldownTicksRange = new IntRange(tickMarksmanCommand, tickMarksmanCommand);
        }

        private static void ResetSettings()
        {

            //Rituals
            settings.ritualPenalty = 95;
            settings.ritualCooldown = 20;

            //Leader abilities
            settings.abilityTrial = 10;
            settings.abilityWorkDrive = 10;
            settings.abilityCombatCommand = 10;
            DefDatabase<AbilityDef>.GetNamed("Trial").cooldownTicksRange = new IntRange(600000, 600000);
            DefDatabase<AbilityDef>.GetNamed("WorkDrive").cooldownTicksRange = new IntRange(600000, 600000);
            DefDatabase<AbilityDef>.GetNamed("CombatCommand").cooldownTicksRange = new IntRange(600000, 600000);

            //Moral Guide abilities
            settings.abilityConvert = 8;
            settings.abilityPreachHealth = 8;
            settings.abilityReassure = 8;
            settings.abilityCounsel = 8;
            DefDatabase<AbilityDef>.GetNamed("Convert").cooldownTicksRange = new IntRange(480000, 480000);
            DefDatabase<AbilityDef>.GetNamed("PreachHealth").cooldownTicksRange = new IntRange(480000, 480000);
            DefDatabase<AbilityDef>.GetNamed("Reassure").cooldownTicksRange = new IntRange(480000, 480000);
            DefDatabase<AbilityDef>.GetNamed("Counsel").cooldownTicksRange = new IntRange(480000, 480000);

            //Specialist abilities
            settings.abilityAnimalCalm = 20;
            settings.abilityImmunityDrive = 3;
            settings.abilityBerserkTrance = 3;
            settings.abilityMiningCommand = 3;
            settings.abilityFarmingCommand = 3;
            settings.abilityProductionCommand = 3;
            settings.abilityResearchCommand = 3;
            settings.abilityMarksmanCommand = 3;
            DefDatabase<AbilityDef>.GetNamed("AnimalCalm").cooldownTicksRange = new IntRange(1200000, 1200000);
            DefDatabase<AbilityDef>.GetNamed("ImmunityDrive").cooldownTicksRange = new IntRange(180000, 180000);
            DefDatabase<AbilityDef>.GetNamed("BerserkTrance").cooldownTicksRange = new IntRange(180000, 180000);
            DefDatabase<AbilityDef>.GetNamed("MiningCommand").cooldownTicksRange = new IntRange(180000, 180000);
            DefDatabase<AbilityDef>.GetNamed("FarmingCommand").cooldownTicksRange = new IntRange(180000, 180000);
            DefDatabase<AbilityDef>.GetNamed("ProductionCommand").cooldownTicksRange = new IntRange(180000, 180000);
            DefDatabase<AbilityDef>.GetNamed("ResearchCommand").cooldownTicksRange = new IntRange(180000, 180000);
            DefDatabase<AbilityDef>.GetNamed("MarksmanCommand").cooldownTicksRange = new IntRange(180000, 180000);
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