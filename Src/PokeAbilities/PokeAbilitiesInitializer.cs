using HarmonyLib;

namespace PokeAbilities
{
    public class PokeAbilitiesInitializer : ModInitializer
    {
        public override void OnInitializeMod()
        {
            new Harmony("PokeAbilities").PatchAll();
        }
    }
}
