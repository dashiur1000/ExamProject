using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriticalConsumer.Models
{
    public class Exam
    {
        public string Id { get; set; }

        public string? Server { get; set; }

        public string? Type { get; set; }

        public int Value { get; set; }

        public string? Status { get; set; }
    }
}
