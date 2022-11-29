using UnityEngine;
using Gameplay.Elements;
using Gameplay.Order;

namespace EventHandlers
{
    [RequireComponent(typeof(ElementsGuide))]
    public class ElementsGuideHandler : MonoBehaviour
    {
        private ElementsGuide _elementsGuide;

        private void Awake()
        {
            _elementsGuide = GetComponent<ElementsGuide>();
        }

        private void OnEnable()
        {
            ElementsMerging.GetMergeElement += _elementsGuide.GetElementBy;
            Order.GetElementCost += _elementsGuide.GetCost;
        }

        private void OnDisable()
        {
            ElementsMerging.GetMergeElement -= _elementsGuide.GetElementBy;
            Order.GetElementCost -= _elementsGuide.GetCost;
        }
    }

}