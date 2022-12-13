using Gameplay.Notifications;
using Gameplay.Order;
using System;
using UI;
using UnityEngine;

namespace EventHandlers
{
    [RequireComponent(typeof(NotificationSystem))]
    public class NotificationSystemHandler : MonoBehaviour
    {
        [SerializeField] private float _showingCashTime;

        private NotificationSystem _notificationSystem;

        public static event Func<bool> TutorialDone;

        private void Awake()
        {
            _notificationSystem = GetComponent<NotificationSystem>();
        }

        private void OnEnable()
        {
            Order.CashGetted += ShowCash;
            PhilosopherStoneBoard.Purchased += ShowCongratulation;
        }

        private void OnDisable()
        {
            Order.CashGetted -= ShowCash;
            PhilosopherStoneBoard.Purchased -= ShowCongratulation;
        }

        private void ShowCash(int value)
        {
            var tutorialDone = TutorialDone?.Invoke();
            if (tutorialDone.GetValueOrDefault())
                _notificationSystem.Show($"Заказ выполнен.\nПолучено {value} монет.", _showingCashTime);
        }

        private void ShowCongratulation()
        {
            _notificationSystem.Show($"Поздравялем! Вы достигли цели. Благодарим за прохождение демо-версии “Magic Alchemy”!", true);
        }
    }
}
