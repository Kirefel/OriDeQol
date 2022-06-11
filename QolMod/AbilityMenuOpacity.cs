﻿using Game;
using HarmonyLib;
using UnityEngine;

namespace QolMod
{
    [HarmonyPatch(typeof(SkillTreeManager), nameof(SkillTreeManager.Awake))]
    internal class AbilityMenuOpacity
    {
        private static void Postfix(SkillTreeManager __instance)
        {
            __instance.gameObject.AddComponent<AbilityMenuOpcityController>();
        }
    }

    public class AbilityMenuOpcityController : MonoBehaviour
    {
        SkillTreeManager skillTreeManager;

        private void Awake()
        {
            skillTreeManager = GetComponent<SkillTreeManager>();
        }

        private void Update()
        {
            float opacity = Characters.Sein.IsSuspended ? 1f : Settings.abilityMenuOpacity;
            skillTreeManager.NavigationManager.FadeAnimator.SetParentOpacity(opacity);
        }
    }
}
