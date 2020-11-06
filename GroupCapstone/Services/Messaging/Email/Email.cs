using GroupCapstone.Models;
using IronBarCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCapstone.Services.Messaging.Email
{
    public static class Email
    {
        public static string qrCode;
        public static string EmailSubject = "Your order is ready to pick up";
        public static string EmailBody = "<h6>Thank you!</h6><br><div>for placing your order with us!<br>" +
            "Please show the QR code to the employee when you arrive for your pick up. Thank you.</div>" +
            "<div>" + qrCode + "</div>" ;
        public static string GetQRCode(Order order)
        {
            QRCodeWriter.CreateQrCode(order.Id.ToString(), 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsHtmlFile("QRCode.html");
            qrCode = QRCodeWriter.CreateQrCode(order.Id.ToString(), 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).ToHtmlTag();
            return qrCode;
        }




    }
}
