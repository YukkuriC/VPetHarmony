using VPet_Simulator.Windows.Interface;
using HarmonyLib;

namespace VPetHarmony
{
    public class ModMain : MainPlugin
    {
        public override string PluginName => "YukkuriC.InjectTemplate";
        IMainWindow mw;
        Harmony patcher;
        public static ModMain instance { get; private set; }

        public ModMain(IMainWindow mainwin) : base(mainwin)
        {
            mw = mainwin;
            patcher = Injector.Init(PluginName);
            instance = this;
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
