using HarmonyLib;

namespace QolMod
{
    [HarmonyPatch(typeof(CameraShake), "get_ModifiedStrength")]
    public class ReduceScreenShake
    {
        public static void Postfix(ref float __result)
        {
            __result *= Settings.screenShakeStrength.Value;
        }
    }
}
