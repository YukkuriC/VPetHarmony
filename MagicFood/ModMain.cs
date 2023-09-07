using VPet_Simulator.Windows.Interface;
using HarmonyLib;
using VPet_Simulator.Windows;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VPetHarmony
{
    public class MagicFoodPlugin : MainPlugin
    {
        public override string PluginName => "YukkuriC.MagicFood";
        MainWindow mw;
        Harmony patcher;
        public static MagicFoodPlugin instance { get; private set; }

        public MagicFoodPlugin(IMainWindow mainwin) : base(mainwin)
        {
            mw = mainwin as MainWindow;
            patcher = Injector.Init(PluginName);
            instance = this;
        }

        public void OnTakeItem(Food item)
        {
            switch (item.Name)
            {
                default: return;
                case "forget_spray":
                    {
                        var petData = mw.Set.PetData;
                        var now = DateTime.Now;
                        foreach (var f in mw.Foods)
                        {
                            var key = "buytime_" + f.Name;
                            var expireTime = petData.GetDateTime(key, now);
                            if (expireTime > now)
                            {
                                petData.SetDateTime(key, now);
                                item.LoadEatTimeSource(MW);
                                item.NotifyOfPropertyChange("Description");
                                // TODO 未知原因刷新不及时
                            }
                        }
                    }
                    break;
                case "forgive_me":
                    mw.HashCheck = true;
                    foreach (var key in mw.Set.Statistics.Data.Keys.ToList())
                    {
                        if (!key.StartsWith("stat_bb_")) continue;
                        var val = mw.Set.Statistics.GetDouble(key);
                        if (val < 0) mw.Set.Statistics.SetDouble(key, 0);
                    }
                    break;
            }
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
