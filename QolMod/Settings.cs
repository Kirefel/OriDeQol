using BaseModLib;

namespace QolMod
{
    public class Settings
    {
        public static float BashDeadzone = 0.5f;

        public static BoolSetting cursorLock = new BoolSetting("Cursor Lock", true);
        public static BoolSetting runInBackground = new BoolSetting("Run In Background", true);
        public static FloatSetting abilityMenuOpacity = new FloatSetting("Ability Menu Opacity", 0.5f);
    }
}
