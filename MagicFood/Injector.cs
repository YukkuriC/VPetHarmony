using HarmonyLib;
using VPet_Simulator.Windows;
using VPet_Simulator.Windows.Interface;

namespace VPetHarmony
{
    [HarmonyPatch]
    public static partial class Injector
    {
        [HarmonyPostfix, HarmonyPatch(typeof(MainWindow), nameof(MainWindow.TakeItem))]
        public static void OnTakeItem(Food item)
        {
            MagicFoodPlugin.instance.OnTakeItem(item);
        }
    }
}
