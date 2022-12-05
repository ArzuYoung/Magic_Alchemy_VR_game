using Gameplay.Elements;
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Order
{
    public class Box : MonoBehaviour
    {
        [SerializeField] private Light _light;
        [SerializeField] private Color _wrongColor;
        [SerializeField] private Color _correctColor;
        [SerializeField] private float _checkingRadius;

        public static event Func<ElementType> GetCurrentOrder;

        public bool OrderIsCorrect { get; private set; }

        public void RemoveContent()
        {
            var colliders = Physics.OverlapSphere(transform.position, _checkingRadius);
            foreach (var collider in colliders)
            {
                if (collider.GetComponent<ElementsMerging>() != null)
                    Destroy(collider.gameObject);
            }
        }

        private void Start()
        {
            SetWorngColor();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!OrderExists() && OrderIsCorrect) return;
            if (other.TryGetComponent<ElementsMerging>(out var element))
            {
                var currentOrder = GetCurrentOrder?.Invoke();
                if (element.Type == currentOrder.GetValueOrDefault())
                {
                    SetCorrectColor();
                    OrderIsCorrect = true;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!OrderExists()) return;
            if (other.TryGetComponent<ElementsMerging>(out var element))
            {
                var currentOrder = GetCurrentOrder?.Invoke();
                if (element.Type == currentOrder.GetValueOrDefault())
                {
                    SetWorngColor();
                    OrderIsCorrect = false;
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, _checkingRadius);
        }

        private bool OrderExists()
        {
            var currentOrder = GetCurrentOrder?.Invoke();
            if (currentOrder.GetValueOrDefault() == ElementType.None)
                return false;
            return true;
        }

        private void SetWorngColor()
        {
            _light.color = _wrongColor;
        }

        private void SetCorrectColor()
        {
            _light.color = _correctColor;
        }
    }
}
