using AppService;
using Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;

namespace Serverless_Api
{
    public partial class RunGetInvites
    {
        private readonly LoggedPerson _user;
        private readonly IPersonAppService _personApp;


        public RunGetInvites(LoggedPerson user, IPersonAppService personApp)
        {
            _user = user;
            _personApp = personApp;
        }

        [Function(nameof(RunGetInvites))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "person/invites")] HttpRequestData req)
        {

            //user validation
            var loggedPersonId = _user.Id;
            if (String.IsNullOrEmpty(loggedPersonId))
            {
                return await req.CreateResponse(HttpStatusCode.Unauthorized, "Invalid User.");
            }

            var loggedPerson = await _personApp.GetAsync(loggedPersonId);

            if (loggedPerson is null)
            {
                return await req.CreateResponse(HttpStatusCode.Unauthorized, "Invalid User.");
            }

            var response = await _personApp.GetProposedBbqs(loggedPersonId);

            return await req.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
