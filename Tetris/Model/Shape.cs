using System.Drawing;


namespace Tetris
{
    /// <summary>
    /// Форма фигуры
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Вращение по х
        /// </summary>
        /// <returns></returns>
        public abstract int NextRotationX();
        /// <summary>
        /// Вращение по у
        /// </summary>
        /// <returns></returns>
        public abstract int NextRotationY();
        /// <summary>
        /// Следующий поворот
        /// </summary>
        /// <param name="parDirectionRotation">Направление вращения</param>
        /// <returns></returns>
        public abstract int[,] NextRotation(int parDirectionRotation);
        /// <summary>
        /// Вращение по кругу
        /// </summary>
        public abstract void Wheel();
        /// <summary>
        /// Координата x
        /// </summary>
        public abstract int X
        {
            get;
            set;
        }
        /// <summary>
        /// Координата y
        /// </summary>
        public abstract int Y
        {
            get;
            set;
        }
        /// <summary>
        /// Сокращенное обозначение фигуры
        /// </summary>
        public abstract char Name
        {
            get;
        }
        /// <summary>
        /// Изображение
        /// </summary>
        public abstract Image Image
        {
            get;
        }
        /// <summary>
        /// Шаблон для получения конкретного положения относительно поворота
        /// </summary>
        public abstract int[,] Pattern
        {
            get;
        }
        /// <summary>
        /// Поворот
        /// </summary>
        public abstract int Rotation
        {
            get;
            set;
        }
    }

}
