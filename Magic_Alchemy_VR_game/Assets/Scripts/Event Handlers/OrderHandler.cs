using Gameplay.Order;
using System.Collections.Generic;
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
            SendingButton.OrderDone += FinishOrder;
        }

        private void OnDisable()
        {
            Box.GetCurrentOrder -= GetCurrentOrder;
            SendingButton.OrderDone -= FinishOrder;
        }

        private KeyValuePair<ElementType, int> GetCurrentOrder() => _order.CurrentOrder;

        private void FinishOrder()
        {
            _order.GetCash();
            _order.Generate();
        }
    }
}