using System.Collections.Generic;
using System.Linq;
using Session;
using UnityEngine;

namespace Turrets
{
    public class TurretsController : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;
        
        private List<Turret> _turrets;

        private void Awake()
        {
            _turrets = new List<Turret>();

            _turrets = FindObjectsOfType<Turret>().ToList();
        }

        public void Remove(Turret turret)
        {
            
            _turrets.Remove(turret);

            Destroy(turret.gameObject);
            
            if (_turrets.Count == 0)
            {
                _gameState.ShowVictoryScreen();
            }
        }
    }
}