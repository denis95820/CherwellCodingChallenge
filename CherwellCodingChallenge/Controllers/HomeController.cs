using CherwellCodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CherwellCodingChallenge.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CalculateTriangleCoordinates(string row, string column)
        {
            VertexCoordinates c = new VertexCoordinates();

            if (!string.IsNullOrWhiteSpace(row) && !string.IsNullOrWhiteSpace(column))
            {

                Tuple<int, int> rCoordinates = GetRowCoordinates(row);
                Tuple<int, int> cCoordinates = GetColumnCoordinates(column);

                int intColumn = Convert.ToInt32(column);

                if (rCoordinates == null || cCoordinates == null)
                {
                    ViewBag.Message = "Error: check inputs";
                    return View();
                }
                if (intColumn % 2 == 0)
                {
                    c.V1x = cCoordinates.Item1 > cCoordinates.Item2 ? cCoordinates.Item1 : cCoordinates.Item2;
                    c.V1y = rCoordinates.Item1 > rCoordinates.Item2 ? rCoordinates.Item1 : rCoordinates.Item2;
                    c.V2x = cCoordinates.Item1 > cCoordinates.Item2 ? cCoordinates.Item1 : cCoordinates.Item2;
                    c.V2y = rCoordinates.Item1 < rCoordinates.Item2 ? rCoordinates.Item1 : rCoordinates.Item2;
                    c.V3x = cCoordinates.Item1 < cCoordinates.Item2 ? cCoordinates.Item1 : cCoordinates.Item2;
                    c.V3y = rCoordinates.Item1 > rCoordinates.Item2 ? rCoordinates.Item1 : rCoordinates.Item2;
                }
                else
                {
                    c.V1x = cCoordinates.Item1 < cCoordinates.Item2 ? cCoordinates.Item1 : cCoordinates.Item2;
                    c.V1y = rCoordinates.Item1 < rCoordinates.Item2 ? rCoordinates.Item1 : rCoordinates.Item2;
                    c.V2x = cCoordinates.Item1 < cCoordinates.Item2 ? cCoordinates.Item1 : cCoordinates.Item2;
                    c.V2y = rCoordinates.Item1 > rCoordinates.Item2 ? rCoordinates.Item1 : rCoordinates.Item2;
                    c.V3x = cCoordinates.Item1 > cCoordinates.Item2 ? cCoordinates.Item1 : cCoordinates.Item2;
                    c.V3y = rCoordinates.Item1 < rCoordinates.Item2 ? rCoordinates.Item1 : rCoordinates.Item2;
                }
            }

            return View(c);
        }

        private Tuple<int, int> GetRowCoordinates(string row)
        {
            Tuple<int, int> tuple;

            row = row.ToUpper().Trim();

            if (row.Length < 0)
                return null;

            switch (row)
            {
                case "A":
                    tuple = new Tuple<int, int>(50, 60);
                    break;
                case "B":
                    tuple = new Tuple<int, int>(40, 50);
                    break;
                case "C":
                    tuple = new Tuple<int, int>(30, 40);
                    break;
                case "D":
                    tuple = new Tuple<int, int>(20, 30);
                    break;
                case "E":
                    tuple = new Tuple<int, int>(10, 20);
                    break;
                case "F":
                    tuple = new Tuple<int, int>(0, 10);
                    break;

                default:
                    return null;
            }

            return tuple;
        }

        private Tuple<int, int> GetColumnCoordinates(string column)
        {
            Tuple<int, int> tuple;

            column = column.ToUpper().Trim();

            if (column.Length < 0)
                return null;

            switch (column)
            {
                case "1":
                    tuple = new Tuple<int, int>(0, 10);
                    break;
                case "2":
                    tuple = new Tuple<int, int>(0, 10);
                    break;
                case "3":
                    tuple = new Tuple<int, int>(10, 20);
                    break;
                case "4":
                    tuple = new Tuple<int, int>(10, 20);
                    break;
                case "5":
                    tuple = new Tuple<int, int>(20, 30);
                    break;
                case "6":
                    tuple = new Tuple<int, int>(20, 30);
                    break;
                case "7":
                    tuple = new Tuple<int, int>(30, 40);
                    break;
                case "8":
                    tuple = new Tuple<int, int>(30, 40);
                    break;
                case "9":
                    tuple = new Tuple<int, int>(40, 50);
                    break;
                case "10":
                    tuple = new Tuple<int, int>(40, 50);
                    break;
                case "11":
                    tuple = new Tuple<int, int>(50, 60);
                    break;
                case "12":
                    tuple = new Tuple<int, int>(50, 60);
                    break;

                default:
                    return null;
            }

            return tuple;
        }

        public ActionResult CalculateRowAndColumn(VertexCoordinates c)
        {
            if (c != null)
            {
                string rowLetter = CalculateRow(c.V1y, c.V2y);

                bool isRightAngleOnTop;

                if (c.V1y < c.V2y)
                {
                    isRightAngleOnTop = false;
                }
                else
                {
                    isRightAngleOnTop = true;
                }

                string columnNumber = CalculateColumn(c.V1x, c.V3x, isRightAngleOnTop);

                string[] validRows = new string[] { "A", "B", "C", "D", "E", "F" };
                string[] validColumns = new string[] { "1","2","3","4","5","6","7","8","9","10","11","12" };

                if (!string.IsNullOrEmpty(rowLetter) && !string.IsNullOrEmpty(columnNumber) &&
                    validRows.Contains(rowLetter) && validColumns.Contains(columnNumber))
                {
                    ViewBag.Result = rowLetter + columnNumber;
                }
                else
                {
                    ViewBag.Result = "Error: check inputs";
                }
            }

            return View();
        }

        private string CalculateRow(int y1, int y2, bool tryReversed = true)
        {
            if ((y1 == 0 && y2 == 10))
            {
                return "F";
            }
            if (y1 == 10 && y2 == 20)
            {
                return "E";
            }
            if (y1 == 20 && y2 == 30)
            {
                return "D";
            }
            if (y1 == 30 && y2 == 40)
            {
                return "C";
            }
            if (y1 == 40 && y2 == 50)
            {
                return "B";
            }
            if (y1 == 50 && y2 == 60)
            {
                return "A";
            }

            if (tryReversed)
            {
                return CalculateRow(y2, y1, tryReversed = false);  
            }

            return null;
        }

        private string CalculateColumn(int x1, int x2, bool isRightAngleOnTop, bool tryReversed = true)
        {
            int column = 0;

            if ((x1 == 0 && x2 == 10))
            {
                column = 1;
            }
            if (x1 == 10 && x2 == 20)
            {
                column = 3;
            }
            if (x1 == 20 && x2 == 30)
            {
                column = 5;
            }
            if (x1 == 30 && x2 == 40)
            {
                column = 7;
            }
            if (x1 == 40 && x2 == 50)
            {
                column = 9;
            }
            if (x1 == 50 && x2 == 60)
            {
                column = 11;
            }

            if (column == 0 && tryReversed)
            {
                return CalculateColumn(x2, x1, isRightAngleOnTop, tryReversed = false).ToString();
            }

            if (column > 0 && isRightAngleOnTop)
                column++;

            return column.ToString();
        }


        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}


    }
}