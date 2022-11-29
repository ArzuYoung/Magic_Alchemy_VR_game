using Servive;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Order
{
    public class Order : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _name;

        private ElementType[] _possibleOrders = new[]
        {
            ElementType.Wind,
            ElementType.Lava,
            ElementType.Rock,
            ElementType.Cloud,
            ElementType.Grass,
            ElementType.Lake,
            ElementType.Steam,
            ElementType.Warm
        };

        public static event Func<ElementType, Sprite> GetElementSprite;
        public static event Func<ElementType, int> GetElementCost;
        public static event Action<int> CashGetted;

        public KeyValuePair<ElementType, int> CurrentOrder { get; private set; } = new KeyValuePair<ElementType, int>(ElementType.None, 0);

        public void Generate()
        {
            var randomElementType = _possibleOrders[UnityEngine.Random.Range(0, _possibleOrders.Length)];
            _image.sprite = GetElementSprite?.Invoke(randomElementType);
            _name.text = Translation.GetElementName(randomElementType);

            var cost = GetElementCost?.Invoke(randomElementType);
            CurrentOrder = new KeyValuePair<ElementType, int>(randomElementType, cost.GetValueOrDefault());
        }

        public void GetCash() => CashGetted?.Invoke(CurrentOrder.Value);

        private void Start()
        {
            Generate();
        }
    }
}