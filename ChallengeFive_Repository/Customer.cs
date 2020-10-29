using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFive_Repository
{ 
    public enum CustType { Past =1, Present, Potential}
    public class Customer
    {// pseudo code
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustType CustType { get; set; }
        
        public string EmailType
        {
            get
            {
                switch(CustType)
                {
                    case CustType.Past:
                        return "It's been a long time since we've heard from you, we want you back";
                    case CustType.Present:
                        return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    case CustType.Potential:
                        return "We currently have the lowest rates on Helicopter Insurance";
                    default:
                        return "Error in Customer Type, Please Review";
                }
            }
        }
        public Customer() { }

        public Customer(string firstName, string lastName, CustType custType)
        {
            FirstName = firstName;
            LastName = lastName;
            CustType = custType;
        }
    }
}
