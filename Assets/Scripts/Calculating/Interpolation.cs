using UnityEngine;

namespace TestQuest.Cubes.Calculating
{
    public static class Interpolation
    {
        public static Vector3 CustomLerp(Vector3 before, Vector3 after, float time)
        {
            time = Mathf.Clamp01(time);

            return new Vector3(before.x + (after.x - before.x) * time, before.y + (after.y - before.y) * time,
                before.z + (after.z - before.z) * time);
        }
        
        public static float CustomLerp(float before, float after, float time)
        {
            return before + (after - before) * Mathf.Clamp01(time);
        }
    }
}