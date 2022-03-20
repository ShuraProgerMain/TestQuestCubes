using UnityEngine;

namespace TestQuest.Cubes.Calculating
{
    public static class Bezier
    {
        private const float BisectorLenght = 1f;

        public static Vector3 GetPoint(Vector3 pointStart, Vector3 pointEnd, float time)
        {
            var pointBisector = CalculateBisector(pointStart, pointEnd);

            return GetVector(pointStart, pointEnd, pointBisector, time);
        }

        private static Vector3 CalculateBisector(Vector3 pointStart, Vector3 pointEnd)
        {
            var middlePoint = (pointStart + pointEnd) / 2;

            var slide1 = pointStart - middlePoint;
            var newPoint = BisectorLenght * (Vector3.Cross(Vector3.up, slide1));
            return newPoint + middlePoint;
        }

        private static Vector3 GetVector(Vector3 pointStart, Vector3 pointEnd, Vector3 pointBisector, float time)
        {
            time = Mathf.Clamp01(time);

            var x = CalculatingCoordinatesFromThreePoints(pointStart.x, pointEnd.x, pointBisector.x, time); 
            var z = CalculatingCoordinatesFromThreePoints(pointStart.z, pointEnd.z, pointBisector.z, time); 

            return new Vector3(x, 0, z);
        }

        private static float CalculatingCoordinatesFromThreePoints(float pointStart, float pointEnd, float pointBisector, float time)
        {
            var oneMinusT = 1f - time;

            return (oneMinusT * oneMinusT) * pointStart + 2 * (oneMinusT) * time * pointBisector + (time * time) * pointEnd;
        }
    }
}