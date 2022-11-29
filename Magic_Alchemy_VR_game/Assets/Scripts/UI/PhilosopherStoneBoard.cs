using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PhilosopherStoneBoard : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private Image _stoneImage;
        [SerializeField] private Image _coinImage;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Sprite _markSprite;
        [SerializeField] private int _cost = 100;

        private bool _sold = false;

        public static event Func<int> GetCoinsCount;
        public static event Action<int> AddCoins;

        public void CheckButtonInteractable(int coins)
        {
            if (_sold) return;
            _buyButton.interactable = coins >= _cost;
        }

        private void Awake()
        {
            var coins = GetCoinsCount?.Invoke();
            CheckButtonInteractable(coins.GetValueOrDefault());

            _buyButton.onClick.AddListener(Buy);
        }

        private void Buy()
        {
            _sold = true;
            AddCoins?.Invoke(-_cost);
            _titleText.text = "�����������!";
            _costText.gameObject.SetActive(false);
            _coinImage.gameObject.SetActive(false);
            _buyButton.gameObject.SetActive(false);
            _stoneImage.sprite = _markSprite;
        }
    }
}
