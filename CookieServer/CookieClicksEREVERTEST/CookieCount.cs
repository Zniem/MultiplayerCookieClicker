using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCount
{
    public class Cookie
    {
        //all variables 
        public double COOKIES { get; set; }
        public double CPS{ get; set; }
        public int FINGER { get; set; }
        public double FINGERPRICE { get; set; } = 15;
        public int GRANDMA { get; set; }
        public double GRANDMAPRICE { get; set; } = 100;
        public int FARM { get; set; }
        public double FARMPRICE { get; set; } = 1100;
        public int MINE { get; set; }
        public double MINEPRICE { get; set; } = 12000;
        public int FACTORY { get; set; }
        public double FACTORYPRICE { get; set; } = 130000;
        public int BANK { get; set; }
        public double BANKPRICE { get; set; } = 1400000;

        public Cookie(double cOOKIES, double cPS, int fINGER, double fINGERPRICE, int gRANDMA, double gRANDMAPRICE, int fARM, double fARMPRICE, int mINE, double mINEPRICE, int fACTORY, double fACTORYPRICE, int bANK, double bANKPRICE)
        {
            COOKIES = cOOKIES;
            CPS = cPS;
            FINGER = fINGER;
            FINGERPRICE = fINGERPRICE;
            GRANDMA = gRANDMA;
            GRANDMAPRICE = gRANDMAPRICE;
            FARM = fARM;
            FARMPRICE = fARMPRICE;
            MINE = mINE;
            MINEPRICE = mINEPRICE;
            FACTORY = fACTORY;
            FACTORYPRICE = fACTORYPRICE;
            BANK = bANK;
            BANKPRICE = bANKPRICE;
        }

        public Cookie(int cookie)
        {
            this.COOKIES = cookie;
        }


        //initializer


        //all add 1 methodes
        public void addcookies(){this.COOKIES++;}
        public void addGrandma(){this.GRANDMA++;}
        public void addFarm(){this.FARM++;}
        public void addMine(){this.MINE++;}
        public void addFactory(){this.FACTORY++;}
        public void addBank(){this.BANK++;}
        public void addFinger(){ this.FINGER++;}
    }
}
