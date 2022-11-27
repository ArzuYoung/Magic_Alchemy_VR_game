using UnityEngine;
using Gameplay.Elements;
using Gameplay.Order;

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
            Order.GetElementSprite += _elementsStorage.GetSprite;
        }

        private void OnDisable()
        {
            ElementsMerging.GetElementPrefab -= _elementsStorage.GetPrefab;
            ElementSource.GetElementPrefab -= _elementsStorage.GetPrefab;
            Order.GetElementSprite -= _elementsStorage.GetSprite;
        }
    }

}