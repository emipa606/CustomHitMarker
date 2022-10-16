using System;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.Sound;

namespace CustomHitMarker;

[HarmonyPatch(typeof(DamageWorker))]
[HarmonyPatch("Apply")]
public static class CustomHitMakerA
{
    [HarmonyPostfix]
    private static void Postfix(DamageInfo dinfo, Thing victim)
    {
        if (dinfo.Def == DamageDefOf.Flame || dinfo.Def == DamageDefOf.Mining ||
            dinfo.Def == DamageDefOf.Deterioration || dinfo.Def == DamageDefOf.Rotting ||
            !victim.Position.ShouldSpawnMotesAt(victim.Map) || victim.Map.moteCounter.SaturatedLowPriority ||
            victim.def.category == ThingCategory.Mote)
        {
            return;
        }

        var moteThrown = (MoteThrown)ThingMaker.MakeThing(DRCHM_ThingDefOf.DRCHM_Hitmarker);
        moteThrown.Scale = 0.5f;
        var random = new Random();
        float num = random.Next(-5, 5);
        float num2 = random.Next(-5, 5);
        var drawPos = victim.DrawPos;
        drawPos.x += num * 0.1f;
        drawPos.z += num2 * 0.1f;
        moteThrown.exactPosition = drawPos;
        GenSpawn.Spawn(moteThrown, victim.Position, victim.Map);
        DRCHM_ThingDefOf.DRCHM_Hitmarker_Sound.PlayOneShot(new TargetInfo(victim.Position, victim.Map));
    }
}