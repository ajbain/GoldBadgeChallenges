using ChallengeFive_Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace _ChallengeFive_Console
{
    public class ProgramUI
    {
        private Customer_Repo _repo = new Customer_Repo();

        public void Run()
        {
            SeedContent();
            //Menu();

        }
        private void SeedContent()
        {


            Customer jane = new Customer(
                "Jane", "Doe", CustType.Present);
            _repo.AddCustomer(jane);

            Customer abby = new Customer(
                "Abby", "Smith", CustType.Past);
            _repo.AddCustomer(abby);

            Customer emma = new Customer(
                "Emma", "Johnson", CustType.Potential);
            _repo.AddCustomer(emma);


        }
    }


}
