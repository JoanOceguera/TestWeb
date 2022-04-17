using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EmailSender
    {
        public static void Sender (string direccion, int subjectCode, int bodyCode, string attachments)
        {
            MailMessage email = new MailMessage();
            SmtpClient client = new SmtpClient();
            email.To.Add(direccion);
            email.Subject = SubjectText(subjectCode);
            email.SubjectEncoding = System.Text.Encoding.UTF8;
            email.Body = BodyText(bodyCode);
            email.BodyEncoding = System.Text.Encoding.UTF8;
            email.IsBodyHtml = false;
            if (!attachments.Equals(""))
            {
                Attachment archivo = new Attachment(attachments);
                email.Attachments.Add(archivo);
            }
            client.Send(email);

        }

        public static void Sender(string direccion, string subject, string body, string attachments)
        {
            MailMessage email = new MailMessage();
            SmtpClient client = new SmtpClient();
            email.To.Add(direccion);
            email.Subject = subject;
            email.SubjectEncoding = System.Text.Encoding.UTF8;
            email.Body = body;
            email.BodyEncoding = System.Text.Encoding.UTF8;
            email.IsBodyHtml = false;
            if (!attachments.Equals(""))
            {
                Attachment archivo = new Attachment(attachments);
                email.Attachments.Add(archivo);
            }
            client.Send(email);

        }

        public static string SubjectText(int id)
        {
            string subject = "";
            switch (id)
            {
                case (1):
                    subject = "Notificación de Usuario Nuevo";
                    break;
                case (2):
                    subject = "Notificación de Cambio de Correo";
                    break;
            }
            return subject;

        }

        public static string BodyText(int id)
        {
            string body = "";
            switch (id)
            {
                case (1):
                    body = "Buenos Días: \nEl presente correo le llega como una manera de verificar si su correo es una cuenta de correo válida. \nEsta verificación es hecha al registrarse un nuevo usuario en la aplicación Servired usando su correo. \nSaludos y disculpe las molestias ocasionadas. \nAtentamente,\nDepartamento de Informática.";
                    break;
                case (2):
                    body = "Buenos Días: \nEl presente correo le llega como una manera de verificar si su correo es una cuenta de correo válida. \nEsta verificación es hecha al modificarse el correo de un usuario en la aplicación Servired usando su correo. \nSaludos y disculpe las molestias ocasionadas.\nAtentamente,\nDepartamento de Informática.";
                    break;
            }
            return body;

        }

    }
}
