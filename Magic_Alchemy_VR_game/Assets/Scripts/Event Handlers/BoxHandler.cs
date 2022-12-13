using Gameplay.Order;
using UnityEngine;

namespace EventHandlers
{
    [RequireComponent(typeof(Box))]
    public class BoxHandler : MonoBehaviour
    {
        private Box _box;

        private void Awake()
        {
            _box = GetComponent<Box>();
        }

        private void OnEnable()
        {
            SendingButton.OrderDone += _box.RemoveContent;
            SendingButton.OrderCollected += OrderIsCorrect;
        }

        private void OnDisable()
        {
            SendingButton.OrderDone -= _box.RemoveContent;
            SendingButton.OrderCollected -= OrderIsCorrect;
        }

        private bool OrderIsCorrect() => _box.OrderIsCorrect;
    }
}