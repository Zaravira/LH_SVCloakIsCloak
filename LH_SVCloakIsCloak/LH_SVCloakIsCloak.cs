using BepInEx;
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace LH_SVCloakIsCloak
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]

    public class LH_SVCloakIsCloak : BaseUnityPlugin
    {
        public const string pluginGuid = "LH_SVCloakIsCloak";
        public const string pluginName = "LH_SVCloakIsCloak";
        public const string pluginVersion = "0.0.1";

        public void Awake()
        {
            Harmony.CreateAndPatchAll(typeof(LH_SVCloakIsCloak));
        }

        [HarmonyPatch(typeof(SpaceShip), nameof(SpaceShip.RemoveCloak))]
        [HarmonyPrefix]
        static bool PreventDecloak(PlayerControl ___pc, List<MeleeWeaponControl> ___meleeControls)
        {
            if (!___pc)
                return true;
            else if (___meleeControls.Count > 0)
                return true;
            else
                return false;
        }
    }
}

