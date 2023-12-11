using csharp;

namespace Test {
    public class Tests {
        Item item;
        [ SetUp]
        public void Setup( ) {
            item = new Item();
            item.Name = "default";
        }

        [Test]
        public void TestDefaultItem1( ) {
            item.SellIn = 2;
            item.Quality = 3;

            Delegate itemDelegate = ItemResources.GetItemAction( item.Name );
            itemDelegate.DynamicInvoke( item );

            Assert.Multiple( ( ) => {
                Assert.That( item.SellIn, Is.EqualTo(1)  );
                Assert.That( item.Quality, Is.EqualTo( 3 ) );
            } );
        }

        [Test]
        public void TestDefaultItem2( ) {
            item.SellIn = 1;
            item.Quality = 3;

            Delegate itemDelegate = ItemResources.GetItemAction( item.Name );
            itemDelegate.DynamicInvoke( item );

            Assert.Multiple( ( ) => {
                Assert.That( item.SellIn, Is.EqualTo( 0 ) );
                Assert.That( item.Quality, Is.EqualTo( 2 ) );
            } );
        }
        
        [Test]
        public void TestDefaultItem3( ) {
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