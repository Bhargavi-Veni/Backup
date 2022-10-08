using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using oDataWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oDataWebApplication.OdataHelpers
{
    public class odatabuilderExtensions
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            //builder.EntitySet<Employee>() 
            return null;
        }
    }
}
