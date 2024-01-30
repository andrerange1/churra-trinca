using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Contracts;
using System.Net;
using AppService;
using static Contracts.RunAcceptInvite;

namespace Serverless_Api
{
    public partial class RunAcceptInvite
    {
        private readonly LoggedPerson _user;
        private readonly IPersonAppService _personApp;

        public RunAcceptInvite(IPersonAppService personApp, LoggedPerson user)
        {
            _user = user;
            _personApp = personApp;
        }

        [Function(nameof(RunAcceptInvite))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "put", Route = "person/invites/{inviteId}/accept")] HttpRequestData req, string inviteId)
        {
            //user validation
            var loggedPersonId = _user.Id;
            if (String.IsNullOrEmpty(loggedPersonId))
            {
                return await req.CreateResponse(HttpStatusCode.Unauthorized, "Invalid User.");
            }

            //req validation
            var answer = await req.Body<InviteAnswer>();
            if (answer == null)
            {
                return await req.CreateResponse(HttpStatusCode.BadRequest, "Input is required.");
            }

            var loggedPerson = await _personApp.GetAsync(loggedPersonId); 

            if (loggedPerson is null)
            {
                return await req.CreateResponse(HttpStatusCode.Unauthorized, "Invalid User.");
            }

            var response = await _personApp.AcceptInvite(loggedPerson.Id, answer, inviteId);

            return await req.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
