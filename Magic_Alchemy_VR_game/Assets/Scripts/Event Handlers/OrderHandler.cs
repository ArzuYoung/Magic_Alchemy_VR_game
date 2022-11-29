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
            SendingButton.OrderDone += _order.Generate;
        }

        private void OnDisable()
        {
            Box.GetCurrentOrder -= GetCurrentOrder;
            SendingButton.OrderDone -= _order.Generate;
        }

        private KeyValuePair<ElementType, int> GetCurrentOrder() => _order.CurrentOrder;

        private void FinishOrder()
        {

            _order.Generate();
        }
    }
}