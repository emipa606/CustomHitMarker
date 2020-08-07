using System;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace CustomHitMarker
{
	// Token: 0x02000005 RID: 5
	[HarmonyPatch(typeof(Thing))]
	[HarmonyPatch("TakeDamage")]
	public static class CustomHitMakerB
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000021A4 File Offset: 0x000003A4
		[HarmonyPostfix]
		private static void Postfix(DamageInfo dinfo, Thing __instance)
		{
			bool flag = dinfo.Def == DamageDefOf.Flame || dinfo.Def == DamageDefOf.Mining || dinfo.Def == DamageDefOf.Deterioration || dinfo.Def == DamageDefOf.Rotting || !__instance.Position.ShouldSpawnMotesAt(__instance.Map) || __instance.Map.moteCounter.SaturatedLowPriority || __instance.def.category == ThingCategory.Mote;
			if (!flag)
			{
				MoteThrown moteThrown = (MoteThrown)ThingMaker.MakeThing(DRCHM_ThingDefOf.DRCHM_Hitmarker, null);
				moteThrown.Scale = 0.5f;
				var random = new System.Random();
				float num = (float)random.Next(-5, 5);
				float num2 = (float)random.Next(-5, 5);
				Vector3 drawPos = __instance.DrawPos;
				drawPos.x += num * 0.1f;
				drawPos.z += num2 * 0.1f;
				moteThrown.exactPosition = drawPos;
				GenSpawn.Spawn(moteThrown, __instance.Position, __instance.Map, WipeMode.Vanish);
				DRCHM_ThingDefOf.DRCHM_Hitmarker_Sound.PlayOneShot(new TargetInfo(__instance.Position, __instance.Map, false));
			}
		}
	}
}
