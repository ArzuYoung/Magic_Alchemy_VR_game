using Gameplay.Order;
using UnityEngine;

namespace EventHandlers
{
    [RequireComponent(typeof(SendingArea))]
    public class SendingAreaHandler : MonoBehaviour
    {
        private SendingArea _sendingArea;

        private void Awake()
        {
            _sendingArea = GetComponent<SendingArea>();
        }

        private void OnEnable()
        {
            SendingButton.OrderCollected += ReadyToSend;
            SendingButton.OrderDone += _sendingArea.Remove;
        }

        private void OnDisable()
        {
            SendingButton.OrderCollected -= ReadyToSend;
            SendingButton.OrderDone -= _sendingArea.Remove;
        }

        private bool ReadyToSend() => _sendingArea.ReadyToSend;
    }
}
