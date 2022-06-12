using HarmonyLib;

namespace QolMod
{
    [HarmonyPatch(typeof(GameController), "OnApplicationFocus")]
    internal class AlwaysRunInBackground
    {
        private static bool Prefix()
        {
            if (Settings.runInBackground.Value)
            {
                GameController.IsFocused = true;
                return false;
            }

            return true;
        }
    }
}
