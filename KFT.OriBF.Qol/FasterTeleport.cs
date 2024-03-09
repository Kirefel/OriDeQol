using HarmonyLib;

namespace KFT.OriBF.Qol;

// Removes the 7 second minimum teleport duration
// Ported from Will of the Wisps rando by zre https://github.com/ori-community/wotw-rando-client/blob/1f9fe318da786a8e969561f323093a89d20277c4/projects/Randomizer/game/behaviour_changes/faster_teleportation.cpp

[HarmonyPatch]
public static class FasterTeleport
{
    [HarmonyPatch(typeof(TeleporterController), nameof(TeleporterController.FixedUpdate))]
    static void Postfix(ref float ___m_startTime)
    {
        if (Plugin.FasterTeleport.Value)
        {
            ___m_startTime -= 7f;
        }
    }
}
