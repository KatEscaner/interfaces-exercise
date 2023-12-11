using csharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {
    class UnitTestBackstagePasses {
        Item item;
        [SetUp]
        public void Setup( ) {
            item = new Item( );
            item.Name = "Backstage passes to a TAFKAL80ETC concert";
        }

        [Test]
        public void TestBackstagePasses1( ) {
            item.SellIn = 12;
            item.Quality = 3;

            Delegate itemDelegate = ItemResources.GetItemAction( item.Name );
            itemDelegate.DynamicInvoke( item );

            Assert.Multiple( ( ) => {
                Assert.That( item.SellIn, Is.EqualTo( 11 ) );
                Assert.That( item.Quality, Is.EqualTo( 4 ) );
            } );
        }

        [Test]
        public void TestBackstagePasses2( ) {
            item.SellIn = 10;
            item.Quality = 3;

            Delegate itemDelegate = ItemResources.GetItemAction( item.Name );
            itemDelegate.DynamicInvoke( item );

            Assert.Multiple( ( ) => {
                Assert.That( item.SellIn, Is.EqualTo( 9 ) );
                Assert.That( item.Quality, Is.EqualTo( 5 ) );
            } );
        }

        [Test]
        public void TestBackstagePasses3( ) {
            item.SellIn = 5;
            item.Quality = 3;

            Delegate itemDelegate = ItemResources.GetItemAction( item.Name );
            itemDelegate.DynamicInvoke( item );

            Assert.Multiple( ( ) => {
                Assert.That( item.SellIn, Is.EqualTo( 4 ) );
                Assert.That( item.Quality, Is.EqualTo( 6 ) );
            } );
        }
        
        [Test]
        public void TestBackstagePasses4( ) {
            item.SellIn = 1;
            item.Quality = 3;

            Delegate itemDelegate = ItemResources.GetItemAction( item.Name );
            itemDelegate.DynamicInvoke( item );

            Assert.Multiple( ( ) => {
                Assert.That( item.SellIn, Is.EqualTo( 0 ) );
                Assert.That( item.Quality, Is.EqualTo( 0 ) );
            } );
        }
    }
}
