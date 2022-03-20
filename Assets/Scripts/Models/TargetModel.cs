using UnityEngine;

namespace TestQuest.Cubes.Models
{
    public class TargetModel : MonoBehaviour
    {
        private Vector3 _position;
        private Vector3 _rotation;

        public Vector3 Position => _position;
        public Vector3 Rotation => _rotation;
        private void Awake()
        {
            var mainTransform = transform;
            
            _position = mainTransform.position;
            _rotation = mainTransform.localEulerAngles;
        }
    }
}
