using AppService;
using Contracts;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using System.Net;

namespace Serverless_Api.Functions.Lookups.AddPerson
{
    public partial class RunAddPersonToLookup
    {
        private readonly LoggedPerson _user;
        private readonly ILookupAppService _lookupsApp;

        public RunAddPersonToLookup(LoggedPerson user, ILookupAppService lookupApp)
        {
            _user = user;
            _lookupsApp = lookupApp;
        }

        [Function(nameof(RunAddPersonToLookup))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "put", Route = "lookups/{id}/addperson")] HttpRequestData req, string id)
        {
            var input = await req.Body<AddPersonToALookupRequest>();
            var response = await _lookupsApp.AddPerson(input, id);
            return await req.CreateResponse(HttpStatusCode.OK, response);
        }

    }
}
