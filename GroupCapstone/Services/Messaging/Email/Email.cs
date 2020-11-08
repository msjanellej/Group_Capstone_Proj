using GroupCapstone.Models;
using IronBarCode;
using Microsoft.AspNetCore.Routing.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCapstone.Services.Messaging.Email
{
    public static class Email
    {
        public static string qrCode;
        
        public static string GetQRCode(Order order)
        {
            string sourceFile = System.IO.Path.Combine("", "template.pdf");
            string destFile = System.IO.Path.Combine("", "qrCode.pdf");
            System.IO.File.Copy(sourceFile, destFile, true);
           
            string qrString = "https://groupcapstone.conveyor.cloud/" + order.Id.ToString();
            QRCodeWriter.CreateQrCodeWithLogo(qrString, "logo.png", 150).StampToExistingPdfPage("qrcode.pdf", 200, 200, 1);
            qrCode = QRCodeWriter.CreateQrCode(order.Id.ToString(), 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).ToHtmlTag();
            return qrCode;
        }




    }
}
