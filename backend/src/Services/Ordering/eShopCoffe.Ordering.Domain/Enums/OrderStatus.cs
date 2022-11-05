using System.ComponentModel.DataAnnotations;

namespace eShopCoffe.Ordering.Domain.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Pending")]
        Pending = 1,

        [Display(Name = "Confirmed")]
        Confirmed = 2,

        [Display(Name = "In Production")]
        InProduction = 3,

        [Display(Name = "In DeliveryRoute")]
        InDeliveryRoute = 4,

        [Display(Name = "Delivered")]
        Delivered = 5,

        [Display(Name = "Canceled")]
        Canceled = 6
    }
}
