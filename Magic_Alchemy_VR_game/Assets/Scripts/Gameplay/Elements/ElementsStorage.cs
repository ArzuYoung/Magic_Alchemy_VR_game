using UnityEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine.XR.Interaction.Toolkit;

namespace Gameplay.Elements
{
    public class ElementsStorage : MonoBehaviour
    {
        public static ElementsStorage Instance;
        
        [SerializeField] private ElementsMerging[] _elements;

        private readonly Dictionary<ElementType, ElementsMerging> _elementsDictionary = new();

        public GameObject GetPrefab(ElementType type) => _elementsDictionary[type].gameObject;

        public Sprite GetSprite(ElementType type) => _elementsDictionary[type].Sprite;

        private void Awake()
        {
            foreach (var element in _elements)
                _elementsDictionary.Add(element.Type, element);
        }

        private void Start()
        {
            if (Instance == null)
                Instance = this;
        }
    }
}