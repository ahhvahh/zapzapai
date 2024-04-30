using Microsoft.AspNetCore.Mvc;
using Twilio.TwiML;
using Twilio.AspNet.Core;
using WhatAppIntegration.Domain;

namespace WhatsAppIntegration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WhatsAppController : TwilioController
    {
        [HttpPost]
        public IActionResult ReceiveMessageFromTwilio([FromForm] string From, [FromForm] string Body)
        {
            var log = new LogDomain();

            // Logica para processar a mensagem recebida
            log.LogMessage(From, Body);

            try
            {
                // Responder ao Twilio
                string responseMessage = $"Recebido de {From}: {Body}";
                var twilioResponse = new ContentResult
                {
                    ContentType = "text/xml",
                    Content = $"<Response><Message>{responseMessage}</Message></Response>",
                    StatusCode = 200
                };
                return twilioResponse;
            }
            catch (Exception ex)
            {
                log.LogMessage(From, ex.Message);
                return BadRequest("Erro:" + ex.Message);
            }
        }
    }
}
