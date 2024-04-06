using Game;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

namespace KFT.OriBF.Qol;

[HarmonyPatch(typeof(SeinSwimming), nameof(SeinSwimming.UpdateSwimIdleUnderwaterState))]
public class MouseAimSwim
{
    public static Vector2 GetAxisInput(SeinSwimming instance)
    {
        var sein = Traverse.Create(instance).Field("m_sein").GetValue<SeinCharacter>();
        if (!sein.Controller.CanMove)
        {
            return Vector2.zero;
        }
        if (sein.Input.Axis.magnitude > 0.3f)
        {
            return sein.Input.Axis;
        }
        if (Plugin.MouseSwimControls.Value)
        {
            Vector2 v = UI.Cameras.Current.Camera.WorldToScreenPoint(instance.PlatformMovement.Position);
            Vector2 b = UI.Cameras.System.GUICamera.Camera.ScreenToWorldPoint(v);
            Vector2 result = Core.Input.CursorPositionUI - b;
            if (result.magnitude > 0.5f)
            {
                return result;
            }
        }
        return Vector2.zero;
    }

    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        // Replaces original code (get input axis) with MouseAimSwim.GetAxisInput(this)
        bool skip = false;
        foreach (var i in instructions)
        {
            if (skip && i.IsStloc())
                skip = false;

            if (!skip)
            {
                yield return i;
            }

            if (i.Calls(AccessTools.Method(typeof(SeinSwimming), nameof(SeinSwimming.UpdateDrowning))))
            {
                yield return new CodeInstruction(OpCodes.Ldarg_0);
                yield return CodeInstruction.Call(typeof(MouseAimSwim), "GetAxisInput");

                skip = true;
            }
        }
    }
}

[HarmonyPatch(typeof(SeinSwimming), nameof(SeinSwimming.UpdateSwimMovingUnderwaterState))]
public class MouseAimSwimMoving
{
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        // Replaces original code (get input axis) with MouseAimSwim.GetAxisInput(this)
        bool skip = false;
        foreach (var i in instructions)
        {
            if (skip && i.IsStloc())
                skip = false;

            if (!skip)
                yield return i;

            if (i.StoresField(AccessTools.Field(typeof(PlatformMovement), "ForceKeepInAir")))
            {
                yield return new CodeInstruction(OpCodes.Ldarg_0);
                yield return CodeInstruction.Call(typeof(MouseAimSwim), "GetAxisInput");

                skip = true;
            }
        }
    }
}

[HarmonyPatch(typeof(SeinSwimming), nameof(SeinSwimming.UpdateSwimMovingUnderwaterState))]
public class InvertSwim
{
    public static bool IsSwimBoosting => Core.Input.Jump.Pressed ^ Plugin.InvertSwim.Value;

    public static bool SwimBoostPressed()
    {
        if (Plugin.InvertSwim.Value)
        {
            return Core.Input.Jump.OnReleased;
        }
        return Core.Input.Jump.OnPressed;
    }

    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        bool skip = false;
        foreach (var i in instructions)
        {
            if (skip && i.opcode == OpCodes.Brfalse)
                skip = false;

            if (i.LoadsField(AccessTools.Field(typeof(Core.Input), "Jump")))
                skip = true;

            else if (skip && i.Calls(AccessTools.Method(typeof(Core.Input.InputButtonProcessor), "get_Pressed")))
                yield return CodeInstruction.Call(typeof(InvertSwim), "get_IsSwimBoosting");

            else if (skip && i.Calls(AccessTools.Method(typeof(Core.Input.InputButtonProcessor), "get_OnPressed")))
                yield return CodeInstruction.Call(typeof(InvertSwim), "SwimBoostPressed");

            else if (!skip)
                yield return i;
        }
    }
}
