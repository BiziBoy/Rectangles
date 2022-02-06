using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
      // так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top
      //if ((r1.Left <= r2.Left && r2.Left <= r1.Right) && (r1.Top <= r2.Top && r2.Top <= r1.Bottom) ||
      //       (r1.Left <= r2.Right && r2.Right <= r1.Right) && (r1.Top <= r2.Top && r2.Top <= r1.Bottom) ||
      //       (r1.Left <= r2.Right && r2.Right <= r1.Right) && (r1.Top <= r2.Bottom && r2.Bottom <= r1.Bottom) ||
      //       (r1.Left <= r2.Left && r2.Left <= r1.Right) && (r1.Top <= r2.Bottom && r2.Bottom <= r1.Bottom) ||
      //       (r2.Left <= r1.Left && r1.Left <= r2.Right) && (r2.Top <= r1.Top && r1.Top <= r2.Bottom) ||
      //       (r2.Left <= r1.Right && r1.Right <= r2.Right) && (r2.Top <= r1.Top && r1.Top <= r2.Bottom) ||
      //       (r2.Left <= r1.Right && r1.Right <= r2.Right) && (r2.Top <= r1.Bottom && r1.Bottom <= r2.Bottom) ||
      //       (r2.Left <= r1.Left && r1.Left <= r2.Right) && (r2.Top <= r1.Bottom && r1.Bottom <= r2.Bottom))
      //{
      //  return true;
      //}
      //else if ((r2.Left <= r1.Right && r1.Right <= r2.Right) || (r1.Left <= r2.Right && r2.Right <= r1.Right) ||
      //         (r2.Left <= r1.Left && r1.Left <= r2.Right) || (r1.Left <= r2.Left && r2.Left <= r1.Right) ||
      //         (r2.Top <= r1.Bottom && r1.Bottom <= r2.Bottom) || (r1.Top <= r2.Bottom && r2.Bottom <= r1.Bottom) ||
      //         (r2.Top <= r1.Top && r1.Top <= r2.Bottom) || (r1.Top <= r2.Top && r2.Top <= r1.Bottom))
      //{
      //  return true;
      //}
      //else
      //{
      //  return false;
      //}
      bool intersectedForX = false;
      bool intersectedForY = false;
      // цыклы ищут, есть ли хоть одна точка которая пренадлежит обоим прямоугольникам
      for (int i = r1.Left; i <= r1.Left + r1.Width; i++)
      {
        for (int y = r2.Left; y <= r2.Left + r2.Width; y++)
        {
          if (i == y)
            intersectedForX = true;
        }
      }

      for (int i = r1.Top; i <= r1.Top + r1.Height; i++)
      {
        for (int y = r2.Top; y <= r2.Top + r2.Height; y++)
        {
          if (i == y)
            intersectedForY = true;
        }
      }

      return intersectedForX == intersectedForY && intersectedForX;
    }

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
			int left = Math.Max(r1.Left, r2.Left);
			int top = Math.Min(r1.Bottom, r2.Bottom);
			int right = Math.Min(r1.Right, r2.Right);
			int bottom = Math.Max(r1.Top, r2.Top);

			int width = right - left;
			int height = top - bottom;

			if (width < 0 || height < 0)
				return 0;

			return width * height;
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
      if (r1.Left == r2.Left && r1.Top == r2.Top && r1.Right == r2.Right && r1.Bottom == r2.Bottom)
      {
				return 0;
      }
      else if ((r1.Left <= r2.Left && r2.Left <= r1.Right) && (r1.Top <= r2.Top && r2.Top <= r1.Bottom) && (r1.Left <= r2.Right && r2.Right <= r1.Right) && (r1.Top <= r2.Bottom && r2.Bottom <= r1.Bottom))
			{
				return 1;
      }
      else if ((r2.Left <= r1.Left && r1.Left <= r2.Right) && (r2.Top <= r1.Top && r1.Top <= r2.Bottom) && (r2.Left <= r1.Right && r1.Right <= r2.Right) && (r2.Top <= r1.Bottom && r1.Bottom <= r2.Bottom))
      {
				return 0;
      }
			else
      {
				return -1;
			}
			
		}
	}
}