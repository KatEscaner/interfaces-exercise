using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        List<Item> Items;
        public GildedRose(List<Item> Items) {
            this.Items = Items;
        }

        public void UpdateQuality( ) {
            foreach(Item item in Items ) {
                Delegate itemDelegate = ItemResources.GetItemAction( item.Name );
                itemDelegate.DynamicInvoke( item );
            }
        }
    }
}
