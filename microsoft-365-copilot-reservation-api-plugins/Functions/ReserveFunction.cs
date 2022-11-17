using System.Net;
using Karamem0.SampleApplication.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;

namespace Karamem0.SampleApplication.Functions;

public class ReserveFunction(ILoggerFactory loggerFactory, ReservationCollection collection)
{

    private readonly ILogger logger = loggerFactory.CreateLogger<ReserveFunction>();

    private readonly ReservationCollection collection = collection;

    [Function("Reserve")]
    [OpenApiOperation(operationId: "postReserve", Summary = "社内施設を予約します。", Description = "社内施設を予約します。")]
    [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(Reservation), Required = true)]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/json", bodyType: typeof(Reservation))]
    public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "POST")] HttpRequestData req)
    {
        try
        {
            this.logger.LogInformation("Funtcion started");
            var res = req.CreateResponse();
            var item = await req.ReadFromJsonAsync<Reservation>();
            if (item == null)
            {
                res.StatusCode = HttpStatusCode.BadRequest;
                return res;
            }
            this.collection.Add(item);
            res.StatusCode = HttpStatusCode.OK;
            await res.WriteAsJsonAsync(item);
            return res;
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Funtcion failed");
            throw;
        }
        finally
        {
            this.logger.LogInformation("Funtcion ended");
        }
    }

}
