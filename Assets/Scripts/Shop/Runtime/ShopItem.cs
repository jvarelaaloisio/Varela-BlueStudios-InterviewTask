using System;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.Runtime
{
    [RequireComponent(typeof(Button))]
    public class ShopItem : MonoBehaviour
    {
        [field: SerializeField] public bool IsSold { get; set; }
        [field: SerializeField] public int Cost { get; set; }
        [field: SerializeField] public Item Item { get; set; }
        
        private Button _button;

        /// <summary>
        /// Event risen when the button for this item is selected
        /// </summary>
        public event Action<ShopItem> OnSelect = delegate { };

        /// <summary>
        /// Event risen when the user tries to buy the item
        /// </summary>
        public event Action<ShopItem> OnWantToBuy = delegate { };

        /// <summary>
        /// Event risen when this item's button is pressed and it can be used (either is bought right now or was bought before).
        /// </summary>
        public event Action<ShopItem> OnUse = delegate { };

        private void Reset()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(HandleInteraction);
            _button.onClick.AddListener(HandleSelected);
        }

        private void HandleSelected()
        {
            OnSelect(this);
        }

        private void HandleInteraction()
        {
            if (IsSold)
            {
                OnUse(this);
            }
            OnWantToBuy(this);
        }

        public bool TryGet(Wallet wallet, out Item item)
        {
            if (wallet.TrySpend(Cost))
            {
                item = this.Item;
                return true;
            }

            item = null;
            return false;
        }

        public bool TrySell(Wallet wallet)
        {
            if (!IsSold)
                return false;
            wallet.Deposit(Cost);
            return true;

        }
    }
}
