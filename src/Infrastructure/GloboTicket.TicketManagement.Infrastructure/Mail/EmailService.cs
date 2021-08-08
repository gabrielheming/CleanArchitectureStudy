using System.Threading.Tasks;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Models.Mail;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace GloboTicket.TicketManagement.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            this.emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmailAsync(Email email)
        {
            SendGridClient client = new SendGridClient(emailSettings.ApiKey);

            string subject = email.Subject;
            EmailAddress to = new EmailAddress(email.To);
            string emailBody = email.Body;

            EmailAddress from = new EmailAddress
            {
                Email = emailSettings.FromAddress,
                Name = emailSettings.FromName
            };

            SendGridMessage sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            Response response = await client.SendEmailAsync(sendGridMessage);

            return (
                response.StatusCode == System.Net.HttpStatusCode.Accepted
                || response.StatusCode == System.Net.HttpStatusCode.OK
            );
        }
    }
}