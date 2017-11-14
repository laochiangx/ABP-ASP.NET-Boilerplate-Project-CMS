using Abp.AutoMapper;
using ABPCMS.Sessions.Dto;

namespace ABPCMS.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}