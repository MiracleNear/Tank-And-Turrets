using UnityEngine;
using UnityEngine.UI;

namespace HealthSystem
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image _lifeBar;

        public void UpdateBar(float amount)
        {
            _lifeBar.fillAmount = amount;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}