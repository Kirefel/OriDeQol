using OriDeModLoader.UIExtensions;

namespace QolMod
{
    public class QolOptionsScreen : CustomOptionsScreen
    {
        public override void InitScreen()
        {
            AddToggle(Settings.cursorLock, "Cursor Lock", "Whether the cursor should be locked to the screen");
            AddSlider(Settings.screenShakeStrength, "Screen Shake Strength", 0f, 1f, 0.1f, "How strong should the screen shake effects be (min 0%, max 100%)");
            AddSlider(Settings.bashDeadzone, "Bash Deadzone", 0f, 1f, 0.1f, "How large should the deadzone be while bashing (min 0%, max 100%)");
            AddToggle(Settings.runInBackground, "Run In Background", "Whether the game should continue to run when the window is not selected");
            AddSlider(Settings.abilityMenuOpacity, "Ability Menu Opacity", 0f, 1f, 0.1f, "How opaque should the ability menu be while moving in the background (min 0%, max 100%)");
            AddToggle(Settings.skipText, "Skip Text", "Whether the text boxes from Sein and pickups should be skipped");
            AddToggle(Settings.cameraSway, "Camera Sway", "Whether the camera should subtly move when stationary");
        }
    }
}
