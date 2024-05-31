using System;
using ChartExample.ChartModels.Chart;
using ChartExample.ViewComponents;
using Newtonsoft.Json;

namespace ChartExample.ChartModels
{
    public class ChartJsViewModel
    {
        public ChartJs Chart { get; set; }
        public string ChartJson { get; set; }
    }
}