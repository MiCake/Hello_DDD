using MiCake.DDD.Domain;

namespace NoInvolution.MassageShop.Domain.PersonnelContext
{
    /// <summary>
    /// 技师的联系方式
    /// </summary>
    /// <param name="Email"></param>
    /// <param name="Phone"></param>
    public record TechnicianContactInfo
        (
            string Email,
            string Phone
        ) : IValueObject;

}
