using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Contracts;
using AppService;

namespace Serverless_Api
{
    public partial class RunCreateNewPerson
    {
        private readonly IPersonAppService _personApp;

        public RunCreateNewPerson(IPersonAppService personApp)
        {
            _personApp = personApp;
        }

        [Function(nameof(RunCreateNewPerson))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "person")] HttpRequestData req)
        {
            //req validation
            var input = await req.Body<NewPersonRequest>();

            if (input is null)
            {
                return await req.CreateResponse(HttpStatusCode.BadRequest, "Input is required.");
            }

            var response = await _personApp.CreateNew(input);

            return await req.CreateResponse(HttpStatusCode.Created, response);
        }
    }
}
