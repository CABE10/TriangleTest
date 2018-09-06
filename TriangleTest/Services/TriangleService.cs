using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleTest.Models;
namespace TriangleTest.Services
{
    public static class TriangleService
    {
        public static string GetRowAndColumn(Triangle triangle)
        {
            if (!IsValidTriangle(triangle))
            {
                return "Invalid Coordinates";
            }
            StringBuilder sb = new StringBuilder();
            List<char> rowChars = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F' };
            rowChars.Reverse();
            int centerX = (triangle.V1x + triangle.V2x + triangle.V3x) / 3;
            int centerY = (triangle.V1y + triangle.V2y + triangle.V3y) / 3;

            //row first
            var rawRow = ((decimal)rowChars.Count() / ((decimal)60 / (decimal)centerY));
            int row = Convert.ToInt32(Math.Ceiling(rawRow));
            //column second
            var rawColumn = (decimal)12 / (((decimal)60 / (decimal)centerX));
            var column = Math.Ceiling(rawColumn);
            sb.Append($"Row is {rowChars[row - 1]}");
            sb.Append($" and Column is {column}");
            string result = sb.ToString();
            return sb.ToString();
        }

        public static Triangle GetTriangle(char row, sbyte column)
        {
            row = char.ToLower(row);
            if(!IsValidRow(row) || !IsValidColumn(column))
            {
                throw new Exception("Invalid Row Or Column");
            }
            Triangle result = new Triangle();
            sbyte topMost = 0;
            sbyte bottomMost = 0;
            switch (row) //I could have probably done this a little simpler.
            {
                case 'a':
                    topMost = 60;
                    bottomMost = 50;
                    break;
                case 'b':
                    topMost = 50;
                    bottomMost = 40;
                    break;
                case 'c':
                    topMost = 40;
                    bottomMost = 30;
                    break;
                case 'd':
                    topMost = 30;
                    bottomMost = 20;
                    break;
                case 'e':
                    topMost = 20;
                    bottomMost = 10;
                    break;
                case 'f':
                    topMost = 10;
                    bottomMost = 0;
                    break;
            }
            if(column % 2 == 0)
            { //a2, a4, a6, a8, a10, a12
                result.V1x = Convert.ToSByte((10 * Math.Floor((decimal)column / 2)));
                result.V1y = bottomMost;

                result.V2y = topMost;
                result.V2x = Convert.ToSByte((10 * Math.Floor((decimal)(column - 1) / 2)));

                result.V3x = Convert.ToSByte(10 * Math.Floor((decimal)(column / 2)));
                result.V3y = topMost;
            }
            else
            { //a1, a3, a5, a7, a9, a11
                result.V1y = bottomMost;
                result.V1x = Convert.ToSByte((10 * Math.Floor((decimal)(column - 1) / 2)));

                result.V2y = topMost;
                result.V2x = Convert.ToSByte((10 * Math.Floor((decimal)(column - 1) / 2)));

                result.V3y = bottomMost;
                result.V3x = Convert.ToSByte(result.V2x + 10);
            }
            return result;
        }
        private static bool IsValidRow(char c)
        {
            if(c != 'a' && c!= 'b' && c!= 'c' && c != 'd' && c != 'e' && c != 'f')
            {
                return false;
            }
            return true;
        }
        private static bool IsValidColumn(sbyte c)
        {
            if(c < 1 || c > 12)
            {
                return false;
            }
            return true;
        }
        private static bool IsValidTriangle(Triangle t)
        {
            if(t == null)
            {
                return false;
            }
            if(t.V1x > 60 || t.V1x < 0 || t.V1y > 60 || t.V1y < 0)
            {
                return false;
            }
            if (t.V2x > 60 || t.V2x < 0 || t.V2y > 60 || t.V2y < 0)
            {
                return false;
            }
            if (t.V3x > 60 || t.V3x < 0 || t.V3y > 60 || t.V3y < 0)
            {
                return false;
            }

            return true;
        }

    }
}