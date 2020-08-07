using System;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace CustomHitMarker
{
	// Token: 0x02000002 RID: 2
	[StaticConstructorOnStartup]
	public static class CustomHitMarker
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		static CustomHitMarker()
		{
			var harmonyInstance = new Harmony("com.rimworld.Dalrae.CustomHitMarker");
			harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
		}
	}
}
