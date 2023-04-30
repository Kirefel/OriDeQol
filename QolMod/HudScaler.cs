using HarmonyLib;
using UnityEngine;

namespace QolMod
{
    public class HudScaler : MonoBehaviour
    {
        Transform bottom, left, right;

        void Awake()
        {
            bottom = transform.Find("ui/status/dots");
            left = transform.Find("ui/left/mapstones");
            right = transform.Find("ui/right/keystones");

            Settings.hudScale.OnValueChanged += UpdateScale;

            UpdateScale(Settings.hudScale.Value);
        }

        void OnDestroy()
        {
            Settings.hudScale.OnValueChanged -= UpdateScale;
        }

        void UpdateScale(float scale)
        {
            float bottomScale = scale * 0.15f;
            bottom.transform.localScale = new Vector3(bottomScale, bottomScale, 1);
            left.transform.localScale = Vector3.one * scale;
            right.transform.localScale = Vector3.one * scale;
        }
    }

    [HarmonyPatch(typeof(SeinUI), nameof(SeinUI.Awake))]
    static class HudScalePatch
    {
        static void Postfix(SeinUI __instance)
        {
            __instance.gameObject.AddComponent<HudScaler>();
        }
    }
}
