using Player;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Tank _target;
    [SerializeField] private Vector3 _offset;

    private void OnValidate()
    {
        transform.position = _target.transform.position + _offset;
    }

    private void LateUpdate()
    {
        if (_target != null)
        {
            Vector3 positionTarget = new Vector3(0, _target.transform.position.y, _target.transform.position.z);
            Vector3 nextPosition = positionTarget + _offset;

            transform.position = nextPosition;
        }
    }
}
