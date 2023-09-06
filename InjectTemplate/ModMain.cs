using VPet_Simulator.Windows.Interface;
using HarmonyLib;

namespace VPetHarmony
{
    public class ModMain : MainPlugin
    {
        public override string PluginName => "YukkuriC.InjectTemplate";
        IMainWindow mw;
        Harmony patcher;

        public ModMain(IMainWindow mainwin) : base(mainwin)
        {
            mw = mainwin;
            //Harmony.DEBUG = true;
            patcher = new Harmony(PluginName);
            patcher.PatchAll();

            // must call or patch will be ignored, why?
            Injector.RecordRef();
        }
    }
}
