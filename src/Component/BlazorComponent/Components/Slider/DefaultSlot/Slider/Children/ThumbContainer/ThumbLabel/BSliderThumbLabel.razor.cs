﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorComponent
{
    public partial class BSliderThumbLabel<TInput> where TInput : ISlider
    {
        public RenderFragment ThumbLabelContent => Component.ThumbLabelContent;
    }
}