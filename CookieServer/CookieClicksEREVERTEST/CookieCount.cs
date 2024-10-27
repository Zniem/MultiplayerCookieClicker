namespace CookieCount {
    public class Cookie {
        //all variables 
        public double COOKIES { get; set; }
        public double CPS { get; set; }
        public int FINGER { get; set; }
        public double FINGERPRICE { get; set; }
        public int GRANDMA { get; set; }
        public double GRANDMAPRICE { get; set; }
        public int FARM { get; set; }
        public double FARMPRICE { get; set; }
        public int MINE { get; set; }
        public double MINEPRICE { get; set; }
        public int FACTORY { get; set; }
        public double FACTORYPRICE { get; set; }
        public int BANK { get; set; }
        public double BANKPRICE { get; set; }

        public Cookie(double COOKIES, double CPS, int FINGER, double FINGERPRICE, int GRANDMA, double GRANDMAPRICE, int FARM, double FARMPRICE, int MINE, double MINEPRICE, int FACTORY, double FACTORYPRICE, int BANK, double BANKPRICE) {
            this.COOKIES = COOKIES;
            this.CPS = CPS;
            this.FINGER = FINGER;
            this.FINGERPRICE = FINGERPRICE;
            this.GRANDMA = GRANDMA;
            this.GRANDMAPRICE = GRANDMAPRICE;
            this.FARM = FARM;
            this.FARMPRICE = FARMPRICE;
            this.MINE = MINE;
            this.MINEPRICE = MINEPRICE;
            this.FACTORY = FACTORY;
            this.FACTORYPRICE = FACTORYPRICE;
            this.BANK = BANK;
            this.BANKPRICE = BANKPRICE;
        }


        //initializer


        //all add 1 methodes
        public void addcookies() { this.COOKIES++; }
        public void addGrandma() { this.GRANDMA++; }
        public void addFarm() { this.FARM++; }
        public void addMine() { this.MINE++; }
        public void addFactory() { this.FACTORY++; }
        public void addBank() { this.BANK++; }
        public void addFinger() { this.FINGER++; }
    }
}
