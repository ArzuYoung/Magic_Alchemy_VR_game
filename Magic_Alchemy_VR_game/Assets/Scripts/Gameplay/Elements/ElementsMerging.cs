using UnityEngine;
using System;

namespace Gameplay.Elements
{
    public class ElementsMerging : MonoBehaviour
    {
        [SerializeField] private ElementType _type;
        [SerializeField] private Sprite _icon;
        [SerializeField] private float _explosionForce;
        [SerializeField] private float _explosionRadius;

        public ElementType Type { get => _type; }
        public bool Active { get; private set; }
        public Sprite Sprite { get => _icon; }

        public static event Func<ElementType, ElementType, ElementType> GetMergeElement;
        public static event Func<ElementType, GameObject> GetElementPrefab;
        public static event Action ElementsMerged;

        private void OnCollisionEnter(Collision collision)
        {
            var other = collision.gameObject.GetComponent<ElementsMerging>();
            if (other == null || other.Active)
                return;

            Active = true;
            var resultElementTypeNullable = GetMergeElement?.Invoke(_type, other.Type);
            var resultElementType = resultElementTypeNullable.GetValueOrDefault(ElementType.None);

            ElementsMerged?.Invoke();
            Destroy(gameObject);
            Destroy(other.gameObject);

            if (resultElementType == ElementType.None)
            {
                DoExplosion();
                return;
            }

            CreateNew(resultElementType);

        }

        private void CreateNew(ElementType type)
        {
            var element = GetElementPrefab?.Invoke(type);
            Instantiate(element, transform.position, Quaternion.identity);
        }

        private void DoExplosion()
        {
            var colliders = Physics.OverlapSphere(transform.position, _explosionRadius);
            foreach (var collider in colliders)
            {
                var rb = collider.GetComponent<Rigidbody>();
                if (rb != null)
                    rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, 5f);
            }
        }
    }

}