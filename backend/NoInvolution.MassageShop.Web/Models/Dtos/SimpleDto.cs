namespace NoInvolution.MassageShop.Web.Models.Dtos
{
    /// <summary>
    /// 为了让基本类型更容易转换为json。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SimpleDto<T>
    {
        public T Data { get; set; }
    }
}
