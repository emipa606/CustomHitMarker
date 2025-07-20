using HarmonyLib;
using Verse;

namespace CustomHitMarker;

[HarmonyPatch(typeof(Pawn), nameof(Pawn.Kill))]
public static class Pawn_Kill
{
    public static void Postfix(DamageInfo dinfo, Thing __instance)
    {
        // when a pawn receives fatal damage, it is immediately destroyed with a Corpse replacing it at the position
        // we may still need to spawn hit markers here

        if (!CustomHitMarker.DamageIsEligibleForHitMarking(dinfo))
        {
            return;
        }

        CustomHitMarker.TriggerHitMarking(__instance);
    }
}