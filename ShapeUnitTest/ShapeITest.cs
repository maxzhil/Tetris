using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;

namespace ShapeIUnitTest
{
    /// <summary>
    /// Тестовый класс
    /// </summary>
    [TestClass]
    public class ShapeITest
    {
        /// <summary>
        /// Инициализация экземпляра класса
        /// </summary>
        ShapeI _shapeI;

        /// <summary>
        /// Тестирование некорректного значения поворота
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RotationIncorrectValueTest()
        {
            _shapeI = new ShapeI();
            _shapeI.Rotation = 5;
            
        }
        /// <summary>
        /// Тестирование отрицательного значения поворота
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RotatioтNegativeValueTest()
        {
            _shapeI = new ShapeI();
            _shapeI.Rotation = -1;

        }
        /// <summary>
        /// Тестирование некорректного значения координаты y
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void YIncorrectValueTest()
        {
            _shapeI = new ShapeI();
            _shapeI.Y = 17;
        }
        /// <summary>
        /// Тестирование отрицательного значения координаты y
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void YNegativeValueTest()
        {
            _shapeI = new ShapeI();
            _shapeI.Y = -1;
        }
        /// <summary>
        /// Тестирование некорректного значения координаты x
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void XIncorrectValueTest()
        {
            _shapeI = new ShapeI();
            _shapeI.X = 11;
        }
        /// <summary>
        /// Тестирование отрицательного значения координаты x
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void XNegativeValueTest()
        {
            _shapeI = new ShapeI();
            _shapeI.X = -2;
        }
        /// <summary>
        /// Тестирование корректного значения следующей координаты y
        /// </summary>
        [TestMethod]
        public void NextRotationYCorrectValueTest()
        {
            _shapeI = new ShapeI();
            int expected = _shapeI.Y + 1;
            int actual = _shapeI.NextRotationY();
            Assert.AreEqual(expected,actual);
        }
        /// <summary>
        /// Тестирование некорректного значения следующей координаты y
        /// </summary>
        [TestMethod]
        public void NextRotationYIncorrectValueTest()
        {
            _shapeI = new ShapeI();
            _shapeI.Rotation = 2;
            int expected = 1;
            int actual = _shapeI.NextRotationY();
            Assert.AreNotEqual(expected, actual);
        }
        /// <summary>
        /// Тестирование корректного значения следующей координаты x
        /// </summary>
        [TestMethod]
        public void NextRotationXCorrectValueTest()
        {
            _shapeI = new ShapeI();
            int expected = _shapeI.X - 1;
            int actual = _shapeI.NextRotationX();
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Тестирование метода получения матрицы при повороте
        /// </summary>
        [TestMethod]
        public void NextRotationCorrectValueTest()
        {
            _shapeI = new ShapeI();
            int[,] expected =  new int[1, 4]
            {
                { 1, 1, 1, 1 }
            };
            int[,] actual= _shapeI.NextRotation(_shapeI.Rotation);
            Assert.AreEqual(expected.ToString(),actual.ToString());
        }
        /// <summary>
        /// Тестирование метода вращения, проверяется правильно ли меняется координата х
        /// </summary>
        [TestMethod]
        public void WheelXChangeTest()
        {
            _shapeI = new ShapeI();
            int oldX = _shapeI.X;
            _shapeI.Wheel();
            int newX = _shapeI.X;
            Assert.IsTrue(oldX > newX);
        }
        /// <summary>
        /// Тестирование метода вращения, проверяется правильно ли меняется  координата y
        /// </summary>
        [TestMethod]
        public void WheelYChangeTest()
        {
            _shapeI = new ShapeI();
            int oldY = _shapeI.Y;
            _shapeI.Wheel();
            int newY = _shapeI.Y;
            Assert.IsTrue(oldY < newY);
        }
      
    }
}
