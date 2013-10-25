using MundiPaggClientSDK.Service;
using MundiPaggClientSDK.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MundiPaggClientSDK {
    /// <summary>
    /// Class responsible to comunicate with MundiPagg webservice.
    /// </summary>
    public sealed class GatewayClient {

        readonly BasicHttpBinding _binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);

        readonly EndpointAddress _productionAddress = new EndpointAddress("https://transaction.mundipaggone.com/MundiPaggService.svc");
        readonly EndpointAddress _sandboxAddress = new EndpointAddress("https://transaction.mundipaggone.com/MundiPaggService.svc");

        /// <summary>
        /// MundiPagg webservice endpoint.
        /// </summary>
        public EndpointAddress Endpoint { get; set; }

        public GatewayClient(EnvironmentEnum environmnent) {

            if (environmnent == EnvironmentEnum.Production) {
                this.Endpoint = this._productionAddress;
            }
            else {
                this.Endpoint = this._sandboxAddress;
            }


        }

        /// <summary>
        /// Method that call MundiPagg's CreateOrder method.
        /// </summary>
        /// <param name="request">Order data.</param>
        /// <returns></returns>
        public CreateOrderResponse CreateOrder(CreateOrderRequest request) {

            if (request == null) { throw new ArgumentNullException("request"); }
            if (request.MerchantKey == Guid.Empty) { throw new InvalidOperationException("Verify the MerchantKey provided."); }
            if (CreateOrderValidationRules.ExistTransactionInCollection(request) == false) { throw new ArgumentException("You have to create at least one transaction (credit card and/or boleto).", "request"); }

            using (MundiPaggServiceClient client = new MundiPaggServiceClient(this._binding, this.Endpoint)) {
                return client.CreateOrder(request);
            }

        }

        /// <summary>
        /// Calls ManageOrder method. Use to Capture or Void a transaction.
        /// </summary>
        /// <param name="request">Order or Transaction identifier to manage.</param>
        /// <returns></returns>
        public ManageOrderResponse ManageOrder(ManageOrderRequest request) {

            if (request == null) { throw new ArgumentNullException("request"); }
            if (request.MerchantKey == Guid.Empty) { throw new InvalidOperationException("Verify the MerchantKey provided."); }

            using (MundiPaggServiceClient client = new MundiPaggServiceClient(this._binding, this.Endpoint)) {
                return client.ManageOrder(request);
            }

        }

        /// <summary>
        /// Calls QueryOrder method to query a order in MundiPagg.
        /// </summary>
        /// <param name="request">Order data to query.</param>
        /// <returns></returns>
        public QueryOrderResponse QueryOrder(QueryOrderRequest request) {

            if (request == null) { throw new ArgumentNullException("request"); }
            if (request.MerchantKey == Guid.Empty) { throw new InvalidOperationException("Verify the MerchantKey provided."); }

            using (MundiPaggServiceClient client = new MundiPaggServiceClient(this._binding, this.Endpoint)) {
                return client.QueryOrder(request);
            }

        }

        /// <summary>
        /// Calls GetInstantBuyData method.
        /// </summary>
        /// <param name="request">Buyer token.</param>
        /// <returns>InstantBuy information related to the Buyer sent in the request.</returns>
        public GetInstantBuyDataResponse GetInstantBuyData(GetInstantBuyDataRequest request) {

            if (request == null) { throw new ArgumentNullException("request"); }
            if (request.MerchantKey == Guid.Empty) { throw new InvalidOperationException("Verify the MerchantKey provided."); }

            using (MundiPaggServiceClient client = new MundiPaggServiceClient(this._binding, this.Endpoint)) {
                return client.GetInstantBuyData(request);
            }

        }


    }
}
