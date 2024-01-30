using AppService;
using Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;
using static Contracts.RunModerateBbq;

namespace Serverless_Api
{
    public partial class RunModerateBbq
    {
        private readonly IBbqAppService _bbqApp;
        private readonly LoggedPerson _user;
        private readonly IPersonAppService _personApp;

        public RunModerateBbq(IBbqAppService bbqAppService, IPersonAppService personApp, LoggedPerson user)
        {
            _bbqApp = bbqAppService;
            _user = user;
            _personApp = personApp;
        }

        [Function(nameof(RunModerateBbq))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "put", Route = "churras/{id}/moderar")] HttpRequestData req, string id)
        {
            //user validation
            var loggedPersonId = _user.Id;
            if (String.IsNullOrEmpty(loggedPersonId))
            {
                return await req.CreateResponse(HttpStatusCode.BadRequest, "Input is required.");
            }

            //req validation
            var input = await req.Body<ModerateBbqRequest>();

            if (input == null)
            {
                return await req.CreateResponse(HttpStatusCode.BadRequest, "Input is required.");
            }

            //validating if it is a real user. This validations should be made in app layer.
            var loggedPerson = await _personApp.GetAsync(loggedPersonId);

            if (loggedPerson is null)
            {
                return await req.CreateResponse(HttpStatusCode.Unauthorized, "Invalid User.");
            }

            //validating if it is a IsCoOwner. This validations should be made in app layer.
            if (!loggedPerson.IsCoOwner)
            {
                return await req.CreateResponse(HttpStatusCode.Unauthorized, "Invalid User.");
            }

            var bbq = await _bbqApp.Moderate(input, id);

            return await req.CreateResponse(HttpStatusCode.OK, bbq);
        }
    }
}
