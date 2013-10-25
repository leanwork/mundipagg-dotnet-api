using Microsoft.VisualStudio.TestTools.UnitTesting;
using MundiPaggClientSDK.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MundiPaggClientSDK.Test {

    [TestClass]
    public class PostNotificationTest {


        public string Xml { get; set; }

        [TestInitialize]
        public void Init() {
            this.Xml = HttpUtility.HtmlEncode("<StatusNotification xmlns=\"http://schemas.datacontract.org/2004/07/MundiPagg.NotificationService.DataContract\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"><AmountInCents>24470</AmountInCents><AmountPaidInCents>0</AmountPaidInCents><BoletoTransaction><AmountInCents>24470</AmountInCents><AmountPaidInCents>24470</AmountPaidInCents><BoletoExpirationDate>2013-10-29T00:00:00</BoletoExpirationDate><NossoNumero>00006746</NossoNumero><StatusChangedDate>2013-10-25T04:09:46.397</StatusChangedDate><TransactionKey>bcf3dc54-22be-4690-b1c8-c88d95eb50a1</TransactionKey><TransactionReference>6746</TransactionReference><PreviousBoletoTransactionStatus>Generated</PreviousBoletoTransactionStatus><BoletoTransactionStatus>Paid</BoletoTransactionStatus></BoletoTransaction><CreditCardTransaction i:nil=\"true\"/><MerchantKey>23c4f5fe-7d1d-41f8-a899-329e7938c478</MerchantKey><OrderKey>1b809598-1f2b-4bf8-bad3-d5e225d34fef</OrderKey><OrderReference>6746</OrderReference><OrderStatus>Paid</OrderStatus></StatusNotification>");
        }


        [TestMethod]
        public void ParseXML() {

            StatusNotification notification = PostNotificationParser.Parse(this.Xml);

            Assert.IsNotNull(notification);
            Assert.IsNotNull(notification.BoletoTransaction);
            Assert.AreEqual(notification.AmountInCents, 24470L);
            Assert.AreEqual(notification.MerchantKey, new Guid("23c4f5fe-7d1d-41f8-a899-329e7938c478"));
            Assert.AreEqual(notification.OrderReference, "6746");
            Assert.AreEqual(notification.OrderStatus, "Paid");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TryParseNullXML() {

            StatusNotification notification = PostNotificationParser.Parse(null);

        }

    }

}
