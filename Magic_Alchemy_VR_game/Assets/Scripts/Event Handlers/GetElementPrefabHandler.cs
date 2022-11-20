using UnityEngine;
using Gameplay.Elements;

namespace EventHandlers
{
    [RequireComponent(typeof(ElementsStorage))]
    public class GetElementPrefabHandler : MonoBehaviour
    {
        private ElementsStorage _elementsStorage;

        private void Awake()
        {
            _elementsStorage = GetComponent<ElementsStorage>();
        }

        private void OnEnable()
        {
            ElementsMerging.GetElementPrefab += _elementsStorage.GetPrefab;
            ElementSource.GetElementPrefab += _elementsStorage.GetPrefab;
        }

        private void OnDisable()
        {
            ElementsMerging.GetElementPrefab -= _elementsStorage.GetPrefab;
            ElementSource.GetElementPrefab -= _elementsStorage.GetPrefab;
        }
    }

}