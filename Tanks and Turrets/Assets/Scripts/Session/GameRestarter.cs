using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Session
{
    public class GameRestarter : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private string _activeSceneName;

        private void Awake()
        {
            _button.onClick.AddListener(Restart);

            _activeSceneName = SceneManager.GetActiveScene().name;
        }
        
        private void Restart()
        {
            SceneManager.LoadScene(_activeSceneName);
        }
    }
}