using Servive;
using System;
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

        public ElementType CurrentOrder { get; private set; } = ElementType.None;

        public void Generate()
        {
            var randomElementType = _possibleOrders[UnityEngine.Random.Range(0, _possibleOrders.Length)];
            _image.sprite = GetElementSprite?.Invoke(randomElementType);
            _name.text = Translation.GetElementName(randomElementType);
            CurrentOrder = randomElementType;
        }

        private void Start()
        {
            Generate();
        }
    }
}