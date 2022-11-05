using System.ComponentModel.DataAnnotations;

namespace eShopCoffe.Ordering.Domain.Enums
{
    public enum PaymentMethod
    {
        [Display(Name = "Cash")]
        Cash = 1,

        [Display(Name = "Credit Card")]
        CreditCard = 2,

        [Display(Name = "Debit Card")]
        DebitCard = 3,

        [Display(Name = "Pix")]
        Pix = 4
    }
}
