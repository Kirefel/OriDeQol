using OriDeModLoader.UIExtensions;

namespace QolMod
{
    public class OptionsScreen : CustomOptionsScreen
    {
        public override void InitScreen()
        {
            AddToggle(Settings.cursorLock, "Whether the cursor should be locked to the screen");
            AddToggle(Settings.runInBackground, "Whether the game should continue to run when the window is not selected");
            AddSlider(Settings.abilityMenuOpacity, 0f, 1f, 0.1f, "How opaque should the ability menu be while moving in the background (min 0%, max 100%)");
        }
    }
}
