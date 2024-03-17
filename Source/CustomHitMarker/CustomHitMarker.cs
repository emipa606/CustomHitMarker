using System.Reflection;
using HarmonyLib;
using Verse;

namespace CustomHitMarker;

[StaticConstructorOnStartup]
public static class CustomHitMarker
{
    static CustomHitMarker()
    {
        new Harmony("com.rimworld.Dalrae.CustomHitMarker").PatchAll(Assembly.GetExecutingAssembly());
    }
}