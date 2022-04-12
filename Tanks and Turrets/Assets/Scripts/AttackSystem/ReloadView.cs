using UnityEngine;
using UnityEngine.UI;

namespace AttackSystem
{
    public class ReloadView : MonoBehaviour
    {
        [SerializeField] private Text _reloadPresenter;
        [SerializeField] private GameObject _reloadContainer;
        
        private Color _color;
        private IReload _reload;

        private void OnValidate()
        {
            if (_reloadContainer != null && _reloadContainer.GetComponent<IReload>() == null)
            {
                _reload = null;
            }
        }

        private void Awake()
        {
            _color = _reloadPresenter.color;
            _reload = _reloadContainer.GetComponent<IReload>();
        }

        private void OnEnable()
        {
            _reload.Started += OnStarted;
            _reload.Ended += OnEnded;
            _reload.Tick += OnTick;
        }

        private void OnTick()
        {
            _color.a = _reload.CurrentTime / _reload.MaxTime;

            _reloadPresenter.color = _color;
        }

        private void OnEnded()
        {
            _reloadPresenter.gameObject.SetActive(false);
        }

        private void OnStarted()
        {
            _color.a = 1f;
            
            _reloadPresenter.gameObject.SetActive(true);
        }
    }
}