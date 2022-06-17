using System;
using System.Text;

namespace StockMarket
{
    public class Stock
    {
        public string CompanyName { get; set; }

        public string Director { get; set; }

        public decimal PricePerShare { get; set; }

        public int TotalNumberOfShares { get; set; }

        public decimal MarketCapitalization { get; set; }

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
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Company: {this.CompanyName}");
            output.AppendLine($"Director: {this.Director}");
            output.AppendLine($"Price per share: ${this.PricePerShare}");
            output.AppendLine($"Market capitalization: ${this.MarketCapitalization}");

            return output.ToString().TrimEnd();
        }
    }
}
