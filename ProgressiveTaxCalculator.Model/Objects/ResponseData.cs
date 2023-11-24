using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Model.Objects
{
    /// <summary>
    /// Global api response.
    /// </summary>
    public class ResponseData
    {        
        public dynamic? ResponsePayload { get; set; }        
        public HttpStatusCode Status { get; set; }
    }
}
