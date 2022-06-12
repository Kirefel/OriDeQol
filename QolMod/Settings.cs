using BaseModLib;

namespace QolMod
{
    public class Settings
    {
        public static float BashDeadzone = 0.5f;

        public static BoolSetting cursorLock = new BoolSetting("qolCursorLock", true);
        public static BoolSetting runInBackground = new BoolSetting("qolRunInBackground", true);
        public static FloatSetting abilityMenuOpacity = new FloatSetting("qolAbilityMenuOpacity", 0.5f);
    }
}
