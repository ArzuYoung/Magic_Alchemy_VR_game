using System;
using UnityEngine;

namespace Gameplay.Order
{
    public class SendingArea : MonoBehaviour
    {
        [SerializeField] private Light _light;
        [SerializeField] private float _lightIntensityBusy;
        [SerializeField] private float _lightIntensityNotBusy;

        private Box _box;

        public static event Action BoxFixed;

        public bool Busy { get => _box != null; }

        public bool ReadyToSend
        {
            get
            {
                if (!Busy)
                    return false;
                return _box.OrderIsCorrect;
            }
        }

        public void Remove()
        {
            if (!Busy)
                return;

            _box.RemoveContent();
            Destroy(_box.gameObject);
            SetLightIntensity(_lightIntensityNotBusy);
        }

        private void Start()
        {
            SetLightIntensity(_lightIntensityNotBusy);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Box>(out var box) && _box == null)
            {
                _box = box;
                SetLightIntensity(_lightIntensityBusy);
                BoxFixed?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<Box>(out var box) && _box != null && box.GetHashCode() == _box.GetHashCode())
            {
                _box = null;
                SetLightIntensity(_lightIntensityNotBusy);
            }
        }

        private void SetLightIntensity(float value) => _light.intensity = value;
    }
}