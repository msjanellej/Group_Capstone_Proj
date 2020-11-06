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
        public static  string qrCode;
        
        public static  string GetQRCode(Order order)
        {
            QRCodeWriter.CreateQrCode(order.Id.ToString(), 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsHtmlFile("QRCode.html");
            qrCode = QRCodeWriter.CreateQrCode(order.Id.ToString(), 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).ToHtmlTag();
            return qrCode;
        }




    }
}
