using AutoMapper;
using Domain.Repository;
using MimeKit;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.Repository
{
    public class CorreoService : ICorreoService
    {
        private readonly IConfigRepository _entityRepository;
        private readonly IMapper _mapper;
        public CorreoService(IConfigRepository configRepository, IMapper mapper)
        {
            _entityRepository = configRepository;
            _mapper = mapper;
        }

        public async Task<bool> EnviarCorreo(string AliasOrigen, string CorreoDestino, string Asunto, string Mensaje)
        {
            try
            {
                var query = await _entityRepository.GetByRecursoAsync("Servicio_Correo");
                Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);

                var credenciales = new NetworkCredential(Config["correo"], Config["clave"]);
                var correo = new MailMessage()
                {
                    From = new MailAddress(Config["correo"], AliasOrigen),
                    Subject = Asunto,
                    Body = Mensaje,
                    IsBodyHtml = true
                };

                correo.To.Add(new MailAddress(CorreoDestino));

                var clienteServidor = new SmtpClient()
                {
                    Host = Config["host"],
                    Port = int.Parse(Config["puerto"]),
                    Credentials = credenciales,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                };
                clienteServidor.Send(correo);
                return true;

            }
            catch
            {
                return false;
            }
        }

        //public async void SendEmail(EmailDTO request)
        //{
        //    var query = await _entityRepository.GetByRecursoAsync("Servicio_Correo");
        //    Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);
        //    var email = new MimeMessage();
        //    email.From.Add(MailboxAddress.Parse(Config["correo"]));
        //    email.To.Add(MailboxAddress.Parse(request.Para));
        //    email.Subject = request.Asunto;
        //    email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = request.Contenido };

        //    var credenciales = new NetworkCredential(Config["correo"], Config["clave"]);
        //    var clienteServidor = new SmtpClient()
        //    {
        //        Host = Config["host"],
        //        Port = int.Parse(Config["puerto"]),
        //        Credentials = credenciales,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false,
        //        EnableSsl = true,
        //    };
        //}
    }
}
