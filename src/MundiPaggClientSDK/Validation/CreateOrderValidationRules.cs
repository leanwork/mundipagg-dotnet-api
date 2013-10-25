using MundiPaggClientSDK.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundiPaggClientSDK.Validation {
    public static class CreateOrderValidationRules {

        /// <summary>
        /// Check if exist at least one transaction inside the request.
        /// </summary>
        /// <param name="request">CreateOrderRequest instance.</param>
        /// <returns>TRUE if is valid otherwise FALSE.</returns>
        public static bool ExistTransactionInCollection(CreateOrderRequest request) {

            bool result = false;

            if ((request.BoletoTransactionCollection != null && request.BoletoTransactionCollection.Count > 0) ||
                (request.CreditCardTransactionCollection != null && request.CreditCardTransactionCollection.Count > 0)) {

                result = true;

            }


            return result;
        }

    }
}
