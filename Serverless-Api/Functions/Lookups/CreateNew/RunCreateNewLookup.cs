using AppService;
using Contracts;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using System.Net;

namespace Serverless_Api.Functions.Lookups.CreateNew
{
    public partial class RunCreateNewLookup
    {
        private readonly LoggedPerson _user;
        private readonly IPersonAppService _personApp;
        private readonly ILookupAppService _lookupApp;

        public RunCreateNewLookup(LoggedPerson user, IPersonAppService personApp, ILookupAppService lookupApp)
        {
            _personApp = personApp;
            _user = user;
            _lookupApp = lookupApp;

        }

        [Function(nameof(RunCreateNewLookup))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "lookups")] HttpRequestData req)
        {
            var input = await req.Body<NewLookupRequest>();
            var response = await _lookupApp.CreateNew(input, _user.Id);
            return await req.CreateResponse(HttpStatusCode.Created, response);
        }

    }
}
