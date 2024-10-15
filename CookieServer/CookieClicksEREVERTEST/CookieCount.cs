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
        public int GRANDMA { get; set; }
        public double GRANDMAPRICE { get; set; } = 20;
        public int FARM { get; set; }
        public int MINE { get; set; }
        public int FACTORY { get; set; }
        public int WIZARDTOWER { get; set; }

        public cookie(int cookie)
        {
            this.COOKIES = cookie;
        }

        public void addcookies()
        {
            this.COOKIES++;
        }

        public void addGrandma()
        {
            this.GRANDMA++;
        }
        public void addFarm()
        {
            this.FARM++;
        }
        public void addMine()
        {
            this.MINE++;
        }
        public void addFactory()
        {
            this.FACTORY++;
        }
        public void addWizzardTower()
        {
            this.WIZARDTOWER++;
        }


        public override string ToString()
        {
            return "" + COOKIES;
        }

    }
}
