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

        private ElementType GetCurrentOrder() => _order.CurrentOrder;
    }
}