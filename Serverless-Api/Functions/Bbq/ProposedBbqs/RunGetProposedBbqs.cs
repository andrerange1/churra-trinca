using System.Net;
using AppService;
using Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using static Contracts.RunCreateNewBbq;

namespace Serverless_Api
{
    public partial class RunGetProposedBbqs
    {
        private readonly LoggedPerson _user;

        private readonly IPersonAppService _personApp;
        private readonly IBbqAppService _bbqApp;

        public RunGetProposedBbqs(LoggedPerson user, IPersonAppService personApp, IBbqAppService bbqApp)
        {
            _user = user;
            _personApp = personApp;
            _bbqApp = bbqApp;
        }

        [Function(nameof(RunGetProposedBbqs))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "churras")] HttpRequestData req)
        {

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
