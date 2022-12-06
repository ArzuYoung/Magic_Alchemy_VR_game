using System.Collections;
using TMPro;
using UnityEngine;

namespace Gameplay.Notifications
{
    public class NotificationSystem : MonoBehaviour
    {
        [SerializeField] private GameObject _notificationPanel;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private TextMeshProUGUI _clickText;

        private Coroutine _hideCoroutine;

        public bool CanSkip { get => _clickText.gameObject.activeSelf; }

        public void Show(string text, bool canSkip = false)
        {
            _text.text = text;
            _notificationPanel.SetActive(true);
            _clickText.gameObject.SetActive(canSkip);
        }

        public void Show(string text, float hideTime, bool canSkip = false)
        {
            Show(text, canSkip);
            _hideCoroutine = StartCoroutine(Hide(hideTime));
        }

        public void Hide() => _hideCoroutine = StartCoroutine(Hide(0));

        private void Awake()
        {
            //Show("Добро пожаловать!", 5f);
            //gameObject.SetActive(false);
        }

        private IEnumerator Hide(float afterSeconds)
        {
            yield return new WaitForSeconds(afterSeconds);
            _notificationPanel.SetActive(false);
        }
    }
}