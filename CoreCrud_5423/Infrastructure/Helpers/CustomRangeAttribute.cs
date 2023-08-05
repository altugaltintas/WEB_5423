using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud_5423.Infrastructure.Helpers
{
    public class CustomRangeAttribute  : RangeAttribute
    {
        // yönetmen kişisi 18- 110 yaş aralığında olabilir.

        public CustomRangeAttribute() :base(typeof(DateTime),DateTime.Now.AddYears(-110).ToString(),DateTime.Now.AddYears(-18).ToString())
        {

        }

    }
}
