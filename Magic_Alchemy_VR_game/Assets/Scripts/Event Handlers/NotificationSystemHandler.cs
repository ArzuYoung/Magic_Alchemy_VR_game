using Gameplay;
using Gameplay.Order;
using UnityEngine;

namespace EventHandlers
{
    [RequireComponent(typeof(NotificationSystem))]
    public class NotificationSystemHandler : MonoBehaviour
    {
        [SerializeField] private float _showingCashTime;

        private NotificationSystem _notificationSystem;

        private void Awake()
        {
            _notificationSystem = GetComponent<NotificationSystem>();
        }

        private void OnEnable()
        {
            Order.CashGetted += ShowCash;
        }

        private void OnDisable()
        {
            Order.CashGetted -= ShowCash;
        }

        private void ShowCash(int value)
        {
            _notificationSystem.Show($"Заказ выполнен.\nПолучено {value} монет.", _showingCashTime);
        }
    }
}
