using UI;
using UnityEngine;

namespace EventHandlers
{
    [RequireComponent(typeof(PhilosopherStoneBoard))]
    public class PhilosopherStoneBoardHandler : MonoBehaviour
    {
        private PhilosopherStoneBoard _board;

        private void Awake()
        {
            _board = GetComponent<PhilosopherStoneBoard>();
        }

        private void OnEnable()
        {
            Wallet.CoinsCountChanged += _board.CheckButtonInteractable;
        }

        private void OnDisable()
        {
            Wallet.CoinsCountChanged -= _board.CheckButtonInteractable;
        }
    }
}
