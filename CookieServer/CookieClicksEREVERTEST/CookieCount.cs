﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCount
{
    public class cookie
    {
        public double COOKIES { get; set; }
        public double CPS{ get; set; }
        public int FINGER { get; set; }
        public double FINGERPRICE { get; set; } = 15;
        public int GRANDMA { get; set; }
        public double GRANDMAPRICE { get; set; } = 100;
        public int FARM { get; set; }
        public double FARMPRICE { get; set; } = 1100;
        public int MINE { get; set; }
        public double MINEPRICE { get; set; } = 150;
        public int FACTORY { get; set; }
        public double FACTORYPRICE { get; set; } = 200;
        public int WIZARDTOWER { get; set; }
        public double WIZARDTOWERPRICE { get; set; } = 300;

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
        public void addFinger() { 
            this.FINGER++;
        }


        public override string ToString()
        {
            return "" + COOKIES;
        }

    }
}
