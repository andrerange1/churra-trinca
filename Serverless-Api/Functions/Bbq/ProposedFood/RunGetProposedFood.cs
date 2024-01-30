using AppService;
using Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;
using static Contracts.RunModerateBbq;

namespace Serverless_Api.Functions.Bbq.ProposedFood
{
    public partial class RunGetProposedFood
    {
        private readonly LoggedPerson _user;
        private readonly IPersonAppService _personApp;
        private readonly IBbqAppService _bbqApp;

        public RunGetProposedFood(LoggedPerson user, IPersonAppService personApp, IBbqAppService bbqApp)
        {
            _personApp = personApp;
            _user = user;
            _bbqApp = bbqApp;
        }

        [Function(nameof(RunGetProposedFood))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "{bbqId}/food")] HttpRequestData req, string bbqId)
        {
            //user validation
            var loggedPersonId = _user.Id;
            if (String.IsNullOrEmpty(loggedPersonId))
            {
                return await req.CreateResponse(HttpStatusCode.BadRequest, "Input is required.");
            }

            var loggedPerson = await _personApp.GetAsync(loggedPersonId);

            if (loggedPerson is null)
            {
                return await req.CreateResponse(HttpStatusCode.Unauthorized, "Invalid User.");
            }

            if (!loggedPerson.IsCoOwner)
            {
                return await req.CreateResponse(HttpStatusCode.Unauthorized, "Invalid User.");
            }

            var response = await _bbqApp.GetProposedFoodList(bbqId);

            return await req.CreateResponse(HttpStatusCode.Created, response);
        }
    }
}
