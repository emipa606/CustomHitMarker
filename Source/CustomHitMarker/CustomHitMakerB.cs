using System;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.Sound;

namespace CustomHitMarker;

[HarmonyPatch(typeof(Thing))]
[HarmonyPatch("TakeDamage")]
public static class CustomHitMakerB
{
    [HarmonyPostfix]
    private static void Postfix(DamageInfo dinfo, Thing __instance)
    {
        if (dinfo.Def == DamageDefOf.Flame || dinfo.Def == DamageDefOf.Mining ||
            dinfo.Def == DamageDefOf.Deterioration || dinfo.Def == DamageDefOf.Rotting ||
            !__instance.Position.ShouldSpawnMotesAt(__instance.Map) ||
            __instance.Map.moteCounter.SaturatedLowPriority || __instance.def.category == ThingCategory.Mote)
        {
            return;
        }

        var moteThrown = (MoteThrown)ThingMaker.MakeThing(DRCHM_ThingDefOf.DRCHM_Hitmarker);
        moteThrown.Scale = 0.5f;
        var random = new Random();
        float num = random.Next(-5, 5);
        float num2 = random.Next(-5, 5);
        var drawPos = __instance.DrawPos;
        drawPos.x += num * 0.1f;
        drawPos.z += num2 * 0.1f;
        moteThrown.exactPosition = drawPos;
        GenSpawn.Spawn(moteThrown, __instance.Position, __instance.Map);
        DRCHM_ThingDefOf.DRCHM_Hitmarker_Sound.PlayOneShot(new TargetInfo(__instance.Position, __instance.Map));
    }
}