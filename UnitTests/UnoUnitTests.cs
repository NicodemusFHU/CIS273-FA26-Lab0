using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uno;

namespace UnitTests
{
    [TestClass]
    [TestCategory("Uno")]
    public class UnoUnitTests
    {
        [TestMethod]
        public void TestCardMembers()
        {
            var card = new Card();
            card.Color = Color.Red;
            card.Color = Color.Blue;
            card.Color = Color.Green;
            card.Color = Color.Yellow;

            card.Number = 5;

            card.Type = CardType.Number;
            card.Type = CardType.Wild;
            card.Type = CardType.WildDraw4;
            card.Type = CardType.Skip;
            card.Type = CardType.Reverse;

        }

        [TestMethod]
        public void TestCardToString()
        {
            var card = new Card();
            card.Color = Color.Red;
            card.Number = 5;

            string expected = "Red 5";
            Assert.AreEqual(expected, card.ToString());

            card.Color = Color.Blue;
            card.Number = null;
            card.Type = CardType.Reverse;

            expected = "Blue Reverse";
            Assert.AreEqual(expected, card.ToString());

            card.Color = Color.Yellow;
            card.Type = CardType.Skip;

            expected = "Yellow Skip";
            Assert.AreEqual(expected, card.ToString());

            card.Color = Color.Wild;
            card.Type = CardType.WildDraw4;

            expected = "WildDraw4";
            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void TestCardPlaysOn()
        {

            var red5 = new Card();
            red5.Color = Color.Red;
            red5.Number = 5;

            var red9 = new Card();
            red9.Color = Color.Red;
            red9.Number = 9;

            var blue9 = new Card();
            blue9.Color = Color.Blue;
            blue9.Number = 9;

            var yellow2 = new Card();
            yellow2.Color = Color.Yellow;
            yellow2.Number = 2;

            var green1 = new Card();
            green1.Color = Color.Green;
            green1.Number = 1;


            Assert.IsTrue(Card.PlaysOn(red5, red9));
            Assert.IsTrue(Card.PlaysOn(red9, blue9));
            Assert.IsTrue(Card.PlaysOn(red9, red9));

            Assert.IsFalse(Card.PlaysOn(red5, blue9));
            Assert.IsFalse(Card.PlaysOn(yellow2, red5));
            Assert.IsFalse(Card.PlaysOn(yellow2, blue9));

            var blueReverse = new Card() { Type = CardType.Reverse, Color = Color.Blue };
            var greenReverse = new Card() { Type = CardType.Reverse, Color = Color.Green };

            Assert.IsTrue(Card.PlaysOn(blueReverse, blue9));
            Assert.IsTrue(Card.PlaysOn(greenReverse, blueReverse));
            Assert.IsFalse(Card.PlaysOn(greenReverse, red5));

            var redSkip = new Card() { Type = CardType.Skip, Color = Color.Red };
            var blueSkip = new Card() { Type = CardType.Skip, Color = Color.Blue };


            Assert.IsTrue(Card.PlaysOn(redSkip, red9));
            Assert.IsTrue(Card.PlaysOn(blueSkip, redSkip));
            Assert.IsFalse(Card.PlaysOn(blueSkip, red5));

            var redDraw2 = new Card() { Type = CardType.Draw2, Color = Color.Red };
            var greenDraw2 = new Card() { Type = CardType.Draw2, Color = Color.Green };
            Assert.IsTrue(Card.PlaysOn(redDraw2, red9));
            Assert.IsTrue(Card.PlaysOn(greenDraw2, redDraw2));
            Assert.IsFalse(Card.PlaysOn(greenDraw2, red5));


            var wild = new Card() { Type = CardType.Wild };
            var wilddraw4 = new Card() { Type = CardType.WildDraw4 };

            Assert.IsTrue(Card.PlaysOn(wild, red9));
            Assert.IsTrue(Card.PlaysOn(wild, blueReverse));
            Assert.IsTrue(Card.PlaysOn(wild, blueSkip));
            Assert.IsTrue(Card.PlaysOn(wild, greenDraw2));
            Assert.IsTrue(Card.PlaysOn(wild, wilddraw4));

            Assert.IsTrue(Card.PlaysOn(red9, wild));
            Assert.IsTrue(Card.PlaysOn(blueReverse, wild));
            Assert.IsTrue(Card.PlaysOn(blueSkip, wild));
            Assert.IsTrue(Card.PlaysOn(greenDraw2, wild));
            Assert.IsTrue(Card.PlaysOn(wilddraw4, wild));

            Assert.IsTrue(Card.PlaysOn(red9, wilddraw4));
            Assert.IsTrue(Card.PlaysOn(blueReverse, wilddraw4));
            Assert.IsTrue(Card.PlaysOn(blueSkip, wild));
            Assert.IsTrue(Card.PlaysOn(greenDraw2, wild));
            Assert.IsTrue(Card.PlaysOn(wilddraw4, wild));

        }

        [TestMethod]
        public void TestCardPlaysOnWithCurrentColor()
        {
            var yellow7 = new Card() { Type = CardType.Number, Number = 7, Color = Color.Yellow };
            var red9 = new Card() { Type = CardType.Number, Number = 9, Color = Color.Red };
            var wild = new Card() { Type = CardType.Wild, Color = Color.Wild };
            var wilddraw4 = new Card() { Type = CardType.WildDraw4, Color = Color.Wild };

            // A colored card only plays on a wild card if it matches the declared current color.
            Assert.IsTrue(Card.PlaysOn(yellow7, wild, Color.Yellow));
            Assert.IsFalse(Card.PlaysOn(yellow7, wild, Color.Blue));

            Assert.IsTrue(Card.PlaysOn(red9, wilddraw4, Color.Red));
            Assert.IsFalse(Card.PlaysOn(red9, wilddraw4, Color.Green));

            // Wild cards are always playable on a wild card, regardless of the declared color.
            Assert.IsTrue(Card.PlaysOn(wild, wilddraw4, Color.Blue));
            Assert.IsTrue(Card.PlaysOn(wilddraw4, wild, Color.Green));
        }

        [TestMethod]
        public void TestPlayer()
        {
            var player = new Player();
            player.Name = "Josh Smith";
            player.Hand.Add(new Card() { Type = CardType.Number, Number = 2, Color = Color.Green });

            Assert.AreEqual("Josh Smith", player.Name);
        }

        [TestMethod]
        public void TestPlayerHasPlayableCard()
        {
            var red5 = new Card() { Color = Color.Red, Number = 5, Type = CardType.Number };
            var red9 = new Card() { Color = Color.Red, Number = 9, Type = CardType.Number };
            var blue9 = new Card() { Color = Color.Blue, Number = 9, Type = CardType.Number };
            var yellow2 = new Card() { Color = Color.Yellow, Number = 2, Type = CardType.Number };
            var green1 = new Card() { Color = Color.Green, Number = 1, Type = CardType.Number };
            var blueReverse = new Card() { Type = CardType.Reverse, Color = Color.Blue };
            var greenReverse = new Card() { Type = CardType.Reverse, Color = Color.Green };
            var redSkip = new Card() { Type = CardType.Skip, Color = Color.Red };
            var blueSkip = new Card() { Type = CardType.Skip, Color = Color.Blue };
            var redDraw2 = new Card() { Type = CardType.Draw2, Color = Color.Red };
            var greenDraw2 = new Card() { Type = CardType.Draw2, Color = Color.Green };
            var wild = new Card() { Type = CardType.Wild };
            var wilddraw4 = new Card() { Type = CardType.WildDraw4 };

            Card[] cards1 = { red5, red9, blue9, green1, redSkip };

            var player = new Player();
            player.Hand.AddRange(cards1);

            Assert.IsTrue(player.HasPlayableCard(new Card() { Color = Color.Yellow, Number = 9, Type = CardType.Number }));
            Assert.IsTrue(player.HasPlayableCard(new Card() { Color = Color.Green, Number = 4, Type = CardType.Number }));
            Assert.IsTrue(player.HasPlayableCard(new Card() { Color = Color.Blue, Type = CardType.Draw2 }));
            Assert.IsTrue(player.HasPlayableCard(new Card() { Color = Color.Blue, Type = CardType.Skip }));
            Assert.IsTrue(player.HasPlayableCard(new Card() { Color = Color.Yellow, Type = CardType.Skip }));
            Assert.IsTrue(player.HasPlayableCard(new Card() { Type = CardType.Wild }));
            Assert.IsTrue(player.HasPlayableCard(new Card() { Type = CardType.WildDraw4 }));

            Assert.IsFalse(player.HasPlayableCard(new Card() { Color = Color.Yellow, Number = 4 }));
            Assert.IsFalse(player.HasPlayableCard(new Card() { Color = Color.Yellow, Type = CardType.Draw2 }));

        }

        [TestMethod]
        public void TestPlayerGetFirstPlayableCard()
        {
            var red5 = new Card() { Color = Color.Red, Number = 5, Type = CardType.Number };
            var red9 = new Card() { Color = Color.Red, Number = 9, Type = CardType.Number };
            var blue9 = new Card() { Color = Color.Blue, Number = 9, Type = CardType.Number };
            var yellow2 = new Card() { Color = Color.Yellow, Number = 2, Type = CardType.Number };
            var green1 = new Card() { Color = Color.Green, Number = 1, Type = CardType.Number };
            var blueReverse = new Card() { Type = CardType.Reverse, Color = Color.Blue };
            var greenReverse = new Card() { Type = CardType.Reverse, Color = Color.Green };
            var redSkip = new Card() { Type = CardType.Skip, Color = Color.Red };
            var blueSkip = new Card() { Type = CardType.Skip, Color = Color.Blue };
            var redDraw2 = new Card() { Type = CardType.Draw2, Color = Color.Red };
            var greenDraw2 = new Card() { Type = CardType.Draw2, Color = Color.Green };
            var wild = new Card() { Type = CardType.Wild };
            var wilddraw4 = new Card() { Type = CardType.WildDraw4 };

            Card[] cards1 = { red5, red9, blue9, green1, redSkip };

            var player = new Player();
            player.Hand.AddRange(cards1);

            Assert.AreEqual(red9, player.GetFirstPlayableCard(new Card() { Color = Color.Yellow, Number = 9, Type = CardType.Number }));
            Assert.AreEqual(green1, player.GetFirstPlayableCard(new Card() { Color = Color.Green, Number = 4, Type = CardType.Number }));
            Assert.AreEqual(blue9, player.GetFirstPlayableCard(new Card() { Color = Color.Blue, Type = CardType.Draw2 }));
            Assert.AreEqual(blue9, player.GetFirstPlayableCard(new Card() { Color = Color.Blue, Type = CardType.Skip }));
            Assert.AreEqual(redSkip, player.GetFirstPlayableCard(new Card() { Color = Color.Yellow, Type = CardType.Skip }));
            Assert.AreEqual(red5, player.GetFirstPlayableCard(new Card() { Type = CardType.Wild }));
            Assert.AreEqual(red5, player.GetFirstPlayableCard(new Card() { Type = CardType.WildDraw4 }));

            Assert.IsNull(player.GetFirstPlayableCard(new Card() { Color = Color.Yellow, Number = 4, Type = CardType.Number }));
            Assert.IsNull(player.GetFirstPlayableCard(new Card() { Color = Color.Yellow, Type = CardType.Draw2 }));

        }


        [TestMethod]
        public void TestPlayerMostCommonColor()
        {
            var red5 = new Card() { Color = Color.Red, Number = 5, Type = CardType.Number };
            var red9 = new Card() { Color = Color.Red, Number = 9, Type = CardType.Number };
            var blue9 = new Card() { Color = Color.Blue, Number = 9, Type = CardType.Number };
            var yellow2 = new Card() { Color = Color.Yellow, Number = 2, Type = CardType.Number };
            var green1 = new Card() { Color = Color.Green, Number = 1, Type = CardType.Number };
            var blueReverse = new Card() { Type = CardType.Reverse, Color = Color.Blue };
            var greenReverse = new Card() { Type = CardType.Reverse, Color = Color.Green };
            var redSkip = new Card() { Type = CardType.Skip, Color = Color.Red };
            var blueSkip = new Card() { Type = CardType.Skip, Color = Color.Blue };
            var redDraw2 = new Card() { Type = CardType.Draw2, Color = Color.Red };
            var greenDraw2 = new Card() { Type = CardType.Draw2, Color = Color.Green };
            var wild = new Card() { Type = CardType.Wild };
            var wilddraw4 = new Card() { Type = CardType.WildDraw4 };

            Card[] cards1 = { red5, red9, blue9, green1, redSkip };

            var player = new Player();
            player.Hand.AddRange(cards1);

            Assert.AreEqual(Color.Red, player.MostCommonColor());

            player.Hand.Clear();
            Card[] cards2 = { red5, blue9, blueSkip };
            player.Hand.AddRange(cards2);
            Assert.AreEqual(Color.Blue, player.MostCommonColor());


            player.Hand.Clear();
            Card[] cards3 = { red5, blue9, green1 };
            player.Hand.AddRange(cards3);
            Assert.AreEqual(Color.Red, player.MostCommonColor());
        }

        [TestMethod]
        public void TestGame()
        {
            var game = new UnoGame();

            game.DiscardStack.Add(new Card() { Type = CardType.Number, Number = 2, Color = Color.Green });
            game.DrawStack.Add(new Card() { Type = CardType.Number, Number = 4, Color = Color.Green });
            game.Players.Add(new Player() { Name = "Bob Boberson" });

            Assert.AreEqual(1, game.DiscardStack.Count);
            Assert.AreEqual(1, game.DrawStack.Count);
            Assert.AreEqual(1, game.Players.Count);

        }
    }
}
