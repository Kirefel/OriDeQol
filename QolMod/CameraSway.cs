using HarmonyLib;

namespace QolMod
{
    [HarmonyPatch(typeof(AreaMapNavigation), nameof(AreaMapNavigation.UpdatePlane))]
    internal class AreaMapCameraSwayPatch
    {
        private static void Postfix(AreaMapNavigation __instance)
        {
            if (Settings.cameraSway)
                return;

            // Eliminate the offset used to move the camera around
            __instance.MapPivot.position = -__instance.ScrollPosition * __instance.Zoom;
        }
    }

    [HarmonyPatch(typeof(WorldMapUI), nameof(WorldMapUI.UpdateCameraPosition))]
    internal class WorldMapCameraSwayPatch
    {
        private static void Postfix(WorldMapUI __instance)
        {
            if (Settings.cameraSway)
                return;

            Vector3 position;
            position2.x = Mathf.Lerp(__instance.FarPosition.x, __instance.ClosePosition.x, __instance.ZoomXYCurve.Evaluate(__instance.ZoomTime));
            position2.y = Mathf.Lerp(__instance.FarPosition.y, __instance.ClosePosition.y, __instance.ZoomXYCurve.Evaluate(__instance.ZoomTime));
            position2.z = Mathf.Lerp(__instance.FarPosition.z, __instance.ClosePosition.z, __instance.ZoomZCurve.Evaluate(__instance.ZoomTime));
            __instance.Camera.transform.position = position;
        }
    }
}
