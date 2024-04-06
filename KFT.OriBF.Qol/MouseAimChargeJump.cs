using Game;
using HarmonyLib;
using UnityEngine;

namespace KFT.OriBF.Qol;

[HarmonyPatch(typeof(SeinWallChargeJump), nameof(SeinWallChargeJump.UpdateAimElevation))]
public class MouseAimChargeJump
{
    public static void Postfix(SeinWallChargeJump __instance, ref float ___m_angularElevation)
    {
        if (Plugin.MouseChargeJumpControls.Value)
        {
            float directionLeftRight = __instance.PlatformMovement.HasWallLeft ? 1f : -1f;

            Vector2 v = UI.Cameras.Current.Camera.WorldToScreenPoint(__instance.Arrow.transform.position);
            Vector2 b = UI.Cameras.System.GUICamera.Camera.ScreenToWorldPoint(v);
            Vector2 vector = Core.Input.CursorPositionUI - b;
            if (/*Core.Input.CursorMoved && */vector.magnitude > 1f && MoonMath.Float.Normalize(vector.x) == directionLeftRight)
            {
                float angle = Mathf.Atan2(vector.y, vector.x * directionLeftRight) * 57.29578f;
                //if (Mathf.Abs(angle) <= 60f)
                //{
                ___m_angularElevation = angle;
                //}
            }
        }
    }
}
