using HarmonyLib;
using RimWorld;
using Verse;

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

        // when a pawn is about to take damage, this method is called
        // this method is called before the game checks for e.g. shields and armor
        // then, the game calls DamageWorker.Apply(...), which may apply special damage effects to the pawn (e.g. to stun the pawn)
        // as such, no need to spawn hit markers at DamageWorker.Apply(...)

        if (dinfo.Instigator == null)
        {
            // no instigator; basically, indirect or "natural" damage
            // then, need not spawn hit markers
            return;
        }

        if (dinfo.Def == DamageDefOf.Flame || 
            dinfo.Def == DamageDefOf.ToxGas)
        {
            // "ticker" damage need not spawn hit markers
            return;
        }

        CustomHitMarker.TriggerHitMarking(__instance);
    }
}