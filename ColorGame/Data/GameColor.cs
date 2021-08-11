using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColorGame.Data
{
    public static class GameColor
    {
        public static string GetHtml(int code)
        {
            switch (code)
            {
                case 0:
                    return "#0000ff"; // blue
                case 1:
                    return "#00cc00"; // green
                case 2:
                    return "#ffff00"; // yellow
                default:
                    return "#ff0000"; // red
            }
        }

        public static string GetName(int code)
        {
            switch (code)
            {
                case 0:
                    return "blue";
                case 1:
                    return "green";
                case 2:
                    return "yellow";
                default:
                    return "red";
            }
        }

        public static string GetName(string html)
        {
            switch (html)
            {
                case "#0000ff":
                    return "blue";
                case "#00cc00":
                    return "green";
                case "#ffff00":
                    return "yellow";
                default:
                    return "red";
            }
        }
        
    }
}
