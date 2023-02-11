using HarmonyLib;
using OriDeModLoader;
using OriDeModLoader.UIExtensions;
using UnityEngine;

namespace QolMod
{
    public class QolMod : IMod
    {
        public string Name => "QoL Mod";

        private Harmony harmony;

        public void Init()
        {
            harmony = new Harmony("qol");
            harmony.PatchAll();
            BashDeadzone.Patch(harmony);
            MoreSaveSlots.Patch(harmony);

            Cursor.lockState = Settings.cursorLock.Value ? CursorLockMode.Confined : CursorLockMode.None;
            Settings.cursorLock.OnValueChanged += value => Cursor.lockState = value ? CursorLockMode.Confined : CursorLockMode.None;

            CustomMenuManager.RegisterOptionsScreen<QolOptionsScreen>("Advanced", 0);
        }

        public void Unload()
        {
            harmony.UnpatchAll("qol");
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
