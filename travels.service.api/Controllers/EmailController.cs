using AutoMapper;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading.Tasks;
using travels.services.service;
using travels.dto.Dto.Request;
using travels.dto.Dto.Response;
using travels.notifications;
using travels.templates;
using travels.templates.Model;

namespace travels.service.api.Controllers
{
    [RoutePrefix("api/v1/email")]
    public class EmailController : ApiController
    {
        private const string Others = "OTHERS";
        private IEmailService EmailService { get; }
        private EmailTemplates EmailTemplate { get; }

        public EmailController(IEmailService EmailService, EmailTemplates EmailTemplate)
        {
            this.EmailService = EmailService;
            this.EmailTemplate = EmailTemplate;
        }



        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(string id)
        {
            return Ok("ping");
        }


        [HttpPost]
        [Route("send")]
        public async Task<IHttpActionResult> SendEmail([FromBody] EmailRequest emailRequest)
        {
            if (emailRequest.CustomTrips.Count > 0 && emailRequest.CustomTrips.Contains(Others))
                emailRequest.CustomTrips.Remove(Others);

            NotificationMessage message = new NotificationMessage();
            message.To = emailRequest.Email;
            message.Message = EmailTemplate.getTemplate(TempalteType.CustomizedTripsInfo, Mapper.Map<CustomizedTripsInfoModel>(emailRequest));
            message.Name = emailRequest.FirstName + " " + emailRequest.LastName;
            message.Title = "Customized Trips";
            await EmailService.SendEmail(message);

            return Ok();
        }

        [HttpPost]
        [Route("contact")]
        public async Task<IHttpActionResult> SendEmailContactUs([FromBody] ContactRequest emailRequest)
        {
            NotificationMessage message = new NotificationMessage();
            message.To = emailRequest.Email;
            message.Message = EmailTemplate.getTemplate(TempalteType.ContactInfo, Mapper.Map<ContactInfoModel>(emailRequest));
            message.Name = emailRequest.Name;
            message.Title = "Contact - " + message.Name;
            await EmailService.SendEmail(message);

            return Ok();
        }

        [HttpPost]
        [Route("requestinfo")]
        public async Task<IHttpActionResult> SendEmailRequestInfo([FromBody] ProgramInfoRequest emailRequest)
        {                        
            NotificationMessage message = new NotificationMessage();
            message.To = emailRequest.Email;
            message.Message = EmailTemplate.getTemplate(TempalteType.RequestInfo, Mapper.Map<RequestInfoModel>(emailRequest));
            message.Name = emailRequest.Name;
            message.Title = "Request Info for - " + emailRequest.Program;
            await EmailService.SendEmail(message);

            return Ok();
        }

        [HttpPost]
        [Route("enroll")]
        public async Task<IHttpActionResult> SendEmailEnroll([FromBody] EnrollRequest emailRequest)
        {
            NotificationMessage message = new NotificationMessage();
            message.To = emailRequest.ParentEmail;
            message.Message = EmailTemplate.getTemplate(TempalteType.EnrollInfo, Mapper.Map<EnrollInfoModel>(emailRequest));
            message.Name = emailRequest.FullName;
            message.Title = "Enroll for - " + emailRequest.Program;
            await EmailService.SendEmail(message);

            return Ok();
        }
    }
}
