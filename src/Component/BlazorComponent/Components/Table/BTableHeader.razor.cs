﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BlazorComponent
{
    public partial class BTableHeader : BDomComponentBase
    {
        [Parameter]
        public List<string> Headers { get; set; }
    }
}