using System;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace CustomHitMarker
{
	// Token: 0x02000004 RID: 4
	[HarmonyPatch(typeof(DamageWorker))]
	[HarmonyPatch("Apply")]
	public static class CustomHitMakerA
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002078 File Offset: 0x00000278
		[HarmonyPostfix]
		private static void Postfix(DamageInfo dinfo, Thing victim)
		{
			bool flag = dinfo.Def == DamageDefOf.Flame || dinfo.Def == DamageDefOf.Mining || dinfo.Def == DamageDefOf.Deterioration || dinfo.Def == DamageDefOf.Rotting || !victim.Position.ShouldSpawnMotesAt(victim.Map) || victim.Map.moteCounter.SaturatedLowPriority || victim.def.category == ThingCategory.Mote;
			if (!flag)
			{
				MoteThrown moteThrown = (MoteThrown)ThingMaker.MakeThing(DRCHM_ThingDefOf.DRCHM_Hitmarker, null);
				moteThrown.Scale = 0.5f;
				var random = new System.Random();
				float num = (float)random.Next(-5, 5);
				float num2 = (float)random.Next(-5, 5);
				Vector3 drawPos = victim.DrawPos;
				drawPos.x += num * 0.1f;
				drawPos.z += num2 * 0.1f;
				moteThrown.exactPosition = drawPos;
				GenSpawn.Spawn(moteThrown, victim.Position, victim.Map, WipeMode.Vanish);
				DRCHM_ThingDefOf.DRCHM_Hitmarker_Sound.PlayOneShot(new TargetInfo(victim.Position, victim.Map, false));
			}
		}
	}
}
