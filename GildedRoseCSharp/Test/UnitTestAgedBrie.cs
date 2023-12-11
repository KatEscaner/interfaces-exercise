using csharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {
    class UnitTestAgedBrie {
        Item item;
        [SetUp]
        public void Setup( ) {
            item = new Item( );
            item.Name = "Aged Brie";
        }

        [Test]
        public void TestAgedBrie1( ) {
            item.SellIn = 2;
            item.Quality = 3;

            Delegate itemDelegate = ItemResources.GetItemAction( item.Name );
            itemDelegate.DynamicInvoke( item );

            Assert.Multiple( ( ) => {
                Assert.That( item.SellIn, Is.EqualTo( 1 ) );
                Assert.That( item.Quality, Is.EqualTo( 4 ) );
            } );
        }

        [Test]
        public void TestAgedBrie2( ) {
            item.SellIn = 1;
            item.Quality = 3;

            Delegate itemDelegate = ItemResources.GetItemAction( item.Name );
            itemDelegate.DynamicInvoke( item );

            Assert.Multiple( ( ) => {
                Assert.That( item.SellIn, Is.EqualTo( 0 ) );
                Assert.That( item.Quality, Is.EqualTo( 5 ) );
            } );
        }

        [Test]
        public void TestAgedBrie3( ) {
            item.SellIn = 0;
            item.Quality = 3;

            Delegate itemDelegate = ItemResources.GetItemAction( item.Name );
            itemDelegate.DynamicInvoke( item );

            Assert.Multiple( ( ) => {
                Assert.That( item.SellIn, Is.EqualTo( 0 ) );
                Assert.That( item.Quality, Is.EqualTo( 5 ) );
            } );
        }
    }
}
