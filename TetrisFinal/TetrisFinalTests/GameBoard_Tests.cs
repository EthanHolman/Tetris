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
            
            gb.Set(1, 1, new Point(1, 1, "green"));
            gb.Set(1, 2, new Point(1, 2, "green"));
            
            points.Add(new Point(2, 3));
            points.Add(new Point(3, 4));

            Assert.IsTrue(gb.WillPointsFit(points));
        }

        [TestMethod]
        public void WillPointsFit_InvalidPoints_Overlapping() {
            GameBoard gb = new GameBoard();
            var points = new List<Point>();

            gb.Set(1, 1, new Point(1, 1, "green"));
            gb.Set(1, 2, new Point(1, 2, "green"));

            points.Add(new Point(1, 1));
            points.Add(new Point(3, 4));

            Assert.IsFalse(gb.WillPointsFit(points));
        }

        [TestMethod]
        public void WillPointsFit_InvalidPoints_OutOfBounds() {
            GameBoard gb = new GameBoard();
            var points = new List<Point>();

            gb.Set(1, 1, new Point(1, 1, "green"));
            gb.Set(1, 2, new Point(1, 2, "green"));

            points.Add(new Point(-1, 2));
            points.Add(new Point(0, 4));

            Assert.IsFalse(gb.WillPointsFit(points));
        }

        [TestMethod]
        public void WillPointsFitExemptions_ValidPoints() {
            GameBoard gb = new GameBoard();
            var points = new List<Point>();
            var exemptPoints = new List<Point>();

            gb.Set(1, 1, new Point(1, 1, "green"));
            gb.Set(1, 2, new Point(1, 2, "blue"));

            points.Add(new Point(1, 2));
            points.Add(new Point(0, 4));
            points.Add(new Point(0, 5));

            exemptPoints.Add(new Point(1, 2, "blue"));
            exemptPoints.Add(new Point(0, 0));

            Assert.IsTrue(gb.WillPointsFit(points, exemptPoints));
        }

        [TestMethod]
        public void WillPointsFitExemptions_InvalidPoints_NotInExemptions() {
            GameBoard gb = new GameBoard();
            var points = new List<Point>();
            var exemptPoints = new List<Point>();

            gb.Set(1, 1, new Point(1, 1, "green"));
            gb.Set(1, 2, new Point(1, 2, "blue"));

            points.Add(new Point(1, 2));
            points.Add(new Point(0, 4));
            points.Add(new Point(0, 5));

            exemptPoints.Add(new Point(6, 5, "blue"));
            exemptPoints.Add(new Point(0, 0));

            Assert.IsFalse(gb.WillPointsFit(points, exemptPoints));
        }
    }
}
