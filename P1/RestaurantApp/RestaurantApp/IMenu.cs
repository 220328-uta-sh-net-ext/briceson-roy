using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{
    public interface IMenu
    {
        /// <summary>
        /// 
        /// </summary>

        void Display();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string UserChoice();
    }
    interface IMoreMenu
    {
        void Exit();

        void Continue();
    }
}
