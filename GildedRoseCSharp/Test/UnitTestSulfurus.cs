using csharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {
    class UnitTestSulfurus {
        Item item;
        [SetUp]
        public void Setup( ) {
            item = new Item( );
            item.Name = "Sulfuras, Hand of Ragnaros";
        }

        [Test]
        public void TestSulfuras1( ) {
            item.SellIn = 2;
            item.Quality = 3;

            Delegate itemDelegate = ItemResources.GetItemAction( item.Name );
            itemDelegate.DynamicInvoke( item );

            Assert.Multiple( ( ) => {
                Assert.That( item.SellIn, Is.EqualTo( 0 ) );
                Assert.That( item.Quality, Is.EqualTo( 80 ) );
            } );
        }

        [Test]
        public void TestSulfuras2( ) {
            item.SellIn = 1;
            item.Quality = 3;

            Delegate itemDelegate = ItemResources.GetItemAction( item.Name );
            itemDelegate.DynamicInvoke( item );

            Assert.Multiple( ( ) => {
                Assert.That( item.SellIn, Is.EqualTo( 0 ) );
                Assert.That( item.Quality, Is.EqualTo( 80 ) );
            } );
        }

        [Test]
        public void TestSulfuras3( ) {
            item.SellIn = 0;
            item.Quality = 3;

            Delegate itemDelegate = ItemResources.GetItemAction( item.Name );
            itemDelegate.DynamicInvoke( item );

            Assert.Multiple( ( ) => {
                Assert.That( item.SellIn, Is.EqualTo( 0 ) );
                Assert.That( item.Quality, Is.EqualTo( 80 ) );
            } );
        }
    }
}
