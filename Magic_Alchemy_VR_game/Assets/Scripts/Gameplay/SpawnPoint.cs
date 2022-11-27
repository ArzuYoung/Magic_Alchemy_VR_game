using UnityEngine;

namespace Gameplay
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private GameObject _spawnedPrefab;

        public void Spawn()
        {
            Instantiate(_spawnedPrefab, transform.position, transform.rotation, transform.parent);
        }
    }
}