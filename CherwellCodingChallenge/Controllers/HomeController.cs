using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CherwellCodingChallenge.Controllers
{
    public class VertexCoordinates
    {
        public int V1x { get; set; }
        public int V1y { get; set; }

        public int V2x { get; set; }
        public int V2y { get; set; }

        public int V3x { get; set; }
        public int V3y { get; set; }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CalculateTriangleCoordinates(string row, string column)
        {

            if (!string.IsNullOrWhiteSpace(row) && !string.IsNullOrWhiteSpace(column))
            {
                // row = f
                // column = 1

                //row F starts at (0,0)
                //V1x = 0
                //V1y = 0

                //V2x = 0
                //V2y = 10
                
                //V3x = 10
                //V3y = 0
            }

            return View();
        }

        public ActionResult CalculateRowAndColumn(VertexCoordinates c)
        {
            // E3 is the triagle

            //V1x = 10
            //V1y = 10
            //V1 is right angle 

            //V2x = 10
            //V2y = 20

            //V3x = 20
            //V3y = 10

            if (c != null)  // ()
            {
                //calculate the vertical line to get the row
                string rowLetter = CalculateRow(c.V1y, c.V2y);

                if (c.V1y < c.V2y)
                {
                    string columnNumber = CalculateColumn(c.V1x, c.V3x, true);
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

            if (tryReversed)
            {
                return CalculateColumn(x2, x1, isRightAngleOnTop, tryReversed = false).ToString();
            }

            if (isRightAngleOnTop)
                return (column + 1).ToString();

            return null;
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