using Pipedream.Integration.DTOs.Requests;
using Pipedream.Integration.DTOs.Responses;

namespace Pipedream.Integration.Interfaces
{
    public interface IChargeService
    {
        Task<ResponseDto<ResponseCreateCharge>> CreateCharge(RequestCreateCharge requestCreateCharge);
        Task<ResponseDto<ResponseCancelCharge>> CancelCharge(RequestCancelCharge requestCancelCharge);
    }
}
