using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace KFT.OriBF.Qol;

[HarmonyPatch]
public static class FasterTeleport
{
    public static float GetMinimumTPDuration()
    {
        return Plugin.FasterTeleport.Value ? 0f : 7f;
    }

    [HarmonyPatch(typeof(TeleporterController), nameof(TeleporterController.FixedUpdate)), HarmonyTranspiler]
    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        foreach (var ci in instructions)
        {
            if (ci.opcode == OpCodes.Ldc_R4 && (float)ci.operand == 7f)
                yield return CodeInstruction.Call(typeof(FasterTeleport), nameof(GetMinimumTPDuration));
            else
                yield return ci;
        }
    }
}
