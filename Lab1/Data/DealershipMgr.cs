using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Data
{
    public class DealershipMgr
    {
        static List<Dealership> dealerships = new List<Dealership>
        {
            new Dealership { ID=1, Name="Toyota Oakville", Email="info@toyotaoakville.ca", PhoneNumber="1-888-238-8232" },
            new Dealership { ID=2, Name="Queenston Chevrolet", Email="queenston.contact@chevy.com", PhoneNumber="122-441-2214" }
        };

        public Dealership GetDealership(int? id)
        {
            var dealership = dealerships.FirstOrDefault(d => d.ID == id);
            if(dealership == null)
            {
                throw new NullReferenceException("Dealership does not exist!");
            }

            return dealership;
        }

        public Dealership DeleteDealership(int id)
        {
            Dealership dealership = dealerships.FirstOrDefault(d => d.ID == id);

            if (dealership == null)
            {
                throw new NullReferenceException("Dealership does not exist!");
            }

            dealerships.Remove(dealership);
            return dealership;
        }

        public List<Dealership> GetDealerships()
        {
            return dealerships;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public Dealership AddDealership([Bind("ID, Name, Email, PhoneNumber")] Dealership dealership)
        {
            try
            {
                Dealership dealershipExists = dealerships.FirstOrDefault(d => d.ID == dealership.ID);
                if (dealershipExists == null)
                {
                    dealerships.Add(dealership);
                    return dealership;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Cannot add dealership!");
            }
           
        }

        public Dealership UpdateDealership([Bind("ID, Name, Email, PhoneNumber")] Dealership dealershipNew)
        {
            try
            {
                var dealershipExists = dealerships.FirstOrDefault(d => d.ID == dealershipNew.ID);
                if (dealershipExists == null)
                {
                    throw new NullReferenceException("Dealership does not exist!");
                }
                else
                {
                    Dealership dealership = dealerships.FirstOrDefault(d => d.ID == dealershipNew.ID);
                    dealership.Name = dealershipNew.Name;
                    dealership.Email = dealershipNew.Email;
                    dealership.PhoneNumber = dealershipNew.PhoneNumber;
                    return dealership;
                }
            }
            catch (Exception exception)
            {
                throw new ArgumentException(exception.ToString());
            }
        }
    }
}
