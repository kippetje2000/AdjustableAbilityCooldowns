using Verse;

namespace Adjustable_Ability_Cooldowns.Utilities
{
    public static class Example_Settings
    {
        //60000 ticks = 1 day
        //60 ticks = 1 sec
        //2500 ticks = 1 hour
        public static float abilityExampleData = 1; //Hours
        public static float ritualExampleData = 1; //days
        public static void ExposeDataExample()
        {
            /*            Scribe_Values.Look(ref abilityExampleData, "abilityExampleData");
                        Scribe_Values.Look(ref ritualExampleData, "ritualExampleData");
            */
        }
        public static void DrawExample(Listing_Standard listing_Standard)
        {
            /*            listing_Standard.Label("Example abilities");
                        listing_Standard.AddLabeledSlider("Cooldown for the ability: Example (" + abilityExampleData + ") Hours", ref abilityExampleData, 0, 24, "0", "24", 0.5f);
                        listing_Standard.AddLabeledSlider("Cooldown for the ritual: Example (" + ritualExampleData + ") days", ref ritualExampleData, 0, 120, "0", "120", 1f);
                        listing_Standard.AddHorizontalLine();*/
        }
        public static void ApplySettingExample()
        {
            /*            int tickAbilityExampleData = Convert.ToInt32(abilityExampleData * 2500 + 1);
                        DefDatabase<AbilityDef>.GetNamed("AbilityExampleData").cooldownTicksRange = new IntRange(tickAbilityExampleData, tickAbilityExampleData);
                        int tickRitualExampleData = Convert.ToInt32(ritualExampleData * 60000 + 1);
                        DefDatabase<AbilityDef>.GetNamed("RitualExampleData").cooldownTicksRange = new IntRange(tickRitualExampleData, tickRitualExampleData);*/
        }
        public static void ResetSettingsExample()
        {
            abilityExampleData = 1; //Hours
            ritualExampleData = 1; //days
        }
    }
}
