using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shop.Runtime
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private ShopItem shopItemPrefab;
        [SerializeField] private Transform itemListParent;
        [SerializeField] private List<ShopItemConfig> items;
        private itemPreview lastItemPreview;
        private void Start()
        {
            foreach (var config in items)
            {
                var shopItem = Instantiate(shopItemPrefab, itemListParent);
                config.Apply(shopItem);
                shopItem.OnSelect += ChangePreview;
            }
        }

        private void ChangePreview(ShopItem newShopItemSelected)
        {
            
        }

        [Serializable]
        private struct ShopItemConfig
        {
            [field: SerializeField] public Item Item { get; set; }
            [field: SerializeField] public int Cost { get; set; }
            [field: SerializeField] public bool IsSold { get; set; }

            public void Apply(ShopItem shopItem)
            {
                shopItem.Item = Item;
                shopItem.Cost = Cost;
                shopItem.IsSold = IsSold;
            }
        }
        private struct itemPreview
        {
            public SpriteRenderer target;
            public Sprite before;
            public Sprite after;
        }
    }
}
