using System;
using System.Collections.Generic;

namespace RiskProfilingApp.Logic
{
    public class Response
    {
        public string StatusCode { get; set; }
        public string StatusDescription { get; set; }
    }

    public class getriskTokenResp
    {
        public string token { get; set; }
    }
    public class Business
    {
        public string category { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public int value { get; set; }
        public DateTime created { get; set; }
        public string createdBy { get; set; }
        public DateTime modified { get; set; }
        public string modifiedBy { get; set; }
        public int id { get; set; }
    }

    public class CitizenShip
    {
        public string code { get; set; }
        public string description { get; set; }
        public int value { get; set; }
        public DateTime created { get; set; }
        public string createdBy { get; set; }
        public DateTime modified { get; set; }
        public string modifiedBy { get; set; }
        public int id { get; set; }
    }

    public class ClientType
    {
        public string code { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public int value { get; set; }
        public DateTime created { get; set; }
        public string createdBy { get; set; }
        public DateTime modified { get; set; }
        public string modifiedBy { get; set; }
        public int id { get; set; }
    }

    public class DistributionChannel
    {
        public string code { get; set; }
        public string description { get; set; }
        public int value { get; set; }
        public DateTime created { get; set; }
        public string createdBy { get; set; }
        public DateTime modified { get; set; }
        public string modifiedBy { get; set; }
        public int id { get; set; }
    }

    public class Income
    {
        public string code { get; set; }
        public string description { get; set; }
        public int value { get; set; }
        public DateTime created { get; set; }
        public string createdBy { get; set; }
        public DateTime modified { get; set; }
        public string modifiedBy { get; set; }
        public int id { get; set; }
    }

    public class Product
    {
        public string category { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public int value { get; set; }
        public DateTime created { get; set; }
        public string createdBy { get; set; }
        public DateTime modified { get; set; }
        public string modifiedBy { get; set; }
        public int id { get; set; }
    }
    public class Profile
    {
        public int id { get; set; }
        public Business business { get; set; }
        public CitizenShip citizenShip { get; set; }
        public DistributionChannel distributionChannel { get; set; }
        public Income income { get; set; }
        public Product product { get; set; }
        public ClientType clientType { get; set; }
        public string customerName { get; set; }
        public string address { get; set; }
        public int businessId { get; set; }
        public int countryId { get; set; }
        public int distributionChannelId { get; set; }
        public int productId { get; set; }
        public int incomeId { get; set; }
        public int clientTypeId { get; set; }
        public bool isPep { get; set; }
    }

    public class RiskProfilingResponse : Response
    {
        public string id { get; set; }
        public Profile profile { get; set; }
        public Score score { get; set; }
        public DateTime submitted { get; set; }
        public object submittedBy { get; set; }
        public DateTime completed { get; set; }
    }

    public class Score
    {
        public string rating { get; set; }
        public double score { get; set; }
        public double clientType { get; set; }
        public double product { get; set; }
        public double business { get; set; }
        public double citizenship { get; set; }
        public double channel { get; set; }
        public double income { get; set; }
    }

    public class TransactionArray
    {
        public int id { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string tranId { get; set; }
        public double collected { get; set; }
        public double balance { get; set; }
        public DateTime lastAttempt { get; set; }
        public DateTime modified { get; set; }
        public string modifiedBy { get; set; }
        public object loanId { get; set; }
        public int method { get; set; }
        public double amount { get; set; }
        public string narration { get; set; }
        public string reference { get; set; }
        public string account { get; set; }
        public DateTime transactionDate { get; set; }
    }

    public class TransactionLogs
    {
        public List<TransactionArray> TransactionArray { get; set; }
    }
}