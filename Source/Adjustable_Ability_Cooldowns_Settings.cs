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
        //60000 ticks = 1 day
        //60 ticks = 1 sec
        //2500 ticks = 1 hour

        //Rituals
        public float ritualPenalty = 95; //%
        public float ritualCooldown = 20; //Days

        //Leader
        public float abilityLeaderSpeech = 10; //Days
        public float abilityTrial = 10; //Days
        public float abilityWorkDrive = 10; //Days
        public float abilityCombatCommand = 10; //Days

        //Moral Guide
        public float abilityConvert = 8; //Days
        public float abilityPreachHealth = 8; //Days
        public float abilityReassure = 8; //Days
        public float abilityCounsel = 8; //Days

        //Animal Specialist
        public float abilityAnimalCalm = 20; //Days

        //Medical Specialist
        public float abilityImmunityDrive = 3; //Days

        //Melee Specialist
        public float abilityBerserkTrance = 3; //Days

        //Mining Specialist
        public float abilityMiningCommand = 3; //Days

        //Plants Specialist
        public float abilityFarmingCommand = 3; //Days

        //Production Specialist
        public float abilityProductionCommand = 3; //Days

        //Research Specialist
        public float abilityResearchCommand = 3; //Days

        //Shooting Specialist
        public float abilityMarksmanCommand = 3; //Days

        //Biotech
        public float abilityPiercingSpine = 1; //Seconds
        public float abilityResurrect = 120; //Days
        public float abilityAcidSpray = 12; //Hours
        public float abilityFoamSpray = 12; //Hours
        public float abilityFireSpew = 5; //Days
        public float abilityLongjump = 1; //Seconds
        public float abilityFireBurst = 45; //Seconds
        public float abilityAnimalWarcall = 15; //Days
        public float abilityLongjumpMech = 8; //Seconds
        public float abilityLongjumpMechLauncher = 8; //Hours
        public float abilitySmokepopMech = 15; //Days
        public float abilityFirefoampopMech = 5; //Days
        public float abilityResurrectionMech = 2; //Seconds

        public bool separatedAblilities = false;

        public override void ExposeData()
        {
            //Ritual penalty
            Scribe_Values.Look(ref ritualPenalty, "ritualPenalty", 95);
            Scribe_Values.Look(ref ritualCooldown, "ritualCooldown", 20);

            //Leader abilities
            Scribe_Values.Look(ref abilityLeaderSpeech, "abilityLeaderSpeech", 10);
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

            Scribe_Values.Look(ref separatedAblilities, "separatedAblilities", false);

            if (ModLister.HasActiveModWithName("ludeon.rimworld.biotech") == true)
            {
                //Biotech
                Scribe_Values.Look(ref abilityPiercingSpine, "abilityPiercingSpine", 1);
                Scribe_Values.Look(ref abilityResurrect, "abilityResurrect", 120);
                Scribe_Values.Look(ref abilityAcidSpray, "abilityAcidSpray", 12);
                Scribe_Values.Look(ref abilityFoamSpray, "abilityFoamSpray", 12);
                Scribe_Values.Look(ref abilityFireSpew, "abilityFireSpew", 5);
                Scribe_Values.Look(ref abilityLongjump, "abilityLongjump", 1);
                Scribe_Values.Look(ref abilityFireBurst, "abilityFireBurst", 45);
                Scribe_Values.Look(ref abilityAnimalWarcall, "abilityAnimalWarcall", 15);
                Scribe_Values.Look(ref abilityLongjumpMech, "abilityLongjumpMech", 8);
                Scribe_Values.Look(ref abilityLongjumpMechLauncher, "abilityLongjumpMechLauncher", 8);
                Scribe_Values.Look(ref abilitySmokepopMech, "abilitySmokepopMech", 15);
                Scribe_Values.Look(ref abilityFirefoampopMech, "abilityFirefoampopMech", 5);
                Scribe_Values.Look(ref abilityResurrectionMech, "abilityResurrectionMech", 2);
            }

            base.ExposeData();
        }

    }

    public class Adjustable_Ability_Cooldowns : Mod
    {
        public static Adjustable_Ability_Cooldowns_Settings settings;
        private Vector2 scrollPosition = new Vector2(0f, 0f);
        private static float totalContentHeight = 900f;
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
            listingStandard.AddLabeledSlider("Cooldown for the Rituals (" + settings.ritualCooldown + ") Days", ref settings.ritualCooldown, 0, 20, "0", "20", 1f);
            //Abilities
            listingStandard.AddHorizontalLine();
            //Leader abilities
            listingStandard.Label("\nLeader abilities");
            listingStandard.AddLabeledSlider("Cooldown for the ability: LeaderSpeech (" + settings.abilityLeaderSpeech + ") Days", ref settings.abilityLeaderSpeech, 0, 20, "0", "20", 1);
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
            //More options
            listingStandard.Label("\nMore options");
            listingStandard.AddLabeledCheckbox("Use ablilities separately from each other", ref settings.separatedAblilities);
            if (ModLister.HasActiveModWithName("ludeon.rimworld.biotech") == true)
            {
                //Biotech
                listingStandard.AddHorizontalLine();
                listingStandard.Label("\nBiotech abilities");
                listingStandard.AddLabeledSlider("Cooldown for the ability: PiercingSpine (" + settings.abilityPiercingSpine + ") Seconds", ref settings.abilityPiercingSpine, 0, 60, "0", "60", 1);
                listingStandard.AddLabeledSlider("Cooldown for the ability: Resurrect (" + settings.abilityResurrect + ") Days", ref settings.abilityResurrect, 0, 120, "0", "120", 1);
                listingStandard.AddLabeledSlider("Cooldown for the ability: AcidSpray (" + settings.abilityAcidSpray + ") Hours", ref settings.abilityAcidSpray, 0, 24, "0", "24", 1);
                listingStandard.AddLabeledSlider("Cooldown for the ability: FoamSpray (" + settings.abilityFoamSpray + ") Hours", ref settings.abilityFoamSpray, 0, 24, "0", "24", 1);
                listingStandard.AddLabeledSlider("Cooldown for the ability: FireSpew (" + settings.abilityFireSpew + ") Days", ref settings.abilityFireSpew, 0, 15, "0", "15", 1);
                listingStandard.AddLabeledSlider("Cooldown for the ability: Longjump (" + settings.abilityLongjump + ") Seconds", ref settings.abilityLongjump, 0, 60, "0", "60", 1);
                listingStandard.AddLabeledSlider("Cooldown for the ability: FireBurst (" + settings.abilityFireBurst + ") Seconds", ref settings.abilityFireBurst, 0, 60, "0", "60", 1);
                listingStandard.AddLabeledSlider("Cooldown for the ability: AnimalWarcall (" + settings.abilityAnimalWarcall + ") Days", ref settings.abilityAnimalWarcall, 0, 15, "0", "15", 1);
                listingStandard.AddLabeledSlider("Cooldown for the ability: LongjumpMech (" + settings.abilityLongjumpMech + ") Seconds", ref settings.abilityLongjumpMech, 0, 60, "0", "60", 1);
                listingStandard.AddLabeledSlider("Cooldown for the ability: LongjumpMechLauncher (" + settings.abilityLongjumpMechLauncher + ") Hours", ref settings.abilityLongjumpMechLauncher, 0, 8, "0", "8", 1);
                listingStandard.AddLabeledSlider("Cooldown for the ability: SmokepopMech (" + settings.abilitySmokepopMech + ") Days", ref settings.abilitySmokepopMech, 0, 15, "0", "15", 1);
                listingStandard.AddLabeledSlider("Cooldown for the ability: FirefoampopMech (" + settings.abilityFirefoampopMech + ") Days", ref settings.abilityFirefoampopMech, 0, 15, "0", "15", 1);
                listingStandard.AddLabeledSlider("Cooldown for the ability: ResurrectionMech (" + settings.abilityResurrectionMech + ") Seconds", ref settings.abilityResurrectionMech, 0, 60, "0", "60", 1);
            }

            //listingStandard.AddLabeledNumericalTextField<float>("Cooldown for the ability: PiercingSpine (" + settings.abilityPiercingSpine + ") Seconds", ref settings.abilityPiercingSpine, minValue: 1, maxValue: 60);
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
            int tickLeaderSpeech = Convert.ToInt32(settings.abilityLeaderSpeech * 60000);
            DefDatabase<AbilityDef>.GetNamed("LeaderSpeech").cooldownTicksRange = new IntRange(tickLeaderSpeech, tickLeaderSpeech);
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

            if (ModLister.HasActiveModWithName("ludeon.rimworld.biotech") == true)
            {
                //Biotech
                int tickPiercingSpine = Convert.ToInt32(settings.abilityPiercingSpine * 60);
                DefDatabase<AbilityDef>.GetNamed("PiercingSpine").cooldownTicksRange = new IntRange(tickPiercingSpine, tickPiercingSpine);
                int tickResurrect = Convert.ToInt32(settings.abilityResurrect * 60000);
                DefDatabase<AbilityDef>.GetNamed("Resurrect").cooldownTicksRange = new IntRange(tickResurrect, tickResurrect);
                int tickAcidSpray = Convert.ToInt32(settings.abilityAcidSpray * 2500);
                DefDatabase<AbilityDef>.GetNamed("AcidSpray").cooldownTicksRange = new IntRange(tickAcidSpray, tickAcidSpray);
                int tickFoamSpray = Convert.ToInt32(settings.abilityFoamSpray * 2500);
                DefDatabase<AbilityDef>.GetNamed("FoamSpray").cooldownTicksRange = new IntRange(tickFoamSpray, tickFoamSpray);
                int tickFireSpew = Convert.ToInt32(settings.abilityFireSpew * 60000);
                DefDatabase<AbilityDef>.GetNamed("FireSpew").cooldownTicksRange = new IntRange(tickFireSpew, tickFireSpew);
                int tickLongjump = Convert.ToInt32(settings.abilityLongjump * 60);
                DefDatabase<AbilityDef>.GetNamed("Longjump").cooldownTicksRange = new IntRange(tickLongjump, tickLongjump);
                int tickFireBurst = Convert.ToInt32(settings.abilityFireBurst * 60);
                DefDatabase<AbilityDef>.GetNamed("FireBurst").cooldownTicksRange = new IntRange(tickFireBurst, tickFireBurst);
                int tickAnimalWarcall = Convert.ToInt32(settings.abilityAnimalWarcall * 60000);
                DefDatabase<AbilityDef>.GetNamed("AnimalWarcall").cooldownTicksRange = new IntRange(tickAnimalWarcall, tickAnimalWarcall);
                int tickLongjumpMech = Convert.ToInt32(settings.abilityLongjumpMech * 60);
                DefDatabase<AbilityDef>.GetNamed("LongjumpMech").cooldownTicksRange = new IntRange(tickLongjumpMech, tickLongjumpMech);
                int tickLongjumpMechLauncher = Convert.ToInt32(settings.abilityLongjumpMechLauncher * 2500);
                DefDatabase<AbilityDef>.GetNamed("LongjumpMechLauncher").cooldownTicksRange = new IntRange(tickLongjumpMechLauncher, tickLongjumpMechLauncher);
                int tickSmokepopMech = Convert.ToInt32(settings.abilitySmokepopMech * 60000);
                DefDatabase<AbilityDef>.GetNamed("SmokepopMech").cooldownTicksRange = new IntRange(tickSmokepopMech, tickSmokepopMech);
                int tickFirefoampopMech = Convert.ToInt32(settings.abilityFirefoampopMech * 60000);
                DefDatabase<AbilityDef>.GetNamed("FirefoampopMech").cooldownTicksRange = new IntRange(tickFirefoampopMech, tickFirefoampopMech);
                int tickResurrectionMech = Convert.ToInt32(settings.abilityResurrectionMech * 60000);
                DefDatabase<AbilityDef>.GetNamed("ResurrectionMech").cooldownTicksRange = new IntRange(tickResurrectionMech, tickResurrectionMech);
            }

            if (settings.separatedAblilities)
            {
                DefDatabase<AbilityDef>.GetNamed("LeaderSpeech").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("Trial").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("WorkDrive").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("CombatCommand").groupDef = null;

                DefDatabase<AbilityDef>.GetNamed("Convert").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("PreachHealth").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("Reassure").groupDef = null;
                DefDatabase<AbilityDef>.GetNamed("Counsel").groupDef = null;
            }
            else
            {
                DefDatabase<AbilityDef>.GetNamed("LeaderSpeech").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("Leader");
                DefDatabase<AbilityDef>.GetNamed("Trial").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("Leader");
                DefDatabase<AbilityDef>.GetNamed("WorkDrive").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("Leader");
                DefDatabase<AbilityDef>.GetNamed("CombatCommand").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("Leader");

                DefDatabase<AbilityDef>.GetNamed("Convert").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("Moralist");
                DefDatabase<AbilityDef>.GetNamed("PreachHealth").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("Moralist");
                DefDatabase<AbilityDef>.GetNamed("Reassure").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("Moralist");
                DefDatabase<AbilityDef>.GetNamed("Counsel").groupDef = DefDatabase<AbilityGroupDef>.GetNamed("Moralist");
            }
        }

        private static void ResetSettings()
        {

            //Rituals
            settings.ritualPenalty = 95; //%
            settings.ritualCooldown = 20; //Days

            //Leader abilities
            settings.abilityLeaderSpeech = 10; //Days
            settings.abilityTrial = 10; //Days
            settings.abilityWorkDrive = 10; //Days
            settings.abilityCombatCommand = 10; //Days
            DefDatabase<AbilityDef>.GetNamed("LeaderSpeech").cooldownTicksRange = new IntRange(600000, 600000);
            DefDatabase<AbilityDef>.GetNamed("Trial").cooldownTicksRange = new IntRange(600000, 600000);
            DefDatabase<AbilityDef>.GetNamed("WorkDrive").cooldownTicksRange = new IntRange(600000, 600000);
            DefDatabase<AbilityDef>.GetNamed("CombatCommand").cooldownTicksRange = new IntRange(600000, 600000);

            //Moral Guide abilities
            settings.abilityConvert = 8; //Days
            settings.abilityPreachHealth = 8; //Days
            settings.abilityReassure = 8; //Days
            settings.abilityCounsel = 8; //Days
            DefDatabase<AbilityDef>.GetNamed("Convert").cooldownTicksRange = new IntRange(480000, 480000);
            DefDatabase<AbilityDef>.GetNamed("PreachHealth").cooldownTicksRange = new IntRange(480000, 480000);
            DefDatabase<AbilityDef>.GetNamed("Reassure").cooldownTicksRange = new IntRange(480000, 480000);
            DefDatabase<AbilityDef>.GetNamed("Counsel").cooldownTicksRange = new IntRange(480000, 480000);

            //Specialist abilities
            settings.abilityAnimalCalm = 20; //Days
            settings.abilityImmunityDrive = 3; //Days
            settings.abilityBerserkTrance = 3; //Days
            settings.abilityMiningCommand = 3; //Days
            settings.abilityFarmingCommand = 3; //Days
            settings.abilityProductionCommand = 3; //Days
            settings.abilityResearchCommand = 3; //Days
            settings.abilityMarksmanCommand = 3; //Days
            DefDatabase<AbilityDef>.GetNamed("AnimalCalm").cooldownTicksRange = new IntRange(1200000, 1200000);
            DefDatabase<AbilityDef>.GetNamed("ImmunityDrive").cooldownTicksRange = new IntRange(180000, 180000);
            DefDatabase<AbilityDef>.GetNamed("BerserkTrance").cooldownTicksRange = new IntRange(180000, 180000);
            DefDatabase<AbilityDef>.GetNamed("MiningCommand").cooldownTicksRange = new IntRange(180000, 180000);
            DefDatabase<AbilityDef>.GetNamed("FarmingCommand").cooldownTicksRange = new IntRange(180000, 180000);
            DefDatabase<AbilityDef>.GetNamed("ProductionCommand").cooldownTicksRange = new IntRange(180000, 180000);
            DefDatabase<AbilityDef>.GetNamed("ResearchCommand").cooldownTicksRange = new IntRange(180000, 180000);
            DefDatabase<AbilityDef>.GetNamed("MarksmanCommand").cooldownTicksRange = new IntRange(180000, 180000);

            if (ModLister.HasActiveModWithName("ludeon.rimworld.biotech") == true)
            {
                //biotech
                settings.abilityPiercingSpine = 1; //Seconds
                DefDatabase<AbilityDef>.GetNamed("PiercingSpine").cooldownTicksRange = new IntRange(60, 60);
                settings.abilityResurrect = 120; //Days
                DefDatabase<AbilityDef>.GetNamed("Resurrect").cooldownTicksRange = new IntRange(7200000, 7200000);
                settings.abilityAcidSpray = 12; //Hours
                DefDatabase<AbilityDef>.GetNamed("AcidSpray").cooldownTicksRange = new IntRange(30000, 30000);
                settings.abilityFoamSpray = 12; //Hours
                DefDatabase<AbilityDef>.GetNamed("FoamSpray").cooldownTicksRange = new IntRange(30000, 30000);
                settings.abilityFireSpew = 5; //Days
                DefDatabase<AbilityDef>.GetNamed("FireSpew").cooldownTicksRange = new IntRange(300000, 300000);
                settings.abilityLongjump = 1; //Seconds
                DefDatabase<AbilityDef>.GetNamed("Longjump").cooldownTicksRange = new IntRange(60, 60);
                settings.abilityFireBurst = 45; //Seconds
                DefDatabase<AbilityDef>.GetNamed("FireBurst").cooldownTicksRange = new IntRange(2700, 2700);
                settings.abilityAnimalWarcall = 15; //Days
                DefDatabase<AbilityDef>.GetNamed("AnimalWarcall").cooldownTicksRange = new IntRange(900000, 900000);
                settings.abilityLongjumpMech = 8; //Seconds
                DefDatabase<AbilityDef>.GetNamed("LongjumpMech").cooldownTicksRange = new IntRange(480, 480);
                settings.abilityLongjumpMechLauncher = 8; //Hours
                DefDatabase<AbilityDef>.GetNamed("LongjumpMechLauncher").cooldownTicksRange = new IntRange(20000, 20000);
                settings.abilitySmokepopMech = 15; //Days
                DefDatabase<AbilityDef>.GetNamed("SmokepopMech").cooldownTicksRange = new IntRange(900000, 900000);
                settings.abilityFirefoampopMech = 5; //Days
                DefDatabase<AbilityDef>.GetNamed("FirefoampopMech").cooldownTicksRange = new IntRange(300000, 300000);
                settings.abilityResurrectionMech = 2; //Seconds
                DefDatabase<AbilityDef>.GetNamed("ResurrectionMech").cooldownTicksRange = new IntRange(120, 120);
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
                if (ModLister.HasActiveModWithName("ludeon.rimworld.biotech") == true)
                {
                    totalContentHeight = totalContentHeight + 500f;
                }
                ApplySettings();
                Harmony harmony = new Harmony("KipsMods.AdjustableAbilityCooldowns");
                harmony.PatchAll();
            }
        }
    }

}