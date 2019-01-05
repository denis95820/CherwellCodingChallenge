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
                }

                //calculate the horizontal line to get the column
                if (c.V1x < c.V3x)
                {
                    //horisontal line going left to right
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
            if (y1 == 0 && y2 == 10)
            {
                return "A";
            }

            if (tryReversed)
            {
                //int c = y1;
                //y1 = y2;
                //y2 = y1;

                return = CalculateRow(y2, y1, tryReversed = false);  
            }

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