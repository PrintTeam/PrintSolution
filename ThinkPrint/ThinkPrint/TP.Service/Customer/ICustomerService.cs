using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Customer {

    public interface ICustomerService {
        SAL_Customer GetCustomer(int  CustomerId);
        SAL_Customer GetCustomer(String UniqueCode);
        List<SALCustomer> GetCustomers();
        PagedList<SALCustomer> GetCustomers(int pageIndex, int pageSize, string searchKey = null);
        void InsertCustomer(SAL_Customer Customer);
        void UpdateCustomer(SAL_Customer Customer);
        void DeleteCustomer(SAL_Customer Customer);
    }

    public class SALCustomer {
        public int CustomerId {
            get;
            set;
        }
        public int IndustryId {
            get;
            set;
        }
        public String IndustryName {
            get;
            set;
        }
        public string Name {
            get;
            set;
        }
        public string MembershipCode {
            get;
            set;
        }
        public string Cardholder {
            get;
            set;
        }
        public string CardNumber {
            get;
            set;
        }
        public string CustomerType {
            get;
            set;
        }
        public string UniqueCode {
            get;
            set;
        }
        public string MnemonicCode {
            get;
            set;
        }
        public bool Sex {
            get;
            set;
        }
        public string MobilePhone {
            get;
            set;
        }
        public string Telephone {
            get;
            set;
        }
        public Nullable<System.DateTime> Birthday {
            get;
            set;
        }
        public string Email {
            get;
            set;
        }
        public Nullable<int> QQ {
            get;
            set;
        }
        public string ZipCode {
            get;
            set;
        }
        public string Address {
            get;
            set;
        }
        public int CreditRating {
            get;
            set;
        }
        public bool IsCreditCard {
            get;
            set;
        }
        public Nullable<decimal> MaximumAmount {
            get;
            set;
        }
        public string SalePriceType {
            get;
            set;
        }
        public string Description {
            get;
            set;
        }
    }
}

