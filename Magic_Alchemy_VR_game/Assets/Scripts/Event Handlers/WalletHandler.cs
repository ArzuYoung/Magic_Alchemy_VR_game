using Gameplay.Order;
using UI;
using UnityEngine;

namespace EventHandlers
{
    [RequireComponent(typeof(Wallet))]
    public class WalletHandler : MonoBehaviour
    {
        private Wallet _wallet;

        private void Awake()
        {
            _wallet = GetComponent<Wallet>();
        }

        private void OnEnable()
        {
            Order.CashGetted += _wallet.AddCoints;
        }

        private void OnDisable()
        {
            Order.CashGetted -= _wallet.AddCoints;
        }
    }
}
