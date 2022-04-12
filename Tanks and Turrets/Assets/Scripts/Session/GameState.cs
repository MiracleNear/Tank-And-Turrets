using UnityEngine;

namespace Session
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] private EndScreen _defeatScreen, _victoryScreen;
        [SerializeField] private Canvas _canvas;

        public void ShowVictoryScreen()
        {
            Show(_victoryScreen);
        }

        public void ShowDefeatScreen()
        {
            Show(_defeatScreen);
        }
        
        private void Show(EndScreen endScreen)
        {
            endScreen.Show();
            _canvas.gameObject.SetActive(true);
        }
    }
}
