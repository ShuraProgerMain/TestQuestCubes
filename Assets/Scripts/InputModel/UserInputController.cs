using TestQuest.Cubes.Contexts;
using TestQuest.Cubes.Interfaces;
using TestQuest.Cubes.Models;
using UnityEngine;

namespace TestQuest.Cubes.InputModel
{
    public class UserInputController : IUpdated
    {
        private readonly Camera _mainCamera;
        private readonly PoolContext _poolContext;
        
        public UserInputController(PoolContext poolContext)
        {
            _mainCamera = Camera.main;
            _poolContext = poolContext;
        }

        public void Updating()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Click(Input.mousePosition);
            }
        }
        
        private void Click(Vector3 position)
        {
            var ray = _mainCamera.ScreenPointToRay(position);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                if (hit.collider.TryGetComponent(out TargetModel target))
                {
                    _poolContext.playerModel.MoveToPointViaNearest(target.Position);
                    _poolContext.playerModel.RotateTo(target.Rotation);
                }
            }
        }
    }
}
