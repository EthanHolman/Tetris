using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisFinal.Services;
using TetrisFinal.Models;
using System.Collections.Generic;

namespace TetrisFinalTests {
    [TestClass]
    public class Game_Tests {
        [TestMethod]
        public void TranslatePoints_MoveDown() {
            Game g = new Game();
            g.InitGame();

            var points = new List<Point>();
            points.Add(new Point(2, 1));
            points.Add(new Point(2, 2));
            points.Add(new Point(3, 1));

            var points_down = g.TranslatePoints(points, MoveDirection.Down);
            
            var pointsShouldBe_down = new List<Point>();
            pointsShouldBe_down.Add(new Point(2, 2));
            pointsShouldBe_down.Add(new Point(2, 3));
            pointsShouldBe_down.Add(new Point(3, 2));
            
            for(int i = 0; i < pointsShouldBe_down.Count; i++) {
                Assert.AreEqual(pointsShouldBe_down[i], points_down[i]);
            }
        }

        [TestMethod]
        public void TranslatePoints_MoveLeft() {
            Game g = new Game();
            g.InitGame();

            var points = new List<Point>();
            points.Add(new Point(2, 1));
            points.Add(new Point(2, 2));
            points.Add(new Point(3, 1));

            var points_left = g.TranslatePoints(points, MoveDirection.Left);

            var pointsShouldBe_left = new List<Point>();
            pointsShouldBe_left.Add(new Point(1, 1));
            pointsShouldBe_left.Add(new Point(1, 2));
            pointsShouldBe_left.Add(new Point(2, 1));

            for(int i = 0; i < pointsShouldBe_left.Count; i++) {
                Assert.AreEqual(pointsShouldBe_left[i], points_left[i]);
            }
        }

        [TestMethod]
        public void TranslatePoints_MoveRight() {
            Game g = new Game();
            g.InitGame();

            var points = new List<Point>();
            points.Add(new Point(2, 1));
            points.Add(new Point(2, 2));
            points.Add(new Point(3, 1));

            var points_right = g.TranslatePoints(points, MoveDirection.Right);

            var pointsShouldBe_right = new List<Point>();
            pointsShouldBe_right.Add(new Point(3, 1));
            pointsShouldBe_right.Add(new Point(3, 2));
            pointsShouldBe_right.Add(new Point(4, 1));

            for(int i = 0; i < pointsShouldBe_right.Count; i++) {
                Assert.AreEqual(pointsShouldBe_right[i], points_right[i]);
            }
        }
    }
}
