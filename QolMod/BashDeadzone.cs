using System.Collections.Generic;
using HarmonyLib;

namespace QolMod
{
    internal class BashDeadzone
    {
        internal static void Patch(Harmony harmony)
        {
            // Required to patch internal class
            harmony.Patch(AccessTools.Method("BashAttackGame:FixedUpdate"), transpiler: new HarmonyMethod(typeof(BashDeadzone), nameof(BashDeadzone.Transpiler)));
        }

        private static float GetBashDeadzone() => Settings.bashDeadzone.Value;

        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var i in instructions)
            {
                if (i.LoadsConstant(0.0400000028f))
                    yield return CodeInstruction.Call(typeof(BashDeadzone), nameof(BashDeadzone.GetBashDeadzone));
                else
                    yield return i;
            }
        }
    }
}
