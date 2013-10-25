using Microsoft.VisualStudio.TestTools.UnitTesting;
using MundiPaggClientSDK.Configuration;
using MundiPaggClientSDK.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundiPaggClientSDK.Test {

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class ManageOrderTest {
        
        public GatewayClient Client { get; set; }

        [TestInitialize]
        public void Init() {
            this.Client = new GatewayClient(EnvironmentEnum.Sandbox);
        }
                
        private CreateOrderResponse AuthorizeTransaction() {

            CreateOrderRequest request = new CreateOrderRequest();

            request.MerchantKey = GlobalConfiguration.MerchantKey;
            request.OrderReference = string.Format("dotNETOrder{0}", new Random(DateTime.Now.Millisecond).Next());
            request.AmountInCents = new Random().Next(1, 120);
            request.CurrencyIsoEnum = CurrencyIsoEnum.BRL;
            request.EmailUpdateToBuyerEnum = EmailUpdateToBuyerEnum.No;

            request.CreditCardTransactionCollection = new System.Collections.Generic.List<CreditCardTransaction>();

            request.CreditCardTransactionCollection.Add(new CreditCardTransaction() {

                CreditCardOperationEnum = CreditCardOperationEnum.AuthOnly,
                AmountInCents = request.AmountInCents,
                CreditCardBrandEnum = CreditCardBrandEnum.Visa,
                CreditCardNumber = "41111111111111",
                SecurityCode = "123",
                InstallmentCount = 1,
                HolderName = "Stanley Martin Lieber",
                ExpMonth = 11,
                ExpYear = 2019,
                PaymentMethodCode = 1

            });


            CreateOrderResponse response = this.Client.CreateOrder(request);

            return response;
        }

        [TestMethod]
        public void CreatingValidManageOrder() {

            CreateOrderResponse responseAuth = this.AuthorizeTransaction();

            ManageOrderRequest request = new ManageOrderRequest();

            request.MerchantKey = GlobalConfiguration.MerchantKey;
            request.ManageOrderOperationEnum = ManageOrderOperationEnum.Capture;
            request.OrderKey = responseAuth.OrderKey;


            ManageOrderResponse response = this.Client.ManageOrder(request);

            Assert.IsTrue(response.Success);        
    
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreatingInvalidManageOrder() {

            CreateOrderResponse responseAuth = this.AuthorizeTransaction();

            ManageOrderRequest request = new ManageOrderRequest();

            request.MerchantKey = Guid.Empty;
            request.ManageOrderOperationEnum = ManageOrderOperationEnum.Capture;
            request.OrderKey = responseAuth.OrderKey;
            
            ManageOrderResponse response = this.Client.ManageOrder(request);
                      
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatingNullManageOrder() {

            ManageOrderRequest request = null;

            ManageOrderResponse response = this.Client.ManageOrder(request);

        }

    }

}
