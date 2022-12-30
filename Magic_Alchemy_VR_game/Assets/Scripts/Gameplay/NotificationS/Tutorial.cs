using System;
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

        private void Start()
        {
            InputHandler.Instance.OnRightUiPressedButton_Down.AddListener(()=>
            {
                if(_notificationSystem.CanSkip)
                    Next();
            });
            
            InputHandler.Instance.OnLeftUiPressedButton_Down.AddListener(()=>
            {
                if(_notificationSystem.CanSkip)
                    Next();
            });
        }

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
            tutorialTextsPart1.Enqueue(("������! ��� ���� �Magic Alchemy�.", true));
            tutorialTextsPart1.Enqueue(("���� ���� ��������� ������, ����� �������� ������ �� ������� ������������ �����.", true));
            tutorialTextsPart1.Enqueue(("����� ��������� ����������� ������ �����!", true));
            tutorialTextsPart1.Enqueue(("��� ������ ������ ����������� �������� � ������ ��� ������ ����������.", true));
            tutorialTextsPart1.Enqueue(("P.S. ������� � ����� ���� ���������� ���������� ���������� ��������.", false));

            var tutorialTextsPart2 = new Queue<(string, bool)>();
            tutorialTextsPart2.Enqueue(("�������!", true));
            tutorialTextsPart2.Enqueue(("����� � ���, ��� ���� �� ����������� �������� �������������� ����������, �� ��������� �����!", true));
            tutorialTextsPart2.Enqueue(("��������! �� ����� ����� �����.", true));
            tutorialTextsPart2.Enqueue(("�� ������ �������� ���������� � ������, ����� ��������� ������������ ���������� ������.", false));

            var tutorialTextsPart3 = new Queue<(string, bool)>();
            tutorialTextsPart3.Enqueue(("���-�� ����� �� ���. ��������, ���������� ����������� ������ ����������.", false));

            var tutorialTextsPart4 = new Queue<(string, bool)>();
            tutorialTextsPart4.Enqueue(("���! ������ ����� �������� �������� �����������.", true));
            tutorialTextsPart4.Enqueue(("� ������ ����� �� ������� ������ ��� �������� ������.", false));

            var tutorialTextsPart5 = new Queue<(string, bool)>();
            tutorialTextsPart5.Enqueue(("��� � �������� ������ �����. ��������� � ��� �� ����. �����!", true));

            var tutorialTextsPart6 = new Queue<(string, bool)>();
            tutorialTextsPart6.Enqueue(("�����������! ���� ����������. ���������� �� ����������� ����-������ �Magic Alchemy�!", true));

            _tutorialTexts = new List<Queue<(string, bool)>>
            {
                tutorialTextsPart1,
                tutorialTextsPart2,
                tutorialTextsPart3,
                tutorialTextsPart4,
                tutorialTextsPart5,
            };

            Next(0);
        }
    }
}
