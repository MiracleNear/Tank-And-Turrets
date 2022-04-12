using Player;
using Session;
using Turrets;
using UnityEngine;

namespace HealthSystem
{
    public class DeathHandler : MonoBehaviour, IVisitor
    {
        [SerializeField] private TurretsController _turretsController;
        [SerializeField] private GameState _gameState;
        
        public void Visit(Tank tank)
        {
            _gameState.ShowDefeatScreen();
            
            Destroy(tank.gameObject);
        }

        public void Visit(Turret turret)
        {
            _turretsController.Remove(turret);   
        }
    }
}