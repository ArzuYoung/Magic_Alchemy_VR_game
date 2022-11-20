using UnityEngine;
using System;

namespace Gameplay.Elements
{
    public class ElementsMerging : MonoBehaviour
    {
        [SerializeField] private ElementType _type;

        public ElementType Type { get => _type; }
        public bool Active { get; private set; }

        public static event Func<ElementType, ElementType, ElementType> GetMergeElement;
        public static event Func<ElementType, GameObject> GetElementPrefab;

        private void OnCollisionEnter(Collision collision)
        {
            var other = collision.gameObject.GetComponent<ElementsMerging>();
            if (other == null || other.Active)
                return;

            Active = true;
            var resultElementTypeNullable = GetMergeElement?.Invoke(_type, other.Type);
            var resultElementType = resultElementTypeNullable.GetValueOrDefault(ElementType.None);

            Destroy(gameObject);
            Destroy(other.gameObject);

            if (resultElementType == ElementType.None)
                return;

            CreateNew(resultElementType);
        }

        private void CreateNew(ElementType type)
        {
            var element = GetElementPrefab?.Invoke(type);
            Instantiate(element, transform.position, Quaternion.identity);
        }
    }

}