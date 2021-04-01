using Infraestructura;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace Dominio.Recursos
{
    public class Correo
    {
        Infraestructura.CRUD.BDClientesBonos _BDClientesBonos = new Infraestructura.CRUD.BDClientesBonos();

        public void Sencillo(string CorreoRemitente, string ClaveMail, string ServidorDeCorreo, int Puerto, bool SSL,
               string Mascara, string Asunto, string Mensaje, string CorreoUsuario)
        {
            MailAddress fromAddress = new MailAddress(CorreoRemitente, Mascara);

            SmtpClient smtp = new SmtpClient(ServidorDeCorreo);
            smtp.Port = Puerto;
            smtp.EnableSsl = SSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(CorreoRemitente, ClaveMail);
            smtp.Timeout = 200000;
            MailMessage message = new MailMessage();
            message.To.Add(CorreoUsuario);
            message.From = fromAddress;
            message.Subject = Asunto;
            message.Body = (" <font face=\"Verdana\">" + (Mensaje + "")); ;
            message.IsBodyHtml = true;

            try
            {
                smtp.Send(message);
            }
            catch (Exception Ex)
            {
                var Respuesta = Ex.Message.ToString();
            }
        }

        public void Adjunto(string CorreoRemitente, string ClaveMail, string ServidorDeCorreo, int Puerto, bool SSL,
               string Mascara, string Asunto, string Mensaje, string RutaArchivos, string CorreoUsuario)
        {
            MailAddress fromAddress = new MailAddress(CorreoRemitente, Mascara);

            SmtpClient smtp = new SmtpClient(ServidorDeCorreo);
            smtp.Port = Puerto;
            smtp.EnableSsl = SSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(CorreoRemitente, ClaveMail);
            smtp.Timeout = 200000;
            MailMessage message = new MailMessage();
            message.To.Add(CorreoUsuario);
            message.From = fromAddress;
            message.Subject = Asunto;
            message.Body = (" <font face=\"Verdana\">" + (Mensaje + ""));
            message.IsBodyHtml = true;

            string[] Archivos = Directory.GetFiles(RutaArchivos);
            foreach (string Archivo in Archivos)
            {
                Attachment ArchAdjunto = new Attachment(Archivo);
                message.Attachments.Add(ArchAdjunto);
            }

            try
            {
                smtp.Send(message);
            }
            catch (Exception Ex)
            {
                var Respuesta = Ex.Message.ToString();
            }
        }

        public string Banner(string CorreoRemitente, string ClaveMail, string ServidorDeCorreo, int Puerto, bool SSL,
               string Mascara, string Asunto, string CorreoCliente, string Html)
        {
            MailAddress fromAddress = new MailAddress(CorreoRemitente, Mascara);

            SmtpClient smtp = new SmtpClient(ServidorDeCorreo);
            smtp.Port = Puerto;
            smtp.EnableSsl = SSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(CorreoRemitente, ClaveMail);
            smtp.Timeout = 200000;
            MailMessage message = new MailMessage();
            message.To.Add(CorreoCliente);
            message.From = fromAddress;
            message.Subject = Asunto;
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.ASCII;

            message.Body = Html;

            try
            {
                smtp.Send(message);
                return "Importacion exitosa";
            }
            catch (Exception Ex)
            {
                return Ex.Message.ToString();
            }
        }

        public string Banner(string CorreoRemitente, string ClaveMail, string ServidorDeCorreo, int Puerto, bool SSL,
               string Mascara, string Asunto, string CorreoReferido, string Empleado, string Referido, string RutaBanner)
        {
            MailAddress fromAddress = new MailAddress(CorreoRemitente, Mascara);

            SmtpClient smtp = new SmtpClient(ServidorDeCorreo);
            smtp.Port = Puerto;
            smtp.EnableSsl = SSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(CorreoRemitente, ClaveMail);
            smtp.Timeout = 200000;
            MailMessage message = new MailMessage();
            message.To.Add(CorreoReferido);
            message.From = fromAddress;
            message.Subject = Asunto;
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.ASCII;

            var Html = File.ReadAllText(RutaBanner);
            Html = Html.Replace("Empleado", Empleado).Replace("Referido", Referido);

            message.Body = Html;

            try
            {
                smtp.Send(message);
                return "Importacion exitosa";
            }
            catch (Exception Ex)
            {
                return Ex.Message.ToString();
            }
        }

        public string Banner(string CorreoRemitente, string ClaveMail, string ServidorDeCorreo, int Puerto, bool SSL,
               string Mascara, string Asunto, string CorreoCliente, string NombreCliente, string DocumentoCliente,
               string Factura, string ValorTotal, int CantidadBonos, string ValorBono, string Marca, string RutaBanner)
        {
            var Resultado = ModificarHtml(NombreCliente, DocumentoCliente, Factura, ValorTotal,
                                       CantidadBonos, ValorBono, Marca, RutaBanner).Split('~');

            MailAddress fromAddress = new MailAddress(CorreoRemitente, Mascara);

            SmtpClient smtp = new SmtpClient(ServidorDeCorreo);
            smtp.Port = Puerto;
            smtp.EnableSsl = SSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(CorreoRemitente, ClaveMail);
            smtp.Timeout = 200000;
            MailMessage message = new MailMessage();
            message.To.Add(CorreoCliente);
            message.From = fromAddress;
            message.Subject = Asunto + Factura;
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.ASCII;
            message.Body = Resultado[2];

            try
            {
                if (Resultado[3].Contains("Importacion exitosa"))
                {
                    smtp.Send(message);
                    return Resultado[0] + '~' + Resultado[1] + '~' + Resultado[2] + '~' + Resultado[3];
                }
                else
                {
                    return Resultado[0] + '~' + Resultado[1] + '~' + Resultado[2] + '~' + Resultado[3];
                }
            }
            catch (Exception Ex)
            {
                return Resultado[0] + '~' + Resultado[1] + '~' + Resultado[2] + '~' + Ex.Message.ToString();
            }
        }

        public string ModificarHtml(string NombreCliente, string DocumentoCliente, string Factura, string ValorTotal,
            int CantidadBonos, string ValorBono, string Marca, string RutaBanner)
        {
            try
            {
                var HtmlEncabezado = string.Empty;
                var HtmlMovimiento = string.Empty;
                var ConjuntoBonos = string.Empty;
                var CodigoBono = Convert.ToInt32(_BDClientesBonos.Sp_ValidarCodigoBono(Marca).Tables[0].Rows[0]["CodigoBono"]);
                var Html = File.ReadAllText(RutaBanner);

                if (CodigoBono != 0)
                {
                    HtmlEncabezado += "<strong>NOMBRE:</strong>" + " " + NombreCliente + "<br>" +
                                         "<strong>ID:</strong>" + " " + DocumentoCliente + "<br>" +
                                         "<strong>FACTURA:</strong>" + " " + Factura + "<br>" +
                                         "<strong>VR. FACTURA:</strong>" + " " + ValorTotal + "<br>";

                    Html = Html.Replace("<strong>NOMBRE:</strong>nombre<br><strong>ID:</strong>id<br><strong>FACTURA:</strong>factura<br><strong>VR. FACTURA:</strong>valorFactura<br>", HtmlEncabezado);

                    for (int i = 0; i < CantidadBonos; i++)
                    {
                        int Cantidad = i + 1;
                        HtmlMovimiento += "<strong>CODIGO " + Cantidad + ":</strong>" + CodigoBono + "<strong> VALOR:</strong>" + ValorBono + "<br>";

                        if (CantidadBonos == i + 1)
                        {
                            ConjuntoBonos += CodigoBono;
                        }
                        else
                        {
                            ConjuntoBonos += CodigoBono + "-";
                            CodigoBono++;
                        }
                    }

                    Html = Html.Replace("<strong>CODIGO:</strong>BONO<strong> VALOR:</strong>VALOR<br>", HtmlMovimiento);

                    return ConjuntoBonos + "~" + CodigoBono + "~" + Html + "~" + "Importacion exitosa";
                }
                else
                {
                    return ConjuntoBonos + "~" + CodigoBono + "~" + Html + "~" + "No hay mas codigos que asignar a esta marca.";
                }

            }
            catch (Exception Ex)
            {
                return "" + "~" + "" + "~" + "No Hay Html" + "~" + Ex.Message.ToString();
            }
        }
    }
}
