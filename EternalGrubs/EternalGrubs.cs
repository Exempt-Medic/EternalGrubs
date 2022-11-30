using Modding;
using System;
using HutongGames.PlayMaker.Actions;
using SFCore.Utils;

namespace EternalGrubs
{
    public class EternalGrubsMod : Mod
    {
        private static EternalGrubsMod? _instance;

        internal static EternalGrubsMod Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException($"An instance of {nameof(EternalGrubsMod)} was never constructed");
                }
                return _instance;
            }
        }

        public override string GetVersion() => GetType().Assembly.GetName().Version.ToString();

        public EternalGrubsMod() : base("EternalGrubs")
        {
            _instance = this;
        }

        public override void Initialize()
        {
            Log("Initializing");

            On.PlayMakerFSM.OnEnable += OnFsmEnable;

            Log("Initialized");
        }
        private void OnFsmEnable(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            orig(self);

            if (self.gameObject.name == "Grub King" && self.FsmName == "King Control")
            {
                self.GetFsmAction<SetPlayerDataBool>("Final Reward?", 1).Enabled = false;
            }
        }
    }
}
