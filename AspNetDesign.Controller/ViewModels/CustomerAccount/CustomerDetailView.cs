﻿using AspNetDesign.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Controller.ViewModels.CustomerAccount
{
    public class CustomerDetailView : BaseCustomerAccountView
    {
        public CustomerView Customer { get; set; }
    }
}
