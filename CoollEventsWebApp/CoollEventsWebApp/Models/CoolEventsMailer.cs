using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Windows;

namespace CoollEventsWebApp.Models {
    public class CoolEventsMailer {
        private string Body { get; set; }
        public string Assunto { get; set; }


        MailMessage mm = new MailMessage();

        public void AdicionarEmail(string adr) {
            mm.To.Add(new MailAddress(adr));
        }

        public void Enviar() {

            //Servidor smtp
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("coollevents@gmail.com", "TCCEtesp2019");
            //Mensagem
            mm.From = new MailAddress("coollevents@gmail.com", "CoolEvents", Encoding.UTF8);
            mm.Body = Body;
            mm.IsBodyHtml = true;
            mm.Subject = Assunto;
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm); //envia os emails

        }

        public void SetBody(string Nome, string Email, string Mensagem) {
            String BodyLayout = @"
                <b> Nome: </b> ##Nome <br/>
                <b> Email: </b> ##Email <br/>
                <b> Assunto: </b> ##Assunto <br/>
                <b> Mensagem: </b> ##Mensagem <br/>
            ";

            this.Body = BodyLayout.Replace("##Nome", Nome).Replace("##Email", Email).Replace("##Mensagem", Mensagem).Replace("##Assunto", this.Assunto);
        }
    }
}

