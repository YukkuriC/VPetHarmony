using HarmonyLib;
using VPet_Simulator.Windows.Interface;
using VPet_Simulator.Core;
using LinePutScript.Localization.WPF;

namespace VPetHarmony
{
    [HarmonyPatch]
    public static partial class Injector
    {
        [HarmonyPostfix, HarmonyPatch(typeof(LocalizeCore), nameof(LocalizeCore.Translate), typeof(string))]
        public static void OverrideAllKey(ref string __result)
        {
            __result = "HelloWorld";
        }
    }
}
