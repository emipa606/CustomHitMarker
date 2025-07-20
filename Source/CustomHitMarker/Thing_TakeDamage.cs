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
        if (dinfo.Def == DamageDefOf.Flame || dinfo.Def == DamageDefOf.Mining ||
            dinfo.Def == DamageDefOf.Deterioration || dinfo.Def == DamageDefOf.Rotting ||
            !__instance.Position.ShouldSpawnMotesAt(__instance.Map) ||
            __instance.Map.moteCounter.SaturatedLowPriority || __instance.def.category == ThingCategory.Mote)
        {
            return;
        }

        CustomHitMarker.TriggerHitMarking(__instance);
    }
}