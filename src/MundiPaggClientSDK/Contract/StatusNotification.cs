using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MundiPaggClientSDK.Contract {
    /// <summary>
    /// Class containing information sent in POST notification.
    /// </summary>
    [XmlRoot(Namespace = @"http://schemas.datacontract.org/2004/07/MundiPagg.NotificationService.DataContract", ElementName = "StatusNotification")]
    [Serializable]
    public class StatusNotification {

        /// <summary>
        /// Order amount in cents.
        /// </summary>
        public long AmountInCents { get; set; }

        /// <summary>
        /// Order amount paid in cents.
        /// </summary>
        public long AmountPaidInCents { get; set; }

        /// <summary>
        /// Boleto transaction that generated the notification.
        /// </summary>
        [XmlElement(ElementName = "BoletoTransaction", IsNullable = true)]
        public PostNotificationBoletoTransaction BoletoTransaction { get; set; }

        /// <summary>
        /// Credit card transaction that generated the notification.
        /// </summary>
        [XmlElement(ElementName = "CreditCardTransaction", IsNullable = true)]
        public PostNotificationCreditCardTransaction CreditCardTransaction { get; set; }

        /// <summary>
        /// Merchat key being notified.
        /// </summary>
        public Guid MerchantKey { get; set; }

        /// <summary>
        /// Order key that generated the notification.
        /// </summary>
        public Guid OrderKey { get; set; }

        /// <summary>
        /// Order Reference.
        /// </summary>
        public string OrderReference { get; set; }

        /// <summary>
        /// Updated order status.
        /// </summary>
        public string OrderStatus { get; set; }


        /// <summary>
        /// Class containing the boleto information who may generated the notification.
        /// </summary>
        [Serializable]
        public class PostNotificationBoletoTransaction {

            /// <summary>
            /// Transaction amount in cents.
            /// </summary>
            public long AmountInCents { get; set; }

            /// <summary>
            /// Transaction amount paid.
            /// </summary>
            public long AmountPaidInCents { get; set; }

            /// <summary>
            /// Boleto expiration date.
            /// </summary>
            public DateTime BoletoExpirationDate { get; set; }

            /// <summary>
            /// Boleto number.
            /// </summary>
            public string NossoNumero { get; set; }

            /// <summary>
            /// Date indicating when the status changed.
            /// </summary>
            public DateTime StatusChangedDate { get; set; }

            /// <summary>
            /// Transaction key.
            /// </summary>
            public Guid TransactionKey { get; set; }

            /// <summary>
            /// Transaction reference.
            /// </summary>
            public string TransactionReference { get; set; }

            /// <summary>
            /// Previous transaction status.
            /// </summary>
            public string PreviousBoletoTransactionStatus { get; set; }

            /// <summary>
            /// New transaction status.
            /// </summary>
            public string BoletoTransactionStatus { get; set; }



        }

        /// <summary>
        /// Class containing the credit card information who may generated the notification.
        /// </summary>
        [Serializable]
        public class PostNotificationCreditCardTransaction {

            /// <summary>
            /// Acquirer who processed the transaction.
            /// </summary>
            public string Acquirer { get; set; }

            /// <summary>
            /// Transaction amount in cents.
            /// </summary>
            public long AmountInCents { get; set; }

            /// <summary>
            /// Transaction amount authorized.
            /// </summary>
            public long AuthorizedAmountInCents { get; set; }

            /// <summary>
            /// Transaction amount captured.
            /// </summary>
            public long CapturedAmountInCents { get; set; }

            /// <summary>
            /// Credit card brand.
            /// </summary>
            public string CreditCardBrand { get; set; }

            /// <summary>
            /// Transaction amount refunded.
            /// </summary>
            public long RefundedAmountInCents { get; set; }

            /// <summary>
            /// Date indicating when the status changed.
            /// </summary>
            public DateTime StatusChangedDate { get; set; }

            /// <summary>
            /// Transaction identifier.
            /// </summary>
            public string TransactionIdentifier { get; set; }

            /// <summary>
            /// Transaction key.
            /// </summary>
            public Guid TransactionKey { get; set; }

            /// <summary>
            /// Transaction reference.
            /// </summary>
            public string TransactionReference { get; set; }

            /// <summary>
            /// Acquirer unique sequential number.
            /// </summary>
            public string UniqueSequentialNumber { get; set; }

            /// <summary>
            /// Transaction amount voided.
            /// </summary>
            public long VoidedAmountInCents { get; set; }

            /// <summary>
            /// Previous transaction status.
            /// </summary>
            public string PreviousCreditCardTransactionStatus { get; set; }

            /// <summary>
            /// New transaction status.
            /// </summary>
            public string CreditCardTransactionStatus { get; set; }

        }

    }
}
