using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisFinal.Models;
using System.Collections.Generic;

namespace TetrisFinalTests {
    [TestClass]
    public class GameBoard_Tests {
        [TestMethod]
        public void WillPointsFit_ValidPoints() {
            GameBoard gb = new GameBoard();
            var points = new List<Point>();
            
            gb.Set(1, 1, new Point(1, 1));
            gb.Set(1, 2, new Point(1, 2));
            
            points.Add(new Point(2, 3));
            points.Add(new Point(3, 4));

            Assert.IsTrue(gb.WillPointsFit(points));
        }

        [TestMethod]
        public void WillPointsFit_InvalidPoints_Overlapping() {
            GameBoard gb = new GameBoard();
            var points = new List<Point>();

            gb.Set(1, 1, new Point(1, 1));
            gb.Set(1, 2, new Point(1, 2));

            points.Add(new Point(1, 1));
            points.Add(new Point(3, 4));

            Assert.IsFalse(gb.WillPointsFit(points));
        }

        [TestMethod]
        public void WillPointsFit_InvalidPoints_OutOfBounds() {
            GameBoard gb = new GameBoard();
            var points = new List<Point>();

            gb.Set(1, 1, new Point(1, 1));
            gb.Set(1, 2, new Point(1, 2));

            points.Add(new Point(-1, 2));
            points.Add(new Point(0, 4));

            Assert.IsFalse(gb.WillPointsFit(points));
        }

        [TestMethod]
        public void WillPointsFitExemptions_ValidPoints() {
            GameBoard gb = new GameBoard();
            var points = new List<Point>();
            var exemptPoints = new List<Point>();

            gb.Set(1, 1, new Point(1, 1));
            gb.Set(1, 2, new Point(1, 2));

            points.Add(new Point(1, 2));
            points.Add(new Point(0, 4));
            points.Add(new Point(0, 5));

            exemptPoints.Add(new Point(1, 2));
            exemptPoints.Add(new Point(0, 0));

            Assert.IsTrue(gb.WillPointsFit(points, exemptPoints));
        }

        [TestMethod]
        public void WillPointsFitExemptions_InvalidPoints_NotInExemptions() {
            var gb = new GameBoard();
            var points = new List<Point>();
            var exemptPoints = new List<Point>();

            gb.Set(1, 1, new Point(1, 1));
            gb.Set(1, 2, new Point(1, 2));

            points.Add(new Point(1, 2));
            points.Add(new Point(0, 4));
            points.Add(new Point(0, 5));

            exemptPoints.Add(new Point(6, 5));
            exemptPoints.Add(new Point(0, 0));

            Assert.IsFalse(gb.WillPointsFit(points, exemptPoints));
        }

        [TestMethod]
        public void FindLines_HasLines_ShouldDetectLines() {
            var gb = ConfigureGameboardWithLines();
            var expectedResult = new List<int> { GameBoard.GAMEBOARD_HEIGHT - 2, GameBoard.GAMEBOARD_HEIGHT - 1 };
            var actualResult = gb.FindLines();

            for (int i = 0; i < expectedResult.Count; i++) {
                Assert.AreEqual(expectedResult[i], actualResult[i]);
            }
        }

        [TestMethod]
        public void FindLines_NoLines_ShouldNotFindAny() {
            var gb = ConfigureGameboardWithPoints();

            Assert.AreEqual(0, gb.FindLines().Count);
        }


        // ~~~ METHODS TO CONFIGURE UNIT TESTS BELOW ~~~

        public GameBoard ConfigureGameboardWithPoints() {
            var gb = new GameBoard();

            gb.Set(1, 1, new Point(1, 1));
            gb.Set(1, 2, new Point(1, 2));

            return gb;
        }
        
        public GameBoard ConfigureGameboardWithLines() {
            // Set the last two rows to be full of blocks
            GameBoard gb = new GameBoard();
            for (int i = 0; i < GameBoard.GAMEBOARD_WIDTH; i++) {
                gb.Set(i, GameBoard.GAMEBOARD_HEIGHT - 2, new Point(i, GameBoard.GAMEBOARD_HEIGHT - 2));
                gb.Set(i, GameBoard.GAMEBOARD_HEIGHT - 1, new Point(i, GameBoard.GAMEBOARD_HEIGHT - 1));
            }

            return gb;
        }
    }
}
