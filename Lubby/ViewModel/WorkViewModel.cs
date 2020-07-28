using System;
using System.Collections.Generic;

namespace Lubby.Domain.ViewModel
{
    public class WorkViewModel
    {
        public string Name { get; set; }
        public IEnumerable<TimeSpan> Horas { get; set; }
    }
}
