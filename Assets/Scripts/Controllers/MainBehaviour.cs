using TestQuest.Cubes.Contexts;
using TestQuest.Cubes.InputModel;
using TestQuest.Cubes.Models;
using UnityEngine;

namespace TestQuest.Cubes.Controllers
{
    public class MainBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private TargetModel[] targetObjects;

        private PoolContext _poolContext;
        private PlayerModel _playerModel;
        private PointsCalculateModel _pointsCalculateModel;
        private UserInputController _userInputController;

        private void Awake()
        {
            _poolContext = new PoolContext();
            
            _poolContext.playerModel = new PlayerModel(player, _poolContext);
            _poolContext.pointsCalculateModel = new PointsCalculateModel(_poolContext, targetObjects);
            
            _userInputController = new UserInputController(_poolContext);
        }

        private void Update()
        {
            _userInputController.Updating();
        }
    }
}