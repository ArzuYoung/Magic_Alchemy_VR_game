using System.Collections;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class NotificationSystem : MonoBehaviour
    {
        [SerializeField] private GameObject _notificationPanel;
        [SerializeField] private TextMeshProUGUI _text;

        private Coroutine _hideCoroutine;

        public void Show(string text)
        {
            _text.text = text;
            _notificationPanel.SetActive(true);
        }

        public void Show(string text, float hideTime)
        {
            Show(text);
            _hideCoroutine = StartCoroutine(Hide(hideTime));
        }

        public void Hide() => _hideCoroutine = StartCoroutine(Hide(0));

        private void Awake()
        {
            gameObject.SetActive(false);
            Show("Добро пожаловать!", 5f);
        }

        private IEnumerator Hide(float afterSeconds)
        {
            yield return new WaitForSeconds(afterSeconds);
            _notificationPanel.SetActive(false);
        }
    }
}