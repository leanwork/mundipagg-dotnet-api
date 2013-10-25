using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MundiPaggClientSDK;
using MundiPaggClientSDK.Service;
using MundiPaggClientSDK.Configuration;

namespace MundiPaggClientSDK.Test {

    [TestClass]
    public class CreateOrderTest {

        [TestMethod]
        public void CreatingAValidOrder() {

            GatewayClient client = new GatewayClient(EnvironmentEnum.Sandbox);

            CreateOrderRequest request = new CreateOrderRequest();

            request.MerchantKey = GlobalConfiguration.MerchantKey;
            request.OrderReference = string.Format("dotNETOrder{0}", new Random(DateTime.Now.Millisecond).Next());
            request.AmountInCents = new Random().Next(1,120);
            request.CurrencyIsoEnum = CurrencyIsoEnum.BRL;
            request.EmailUpdateToBuyerEnum = EmailUpdateToBuyerEnum.No;

            request.CreditCardTransactionCollection = new System.Collections.Generic.List<CreditCardTransaction>();

            request.CreditCardTransactionCollection.Add(new CreditCardTransaction() {

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


            CreateOrderResponse response = client.CreateOrder(request);

            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.ErrorReport == null);

        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void CreatingAInvalidOrder() {


            GatewayClient client = new GatewayClient(EnvironmentEnum.Sandbox);

            CreateOrderRequest request = new CreateOrderRequest();
            request.CreditCardTransactionCollection = new System.Collections.Generic.List<CreditCardTransaction>();

            request.OrderReference = string.Format("dotNETOrder{0}", new Random(DateTime.Now.Millisecond).Next());
            request.AmountInCents = new Random().Next(1, 120);
            request.CurrencyIsoEnum = CurrencyIsoEnum.BRL;
            request.EmailUpdateToBuyerEnum = EmailUpdateToBuyerEnum.No;
            request.CreditCardTransactionCollection.Add(new CreditCardTransaction() {

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


            CreateOrderResponse response = client.CreateOrder(request);

        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CreatingAEmptyOrder() {
            
            GatewayClient client = new GatewayClient(EnvironmentEnum.Sandbox);

            CreateOrderRequest request = null;

            CreateOrderResponse response = client.CreateOrder(request);

        }

    }
}
