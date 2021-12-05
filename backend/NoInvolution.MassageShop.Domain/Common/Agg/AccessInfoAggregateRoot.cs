namespace NoInvolution.MassageShop.Domain.Common
{
    /// <summary>
    /// 包含记录用户访问信息的聚合根
    /// </summary>
    public class AccessInfoAggregateRoot : AuditAggregateRoot
    {
        public AccessDeviceInfo? DeviceInfo { get; private set; }

        public void SetAccess(AccessDeviceInfo deviceInfo)
        {
            DeviceInfo = deviceInfo;
        }
    }

    /// <summary>
    /// 用户访问设备信息
    /// </summary>
    public record AccessDeviceInfo(string UserIP, string UserAgent);
}
