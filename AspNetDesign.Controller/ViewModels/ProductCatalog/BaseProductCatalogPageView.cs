﻿using AspNetDesign.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Controller.ViewModels.ProductCatalog
{
    public abstract class BaseProductCatalogPageView : BasePageView
    {
        public IEnumerable<CategoryView> Categories { get; set; }
    }
}
