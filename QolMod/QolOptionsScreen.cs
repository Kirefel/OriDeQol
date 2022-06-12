using OriDeModLoader.UIExtensions;

namespace QolMod
{
    public class QolOptionsScreen : CustomOptionsScreen
    {
        public override void InitScreen()
        {
            AddToggle(Settings.cursorLock, "Cursor Lock", "Whether the cursor should be locked to the screen");
            AddToggle(Settings.runInBackground, "Run In Background", "Whether the game should continue to run when the window is not selected");
            AddSlider(Settings.abilityMenuOpacity, "Ability Menu Opacity", 0f, 1f, 0.1f, "How opaque should the ability menu be while moving in the background (min 0%, max 100%)");
        }
    }
}
