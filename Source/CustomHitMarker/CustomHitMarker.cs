using System.Reflection;
using HarmonyLib;
using Verse;

namespace CustomHitMarker;

[StaticConstructorOnStartup]
public static class CustomHitMarker
{
    static CustomHitMarker()
    {
        var harmonyInstance = new Harmony("com.rimworld.Dalrae.CustomHitMarker");
        harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
    }
}