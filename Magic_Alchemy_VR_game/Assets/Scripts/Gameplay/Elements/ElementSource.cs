using UnityEngine;
using System;

namespace Gameplay.Elements
{
    public class ElementSource : MonoBehaviour
    {
        [SerializeField] private ElementType _type;

        public static event Func<ElementType, GameObject> GetElementPrefab;

        public GameObject GetPrefab() => GetElementPrefab?.Invoke(_type);
    }
}
