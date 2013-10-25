using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundiPaggClientSDK.Configuration {
    /// <summary>
    /// Class containing global variables.
    /// </summary>
    public static class GlobalConfiguration {

        /// <summary>
        /// GUID that identify the store at Mundipagg.
        /// </summary>
        public static Guid MerchantKey = new Guid(ConfigurationManager.AppSettings["MundiPagg.MerchantKey"]);

    }
}
