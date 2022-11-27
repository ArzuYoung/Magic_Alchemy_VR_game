using System;
using UnityEngine;

namespace Gameplay.Order
{
    public class SendingButton : MonoBehaviour
    {
        public static event Func<bool> OrderCollected;
        public static event Action OrderDone;

        private void OnTriggerEnter(Collider other)
        {
            var orderCollected = OrderCollected?.Invoke();
            if (orderCollected.GetValueOrDefault())
                OrderDone?.Invoke();
        }
    }
}
