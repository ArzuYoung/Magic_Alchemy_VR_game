using Gameplay;
using Gameplay.Order;
using UnityEngine;

namespace EventHandlers
{
    [RequireComponent(typeof(SpawnPoint))]
    public class SpawnBoxHandler : MonoBehaviour
    {
        private SpawnPoint _spawnPoint;

        private void Awake()
        {
            _spawnPoint = GetComponent<SpawnPoint>();
        }

        private void OnEnable()
        {
            SendingButton.OrderDone += _spawnPoint.Spawn;
        }

        private void OnDisable()
        {
            SendingButton.OrderDone -= _spawnPoint.Spawn;
        }
    }
}
