using Gameplay.Elements;
using Gameplay.Notifications;
using Gameplay.Order;
using UI;
using UnityEngine;

namespace EventHandlers
{
    [RequireComponent(typeof(Tutorial))]
    public class TutorialHandler : MonoBehaviour
    {
        private Tutorial _tutorial;

        private void Awake()
        {
            _tutorial = GetComponent<Tutorial>();
        }

        private void OnEnable()
        {
            ElementsMerging.ElementsMerged += StartTutorialChest;
            Box.WrongElement += StartTutorialWrongElement;
            Box.CorrectElement += StartTutorialTeleport;
            SendingButton.OrderDone += StartTutorialEnd;
            NotificationSystemHandler.TutorialDone += TutorialDone;
        }

        private void OnDisable()
        {
            ElementsMerging.ElementsMerged -= StartTutorialChest;
            Box.WrongElement -= StartTutorialWrongElement;
            Box.CorrectElement -= StartTutorialTeleport;
            SendingButton.OrderDone -= StartTutorialEnd;
            NotificationSystemHandler.TutorialDone -= TutorialDone;
        }

        private void StartTutorialChest() => _tutorial.Next(1);

        private void StartTutorialWrongElement() => _tutorial.Next(2);

        private void StartTutorialTeleport() => _tutorial.Next(3);

        private void StartTutorialEnd() => _tutorial.Next(4);

        private bool TutorialDone() => _tutorial.TutorialDone;
    }
}