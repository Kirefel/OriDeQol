using BaseModLib;

namespace QolMod
{
    public class Settings
    {
        public static BoolSetting cursorLock = new BoolSetting("qolCursorLock", false);
        public static BoolSetting runInBackground = new BoolSetting("qolRunInBackground", true);
        public static FloatSetting bashDeadzone = new FloatSetting("qolBashDeadzone", 0.5f);
        public static FloatSetting abilityMenuOpacity = new FloatSetting("qolAbilityMenuOpacity", 0.5f);
        public static FloatSetting screenShakeStrength = new FloatSetting("qolScreenShakeStrength", 1f);
        public static BoolSetting skipText = new BoolSetting("qolSkipText", true);
    }
}
