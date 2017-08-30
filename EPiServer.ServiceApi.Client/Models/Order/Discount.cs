using System;

namespace EPiServer.Integration.Client.Models.Order
{
    /// <summary>
    /// Discount, contains information about specific discount.
    /// </summary>
    [Serializable]
    public class Discount
    {
        /// <summary>Gets or sets the discount id.</summary>
        /// <value>The discount id.</value>
        public int DiscountId { get; set; }

        /// <summary>
        /// Gets or sets the discount amount. Either fixed money value or percentage.
        /// </summary>
        /// <value>The discount amount.</value>
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// Gets or sets the discount code. Also known as a coupon code.
        /// </summary>
        /// <value>The discount code.</value>
        public string DiscountCode { get; set; }

        /// <summary>Gets or sets the name of the discount.</summary>
        /// <value>The name of the discount.</value>
        public string DiscountName { get; set; }

        /// <summary>Gets or sets the display message.</summary>
        /// <value>The display message.</value>
        public string DisplayMessage { get; set; }

        /// <summary>
        /// Gets or sets the discount amount. The amount of discount that was applied. It will equal to DiscountAmount
        /// if it is a fixed monetary value. For the percentage based discount this value will be different.
        /// </summary>
        /// <value>The discount value.</value>
        public decimal DiscountValue { get; set; }
    }
}