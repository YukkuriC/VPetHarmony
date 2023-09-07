using VPet_Simulator.Windows.Interface;
using HarmonyLib;

namespace VPetHarmony
{
    public partial class ModMain : MainPlugin
    {
        public override string PluginName => "YukkuriC.InjectTemplate";
        IMainWindow mw;
        Harmony patcher;

        public ModMain(IMainWindow mainwin) : base(mainwin)
        {
            mw = mainwin;
            patcher = Injector.Init(PluginName);
        }
    }

    public static partial class Injector
    {
        public static Harmony Init(string name)
        {
            var patcher = new Harmony(name);
            patcher.PatchAll();
            return patcher;
        }
    }
}
