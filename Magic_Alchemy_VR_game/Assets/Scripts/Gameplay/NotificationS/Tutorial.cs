using UnityEngine;
using System.Collections.Generic;

namespace Gameplay.Notifications
{
    [RequireComponent(typeof(NotificationSystem))]
    public class Tutorial : MonoBehaviour
    {
        private NotificationSystem _notificationSystem;

        private List<Queue<(string Text, bool ContinueOnClick)>> _tutorialTexts;
        private Queue<(string Text, bool ContinueOnClick)> _currentTutorial;

        public bool TutorialDone { get; private set; }

        public void Next()
        {
            if (_currentTutorial == null || TutorialDone)
                return;

            if (_currentTutorial.Count == 0 && _tutorialTexts.IndexOf(_currentTutorial) == _tutorialTexts.Count - 1)
            {
                _notificationSystem.Hide();
                TutorialDone = true;
                return;
            }

            (var text, var continueOnClick) = _currentTutorial.Dequeue();
            _notificationSystem.Show(text, continueOnClick);
        }

        public void Next(int tutorialIndex)
        {
            if (TutorialDone || tutorialIndex <= _tutorialTexts.IndexOf(_currentTutorial))
                return;

            _currentTutorial = _tutorialTexts[tutorialIndex];
            Next();
        }

        private void Awake()
        {
            _notificationSystem = GetComponent<NotificationSystem>();

            var tutorialTextsPart1 = new Queue<(string, bool)>();
            tutorialTextsPart1.Enqueue(("Привет! Это игра “Magic Alchemy”.", true));
            tutorialTextsPart1.Enqueue(("Тебе надо выполнять заказы, чтобы накопить монеты на покупку философского камня.", true));
            tutorialTextsPart1.Enqueue(("Давай попробуем реализовать первый заказ!", true));
            tutorialTextsPart1.Enqueue(("Для начала возьми необходимые элементы и создай своё первое соединение.", true));
            tutorialTextsPart1.Enqueue(("P.S. Рецепты в нашей игре аналогичны мобильному приложению “Алхимик”.", false));

            var tutorialTextsPart2 = new Queue<(string, bool)>();
            tutorialTextsPart2.Enqueue(("Молодец!", true));
            tutorialTextsPart2.Enqueue(("Помни о том, что если ты попытаешься получить несуществующее соединение, то произойдёт взрыв!", true));
            tutorialTextsPart2.Enqueue(("Посмотри! На доске новый заказ.", true));
            tutorialTextsPart2.Enqueue(("Ты можешь положить соединение в сундук, чтобы проверить правильность выполнения заказа.", false));

            var tutorialTextsPart3 = new Queue<(string, bool)>();
            tutorialTextsPart3.Enqueue(("Что-то пошло не так. Возможно, необходимо реализовать другое соединение.", false));

            var tutorialTextsPart4 = new Queue<(string, bool)>();
            tutorialTextsPart4.Enqueue(("Ура! Первый заказ выполнен согласно требованиям.", true));
            tutorialTextsPart4.Enqueue(("Помести сундук с соединением на платформу в углу комнаты.", false));

            var tutorialTextsPart5 = new Queue<(string, bool)>();
            tutorialTextsPart5.Enqueue(("Не забудь нажать на красную кнопку для отправки заказа.", false));

            var tutorialTextsPart6 = new Queue<(string, bool)>();
            tutorialTextsPart6.Enqueue(("Вот и выполнен первый заказ. Продолжай в том же духе. Удачи!", true));

            _tutorialTexts = new List<Queue<(string, bool)>>
            {
                tutorialTextsPart1,
                tutorialTextsPart2,
                tutorialTextsPart3,
                tutorialTextsPart4,
                tutorialTextsPart5,
                tutorialTextsPart6,
            };

            Next(0);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab) && _notificationSystem.CanSkip)
                Next();
        }
    }
}
