﻿using AspNetDesign.Infrastructure.Domain;
using AspNetDesign.Model.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Model.Customers
{
    public class Customer : EntityBase<int>, IAggregateRoot
    {
        private IList<DeliveryAddress> _deliveryAddressBook = new List<DeliveryAddress>();

        public string IdentityToken { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }

        public IList<Order> Orders { get; set; }

        public void AddAddress(DeliveryAddress deliveryAddress)
        {
            ThrowExceptionIfAddressIsInvalid(deliveryAddress);
            _deliveryAddressBook.Add(deliveryAddress);
        }

        private void ThrowExceptionIfAddressIsInvalid(DeliveryAddress deliveryAddress)
        {
            if (deliveryAddress.GetBrokenRules().Count() > 0)
            {
                StringBuilder deliveryAddressIssues = new StringBuilder();
                deliveryAddressIssues.AppendLine("There were some issues with the address you are adding.");
                foreach (BusinessRule rule in deliveryAddress.GetBrokenRules())
                    deliveryAddressIssues.AppendLine(rule.Rule);
                throw new InvalidAddressException(deliveryAddressIssues.ToString());
            }
        }

        public IEnumerable<DeliveryAddress> DeliveryAddressBook
        {
            get { return _deliveryAddressBook; }
        }

        protected override void Validate()
        {
            if (String.IsNullOrEmpty(FirstName))
                base.AddBrokenRules(CustomerBusinessRules.FirstNameRequired);
            if (String.IsNullOrEmpty(SecondName))
                base.AddBrokenRules(CustomerBusinessRules.SecondNameRequired);
            if (!new EmailValidationSpecification().IsSatisfiedBy(Email))
                base.AddBrokenRules(CustomerBusinessRules.EmailRequired);
            if (String.IsNullOrEmpty(IdentityToken))
                base.AddBrokenRules(CustomerBusinessRules.IdentityTokenRequired);
        }
    }
}