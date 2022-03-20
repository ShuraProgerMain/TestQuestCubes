using System.Threading.Tasks;
using TestQuest.Cubes.Calculating;
using TestQuest.Cubes.Contexts;
using TestQuest.Cubes.Helpers;
using UnityEngine;

namespace TestQuest.Cubes.Models
{
    public class PlayerModel
    {
        private readonly Transform _transform;
        private const float DefaultDuration = 5f;
        private readonly Vector3 _defaultPosition = new Vector3(0, 5, 0);
        private readonly PoolContext _poolContext;
        public PlayerModel(Transform transform, PoolContext poolContext)
        {
            _poolContext = poolContext;
            _transform = transform;
            _transform.position = _defaultPosition;
        }
        
        public void MoveTo(Vector3 targetPosition, float duration = DefaultDuration)
        {
            var oldPosition = _transform.position;
            CoroutinesHelper.Graduate(Progress, duration);

            void Progress(float progress)
            {
                var pos = Bezier.GetPoint(oldPosition, targetPosition, progress);
                pos.y = oldPosition.y;
                
                _transform.position = pos;
            }
        }
        
        public async Task MoveToAsync(Vector3 targetPosition, float duration = DefaultDuration)
        {
            var oldPosition = _transform.position;
            await CoroutinesHelper.GraduateAsync(Progress, duration);

            void Progress(float progress)
            {
                var pos = Bezier.GetPoint(oldPosition, targetPosition, progress);
                pos.y = oldPosition.y;
                
                _transform.position = pos;
            }
        }

        public async void MoveToPointViaNearest(Vector3 targetPosition, float duration = DefaultDuration)
        {
            var nearest = _poolContext.pointsCalculateModel.GetNearestPoint(targetPosition);

            Debug.Log("step");
            await MoveToAsync(nearest);
            Debug.Log("step2");
            await MoveToAsync(targetPosition);
        }

        public void RotateTo(Vector3 targetRotation, float duration = DefaultDuration)
        {
            var oldRotation = _transform.localEulerAngles;
            CoroutinesHelper.Graduate(Progress, duration);

            void Progress(float progress)
            {
                var rotation = Interpolation.CustomLerp(oldRotation, targetRotation, progress);

                _transform.eulerAngles = rotation;
            }
        }
    }
}