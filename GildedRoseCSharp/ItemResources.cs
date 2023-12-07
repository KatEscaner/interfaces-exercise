using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp {
    class ItemResources {
        private static readonly Dictionary<string, Action<Item>> ItemDelegates = new Dictionary<string, Action<Item>>( );

        static ItemResources( ) {
            Initialize( );
        }

        private static void Initialize( ) {
            ItemDelegates[ "Aged Brie" ] = item => {
                item.SellIn = Math.Max( 0, item.SellIn - 1 );
                item.Quality += ( item.SellIn > 0 ) ? 1 : 2;
                item.Quality = Math.Min( 50, item.Quality );
            };

            ItemDelegates[ "Backstage passes to a TAFKAL80ETC concert" ] = item => {
                item.SellIn = Math.Max( 0, item.SellIn - 1 );
                if ( item.SellIn == 0 ) {
                    item.Quality = 0;
                } else {
                    item.Quality += ( item.SellIn <= 5 ) ? 3 : ( item.SellIn <= 10 ) ? 2 : 1;
                    item.Quality = Math.Min( 50, item.Quality );
                }
            };

            ItemDelegates[ "Sulfuras, Hand of Ragnaros" ] = item => {
                item.SellIn = 0;
                item.Quality = 80;
            };

            ItemDelegates[ "Conjured Mana Cake" ] = item => {
                item.SellIn = Math.Max( 0, item.SellIn - 2 );
                if ( item.SellIn == 0 ) {
                    item.Quality -= 1;
                    item.Quality = Math.Max( 0, item.Quality );
                }
            };
        }

        public static Action<Item> GetItemAction( string name ) {
            return ItemDelegates.TryGetValue( name, out var itemDelegate ) ? itemDelegate : DefaultItemAction;
        }

        private static readonly Action<Item> DefaultItemAction = item => {
            item.SellIn = Math.Max( 0, item.SellIn - 1 );
            if ( item.SellIn == 0 ) {
                item.Quality -= 1;
                item.Quality = Math.Max( 0, item.Quality );
            }
        };
    }
}
