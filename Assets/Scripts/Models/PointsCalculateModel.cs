using TestQuest.Cubes.Contexts;
using UnityEngine;

namespace TestQuest.Cubes.Models
{
    public class PointsCalculateModel
    {
        private readonly PoolContext _poolContext;
        private readonly TargetModel[] _targetObjects;

        public PointsCalculateModel(PoolContext poolContext, TargetModel[] targetObjects)
        {
            _poolContext = poolContext;
            _targetObjects = targetObjects;
        }

        public Vector3 GetNearestPoint(Vector3 point)
        {
            var distance = Mathf.Infinity;
            TargetModel nearestModel = default;

            foreach (var targetObject in _targetObjects)
            {
                var tempDistance = Vector3.Distance(point, targetObject.Position);
                if (tempDistance < distance && tempDistance > 0f)
                {
                    distance = tempDistance;
                    nearestModel = targetObject;
                }
            }

            return nearestModel.Position;
        }
    }
}