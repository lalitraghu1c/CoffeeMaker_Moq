using CoffeeMaker_Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker_Moq
{
    public class StarbuckStore
    {
        private readonly IMakeACoffee service;
        public StarbuckStore(IMakeACoffee service)
        {
            this.service = service;
        }
        public string OrderCoffee(int sugarPerPerson, int coffeeCount)
        {
            if (service.CheckIngridentAvailablity())
            {
                return service.CoffeeMaking(sugarPerPerson, coffeeCount);
            }
            else
            {
                return "Sorry, Your coffee is not available.";
            }
        }
    }
}