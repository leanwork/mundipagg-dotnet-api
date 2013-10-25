using MundiPaggClientSDK.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Web;

namespace MundiPaggClientSDK {
    /// <summary>
    /// Class that handles parser POST Notification XML.
    /// </summary>
    public static class PostNotificationParser {

        /// <summary>
        /// Method to parser POST Notification XML.
        /// </summary>
        /// <param name="postNotificationXml">POST notification </param>
        /// <returns></returns>
        public static StatusNotification Parse(string postNotificationXml) {

            if (string.IsNullOrWhiteSpace(postNotificationXml) == true) { throw new ArgumentNullException("postNotificationXml"); }
            
            postNotificationXml = HttpUtility.HtmlDecode(postNotificationXml);

            XmlSerializer serializer = new XmlSerializer(typeof(StatusNotification));

            byte[] xmlByteArray = UTF8Encoding.Default.GetBytes(postNotificationXml);
            MemoryStream stream = new MemoryStream(xmlByteArray);

            StatusNotification notification = serializer.Deserialize(stream) as StatusNotification;

            return notification;

        }

    }


}



