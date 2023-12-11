using csharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {
    class UnitTestConjured {
        Item item;
        [SetUp]
        public void Setup( ) {
            item = new Item( );
            item.Name = "Conjured Mana Cake";
        }

        [Test]
        public void TestConjuredItem1( ) {
            item.SellIn = 3;
            item.Quality = 3;

            Delegate itemDelegate = ItemResources.GetItemAction( item.Name );
            itemDelegate.DynamicInvoke( item );

            Assert.Multiple( ( ) => {
                Assert.That( item.SellIn, Is.EqualTo( 1 ) );
                Assert.That( item.Quality, Is.EqualTo( 3 ) );
            } );
        }

        [Test]
        public void TestConjuredItem2( ) {
            item.SellIn = 2;
            item.Quality = 3;

            Delegate itemDelegate = ItemResources.GetItemAction( item.Name );
            itemDelegate.DynamicInvoke( item );

            Assert.Multiple( ( ) => {
                Assert.That( item.SellIn, Is.EqualTo( 0 ) );
                Assert.That( item.Quality, Is.EqualTo( 2 ) );
            } );
        }

        [Test]
        public void TestConjuredItem3( ) {
            item.SellIn = 0;
            item.Quality = 3;

            Delegate itemDelegate = ItemResources.GetItemAction( item.Name );
            itemDelegate.DynamicInvoke( item );

            Assert.Multiple( ( ) => {
                Assert.That( item.SellIn, Is.EqualTo( 0 ) );
                Assert.That( item.Quality, Is.EqualTo( 2 ) );
            } );
        }
    }
}
