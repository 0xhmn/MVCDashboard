using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard.Models.WidgetModels
{
    public class CounterWidgetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfApplications { get; set; }
        public bool? IsSelected { get; set; }
    }
}