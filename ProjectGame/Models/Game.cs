using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectGame.Models
{
    public class Game
    {

        public int Id { get; set; }
        public String Name { get; set; }
        public String Genre { get; set; }
        public int AgeRange { get; set; }
        public double Price { get; set; }
    }
}