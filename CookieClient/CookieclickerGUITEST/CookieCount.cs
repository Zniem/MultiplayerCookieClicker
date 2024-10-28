using System;

namespace CookieCount {
    public struct Cookie {
        //all variables 
        public double Cookies { get; set; }
        public double Cps { get; set; }
        public int Finger { get; set; }
        public int Grandma { get; set; }
        public int Farm { get; set; }
        public int Mine { get; set; }
        public int Factory { get; set; }
        public int Bank { get; set; }

        public double FingerPrice {
            get {
                return CalculatePrice(15, Finger);
            }
        }
        public double GrandmaPrice {
            get {
                return CalculatePrice(100, Grandma);
            }
        }
        public double FarmPrice {
            get {
                return CalculatePrice(1100, Farm);
            }
        }
        public double MinePrice {
            get {
                return CalculatePrice(12000, Mine);
            }
        }
        public double FactoryPrice {
            get {
                return CalculatePrice(130000, Factory);
            }
        }
        public double BankPrice {
            get {
                return CalculatePrice(1400000, Bank);
            }
        }

        public Cookie(double cookies, double cps, int finger, int grandma, int farm, int mine, int factory, int bank) {
            Cookies = cookies;
            Cps = cps;
            Finger = finger;
            Grandma = grandma;
            Farm = farm;
            Mine = mine;
            Factory = factory;
            Bank = bank;
        }

        private static double CalculatePrice(int initialPrice, int amount) {
            return initialPrice * Math.Pow(1.15, amount);
        }

        //all add 1 methodes
        public void addcookies() { Cookies++; }
        public void addFinger() { Finger++; }
        public void addGrandma() { Grandma++; }
        public void addFarm() { Farm++; }
        public void addMine() { Mine++; }
        public void addFactory() { Factory++; }
        public void addBank() { Bank++; }
    }
}
