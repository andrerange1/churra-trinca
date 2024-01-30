using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using AppService;
using Contracts;
using static Contracts.RunCreateNewBbq;

namespace Serverless_Api
{
    public partial class RunCreateNewBbq
    {
        private readonly LoggedPerson _user;
        private readonly IBbqAppService _bbqApp;
        private readonly IPersonAppService _personApp;

        public RunCreateNewBbq(LoggedPerson user, IPersonAppService personApp, IBbqAppService bbqApp)
        {
            _user = user;
            _bbqApp = bbqApp;
            _personApp = personApp;
        }

        [Function(nameof(RunCreateNewBbq))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "churras")] HttpRequestData req)
        {
            //user validation
            var loggedPersonId = _user.Id;

            if (String.IsNullOrEmpty(loggedPersonId))
            {
                return await req.CreateResponse(HttpStatusCode.Unauthorized, "Invalid User.");
            }

            //req validation
            var input = await req.Body<NewBbqRequest>();

            if (input is null)
            {
                return await req.CreateResponse(HttpStatusCode.BadRequest, "Input is required.");
            }

            //validating if it is a real user.
            var loggedPerson = await _personApp.GetAsync(loggedPersonId);

            if (loggedPerson is null)
            {
                return await req.CreateResponse(HttpStatusCode.Unauthorized, "Invalid User.");
            }

            //access the services through the app
            var response = await _bbqApp.CreateNew(input, loggedPersonId);

            return await req.CreateResponse(HttpStatusCode.Created, response);
        }
    }
}
