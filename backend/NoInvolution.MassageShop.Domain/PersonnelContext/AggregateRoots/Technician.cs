using NoInvolution.MassageShop.Domain.Common;

namespace NoInvolution.MassageShop.Domain.PersonnelContext
{
    /// <summary>
    /// 技师
    /// </summary>
    public class Technician : AuditAggregateRoot
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 性别
        /// </summary>
        public GenderType Gender { get; private set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; private set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public TechnicianContactInfo ContactInfo { get; private set; }

        public static Technician Create(string name, GenderType gender)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw DomainExceptionDescriber.InfoNullError("姓名");
            }

            return new Technician
            {
                Name = name,
                Gender = gender,
            };
        }

        public void SetAvatar(string avatar)
            => Avatar = avatar;

        public void SetContactInfo(string phone, string email)
            => ContactInfo = new TechnicianContactInfo(email, phone);
    }
}
