using Flurl;
using Flurl.Http;
using Pipedream.Integration.DTOs.Requests;
using Pipedream.Integration.DTOs.Responses;
using Pipedream.Integration.Interfaces;

namespace Pipedream.Integration.Services
{
    public class ChargeService : IChargeService
    {
        private const string BaseUrl = "https://{{subDomain}}.m.pipedream.net";
        private static readonly string PathCreateCharge = BaseUrl.Replace("{{subDomain}}", "eoc56jqea5ysq7e");
        private static readonly string PathCancelCharge = BaseUrl.Replace("{{subDomain}}", "eo45xtt0qoks1ru");

        public async Task<ResponseDto<ResponseCreateCharge>> CreateCharge(RequestCreateCharge requestCreateCharge)
        {
            try
            {
                var charge = await PathCreateCharge
                    .PostJsonAsync(requestCreateCharge)
                    .ReceiveJson<ResponseCreateCharge>();
                return new ResponseDto<ResponseCreateCharge>(charge);
            }
            catch(Exception ex)
            {
                return new ResponseDto<ResponseCreateCharge>(ex.Message);
            }
        }

        public async Task<ResponseDto<ResponseCancelCharge>> CancelCharge(RequestCancelCharge requestCancelCharge)
        {
            try
            {
                var charge = await PathCancelCharge
                    .PostJsonAsync(requestCancelCharge)
                    .ReceiveJson<ResponseCancelCharge>();
                return new ResponseDto<ResponseCancelCharge>(charge);
            }
            catch (Exception ex)
            {
                return new ResponseDto<ResponseCancelCharge>(ex.Message);
            }
        }
    }
}
