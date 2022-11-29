using UnityEngine;

namespace Gameplay
{
    public class Tracking : MonoBehaviour
    {
        [SerializeField] private Transform _keepTrackTo;

        private void Update()
        {
            transform.LookAt(_keepTrackTo.position);
        }
    }
}
