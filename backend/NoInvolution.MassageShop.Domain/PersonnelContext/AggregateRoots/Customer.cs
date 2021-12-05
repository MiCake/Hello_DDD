using NoInvolution.MassageShop.Domain.Common;

namespace NoInvolution.MassageShop.Domain.PersonnelContext
{
    public class Customer : AuditAggregateRoot
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
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }

        public static Customer Create(string name, string phone, GenderType gender)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw DomainExceptionDescriber.DataError("姓名");
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                throw DomainExceptionDescriber.PhoneFormatError();
            }

            return new Customer
            {
                Name = name,
                Gender = gender,
                Phone = phone,
            };
        }

        public void SetAvatar(string avatar)
            => Avatar = avatar;

        public void ChangePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw DomainExceptionDescriber.PhoneFormatError();
            }

            Phone = phone;
        }
    }
}
