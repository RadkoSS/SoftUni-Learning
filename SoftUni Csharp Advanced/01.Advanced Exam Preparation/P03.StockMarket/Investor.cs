using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;

        private string fullName;

        private string emailAddress;

        private decimal moneyToInvest;

        private string brokerName;

        private List<Stock> Portfolio
        {
            get { return portfolio; }
            set { portfolio = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        public decimal MoneyToInvest
        {
            get { return moneyToInvest; }
            set { moneyToInvest = value; }
        }

        public string BrokerName
        {
            get { return brokerName; }
            set { brokerName = value; }
        }

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

            return this.Portfolio.First(company => company.MarketCapitalization == maxMarketCapitalization);
        }

        public string InvestorInformation()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");

            for (int i = 0; i < this.Portfolio.Count; i++)
            {
                output.AppendLine(this.Portfolio[i].ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
