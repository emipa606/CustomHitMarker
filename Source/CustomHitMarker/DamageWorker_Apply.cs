using System;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.Sound;

namespace CustomHitMarker;

[HarmonyPatch(typeof(DamageWorker), nameof(DamageWorker.Apply))]
public static class DamageWorker_Apply
{
    public static void Postfix(DamageInfo dinfo, Thing victim)
    {
        if (victim is not Pawn)
        {
            return;
        }

        if (dinfo.Def == DamageDefOf.Flame || dinfo.Def == DamageDefOf.Mining ||
            dinfo.Def == DamageDefOf.Deterioration || dinfo.Def == DamageDefOf.Rotting)
        {
            return;
        }

        CustomHitMarker.TriggerHitMarking(victim);
    }
}