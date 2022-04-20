using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantModel
{
    public class Restaurant
    {
        //Name
        public string Name { get; set; }
        //ZipCode
        public int ZipCode { get; set; }

        //SignatureDish
        public string SignatureDish { get; set; }

        //Reviews
        private List<Review> _reviews;
        public List<Review> Reviews
        {
            get { return _reviews; }
            set { _reviews = value; }
        }

        public Restaurant()
        {
            Name = "Lorem's Diner";
            ZipCode = 00000;
            SignatureDish = "Lorem's Big Belly Burger";
            _reviews = new List<Review>();
            {
                new Review();
            }
            
        }
    }
}
