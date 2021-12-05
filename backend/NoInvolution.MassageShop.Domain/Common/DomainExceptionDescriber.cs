using MiCake.DDD.Domain;

namespace NoInvolution.MassageShop.Domain
{
    /// <summary>
    /// 通用领域错误信息描述
    /// </summary>
    public class DomainExceptionDescriber
    {
        public static DomainException PhoneFormatError()
            => new("手机号码格式不正确");

        public static DomainException DataFormatError(string dataName)
            => new($"{dataName}码格式不正确");

        public static DomainException InfoNullError(string infoName)
            => new($"{infoName}不能为空");

        public static DomainException DataError(string dataName)
            => new($"{dataName}数据错误");

        public static DomainException DataLessThanZero(string dataName)
            => new($"{dataName}不能小于0");
    }
}
