using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCount
{
    public class cookie
    {
        public int COOKIES { get; set; }



        public cookie(int cookie)
        {
            this.COOKIES = cookie;
        }

            public void addcookies()
            {
                this.COOKIES++;
            } 
       
 
        public override string ToString()
        {
            return "Cookies: " + COOKIES;
        }

    }
}
