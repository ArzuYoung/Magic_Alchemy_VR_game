using UnityEngine;

namespace Servive
{
    /// <summary>
    /// Генерирует указанные служебные объекты после старта сцены в точке (0, 0, 0).
    /// </summary>
    public class AutoGeneration : MonoBehaviour
    {
        [SerializeField] private GameObject[] _generatedObjects;

        private void Awake()
        {
            foreach (var obj in _generatedObjects)
                Instantiate(obj, Vector3.zero, Quaternion.identity);
        }
    }
}