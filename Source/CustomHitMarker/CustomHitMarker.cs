using HarmonyLib;
using System;
using System.Reflection;
using Verse;
using Verse.Sound;

namespace CustomHitMarker;

[StaticConstructorOnStartup]
public static class CustomHitMarker
{
    static CustomHitMarker()
    {
        new Harmony("com.rimworld.Dalrae.CustomHitMarker").PatchAll(Assembly.GetExecutingAssembly());
    }

    /// <summary>
    /// Spawns a hit marker mote and plays the hit marker sound once at the specified thing, with mote position randomization.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="map"></param>
    internal static void TriggerHitMarking(Thing thing)
    {
        var theMap = thing.Map;
        if (theMap == null || !thing.Position.ShouldSpawnMotesAt(theMap) || thing.Map.moteCounter.SaturatedLowPriority)
        {
            // skip handling if thing is not in any map
            // or, we should not be spawning motes according to game optimizations/limits
            return;
        }

        // randomize the mote position to be between -0.5 and +0.5, which is conveniently done by shifting random [0, 1) to [-0.5, 0.5)
        var random = new Random();
        var deltaX = (float)(random.NextDouble() - 0.5);
        var deltaZ = (float)(random.NextDouble() - 0.5);

        // then generate the mote/play the sound
        var hitMarkerMote = (MoteThrown)ThingMaker.MakeThing(DRCHM_ThingDefOf.DRCHM_Hitmarker);
        hitMarkerMote.Scale = 0.5f;
        var markerDrawPos = thing.DrawPos;
        markerDrawPos.x += deltaX;
        markerDrawPos.z += deltaZ;
        hitMarkerMote.exactPosition = markerDrawPos;
        GenSpawn.Spawn(hitMarkerMote, thing.Position, theMap);
        DRCHM_ThingDefOf.DRCHM_Hitmarker_Sound.PlayOneShot(new TargetInfo(thing.Position, theMap));
    }
}