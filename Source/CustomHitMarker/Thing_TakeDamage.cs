using System;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.Sound;

namespace CustomHitMarker;

[HarmonyPatch(typeof(Thing), nameof(Thing.TakeDamage))]
public static class Thing_TakeDamage
{
    public static void Postfix(DamageInfo dinfo, Thing __instance)
    {
        if (__instance is not Pawn)
        {
            return;
        }

        if (dinfo.Def == DamageDefOf.Flame || dinfo.Def == DamageDefOf.Mining ||
            dinfo.Def == DamageDefOf.Deterioration || dinfo.Def == DamageDefOf.Rotting)
        {
            return;
        }

        CustomHitMarker.TriggerHitMarking(__instance);
    }
}