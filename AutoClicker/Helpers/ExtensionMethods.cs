using System;
using System.Collections.Generic;
using System.Drawing;

namespace AutoClicker.Helpers
{
	public static class ExtensionMethods
	{
		public static Color[,] GetPixelMap(this Bitmap image)
		{
			Color[,] matrix = new Color[image.Width, image.Height];

			for (int i = 0; i < image.Width; i++)
			{
				for (int j = 0; j < image.Height; j++)
				{
					matrix[i, j] = image.GetPixel(i, j);
				}
			}

			return matrix;
		}

		public static List<T> To1dList<T>(this T[,] array)
		{
			List<T> result = new List<T>();
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					result.Add(array[i, j]);
				}
			}

			return result;
		}

		public static bool Contains<T>(this T[,] largeArray, T[,] smallArray, Func<T, T, bool> compareFunc = null)
		{
			if (compareFunc == null)
			{
				compareFunc = (first, second) => first.Equals(second);
			}

			if (smallArray.GetLength(0) > largeArray.GetLength(0) || smallArray.GetLength(1) > largeArray.GetLength(1))
			{
				//largeArray can't contain smallArray
				return false;
			}

			for (int i = 0; i < largeArray.GetLength(0) - smallArray.GetLength(0) + 1; i++)
			{
				for (int j = 0; j < largeArray.GetLength(1) - smallArray.GetLength(1) + 1; j++)
				{
					if (compareFunc(largeArray[i, j], smallArray[0, 0]))
					{
						if (SubArrayEquals(largeArray, smallArray, i, j, compareFunc))
						{
							return true;
						}
					}
				}
			}

			return false;
		}

		public static bool SubArrayEquals<T>(this T[,] largeArray, T[,] smallArray, int startRow, int startCol, Func<T, T, bool> compareFunc = null)
		{
			for (int m = startRow; m < startRow + smallArray.GetLength(0); m++)
			{
				for (int n = startCol; n < startCol + smallArray.GetLength(1); n++)
				{
					//Console.WriteLine($"Checking largeArray[{m}, {n}]");
					if (!compareFunc(largeArray[m, n], smallArray[m - startRow, n - startCol]))
					{
						//Console.WriteLine($"Mismatch at {m}, {n}. Expected: {smallArray[m - startRow, n - startCol]}, Found: {largeArray[m, n]}");
						return false;
					}
				}
			}

			return true;
		}
	}
}
