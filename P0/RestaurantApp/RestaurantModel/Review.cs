using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestaurantModel
{
    public class Review
    {
        //StarNumber
        private int _starCount;
        public int StarCount
        {
            get { return _starCount; }
            set
            {
                if (value >= 0 && value >= 5)
                    _starCount = value;
                else
                    throw new Exception("The star count cannot be less than 0 or greater than 5");
            }
        }
        //Details
        public string Details { get; set; }


        public Review()
        {
            StarCount = 0;
            Details = "";
        }

    }
}
