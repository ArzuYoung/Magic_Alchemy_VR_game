using UnityEngine;
using TMPro;

namespace UI
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _value;

        public int CoinsCount { get; private set; } = 0;

        private void Awake()
        {
            UpdateText();
        }

        public void AddCoints(int value)
        {
            CoinsCount += value;
            UpdateText();
        }

        public void SetCoints(int value)
        {
            CoinsCount = value;
            UpdateText();
        }

        private void UpdateText() => _value.text = CoinsCount.ToString();
    }
}