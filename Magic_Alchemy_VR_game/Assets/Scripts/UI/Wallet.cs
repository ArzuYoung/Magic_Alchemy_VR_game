using UnityEngine;
using TMPro;
using System;

namespace UI
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _value;
        [SerializeField] private int _coinsCount;

        public int CoinsCount { get => _coinsCount; }

        public static Action<int> CoinsCountChanged;

        public void AddCoints(int value)
        {
            _coinsCount = Mathf.Clamp(_coinsCount + value, 0, int.MaxValue);
            UpdateText();
            CoinsCountChanged?.Invoke(CoinsCount);
        }

        public void SetCoints(int value)
        {
            _coinsCount = Mathf.Clamp(value, 0, int.MaxValue);
            UpdateText();
            CoinsCountChanged?.Invoke(CoinsCount);
        }

        private void Awake()
        {
            UpdateText();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
                AddCoints(10);
        }

        private void UpdateText() => _value.text = CoinsCount.ToString();
    }
}