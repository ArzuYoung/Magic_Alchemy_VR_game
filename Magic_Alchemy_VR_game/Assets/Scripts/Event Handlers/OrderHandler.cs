using Gameplay.Order;
using UnityEngine;

namespace EventHandlers
{
    [RequireComponent(typeof(Order))]
    public class OrderHandler : MonoBehaviour
    {
        private Order _order;

        private void Awake()
        {
            _order = GetComponent<Order>();
        }

        private void OnEnable()
        {
            Box.GetCurrentOrder += GetCurrentOrder;
            SendingButton.OrderDone += _order.Generate;
        }

        private void OnDisable()
        {
            Box.GetCurrentOrder -= GetCurrentOrder;
            SendingButton.OrderDone -= _order.Generate;
        }

        private ElementType GetCurrentOrder() => _order.CurrentOrder;
    }
}