using System;

namespace StockMarket
{
    public class Stock
    {
        private string companyName;

        private string director;

        private decimal pricePerShare;

        private int totalNumberOfShares;

        private decimal marketCapitalization;

        public string CompanyName 
        { 
            get { return companyName; }
            set { companyName = value; }
        }

        public string Director
        {
            get { return director; }
            set { director = value; }
        }

        public decimal PricePerShare
        {
            get { return pricePerShare; }
            set { pricePerShare = value; }
        }

        public int TotalNumberOfShares
        {
            get { return totalNumberOfShares; }
            set { totalNumberOfShares = value; }
        }

        public decimal MarketCapitalization
        {
            get { return marketCapitalization; }
            private set 
            {
                marketCapitalization = value;
            }
        }

        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            this.CompanyName = companyName;

            this.Director = director;

            this.PricePerShare = pricePerShare;

            this.TotalNumberOfShares = totalNumberOfShares;

            this.MarketCapitalization = this.PricePerShare * this.TotalNumberOfShares;
        }

        public override string ToString()
        {
            return $"Company: {this.CompanyName}{Environment.NewLine}Director: {this.Director}{Environment.NewLine}PricePerShare:${this.PricePerShare:f2}{Environment.NewLine}MarketCapitalization: ${this.MarketCapitalization:f2}";
        }
    }
}
