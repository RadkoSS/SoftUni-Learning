using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> Portfolio { get; set; }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public decimal MoneyToInvest { get; set; }

        public string BrokerName { get; set; }

        public Investor(string name, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.Portfolio = new List<Stock>();
            this.FullName = name;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
        }

        public int Count => this.Portfolio.Count;

        public void BuyStock(Stock stock)
        {

            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                this.MoneyToInvest -= stock.PricePerShare;

                this.Portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            var searchedCompany = FindStock(companyName);

            if (searchedCompany != null)
            {
                if (searchedCompany.PricePerShare > sellPrice)
                    return $"Cannot sell {companyName}.";

                else
                {
                    this.Portfolio.Remove(searchedCompany);
                    this.MoneyToInvest += sellPrice;
                    return $"{companyName} was sold.";
                }

            }
            else
                return $"{companyName} does not exist.";
        }

        public Stock FindStock(string companyName) => this.Portfolio.FirstOrDefault(company => company.CompanyName == companyName);

        public Stock FindBiggestCompany()
        {
            if (this.Portfolio.Count == 0)
            {
                return null;
            }

            decimal maxMarketCapitalization = this.Portfolio.Max(stock => stock.MarketCapitalization);

            return this.Portfolio.FirstOrDefault(company => company.MarketCapitalization == maxMarketCapitalization);
        }

        public string InvestorInformation()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");

            foreach (var stock in this.Portfolio)
            {
                output.AppendLine(stock.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
