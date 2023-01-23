using GeekShop.CartApi.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShop.CartApi.Model
{
    [Table("Cart_Detail")]
    public class CartDetail : BaseEntity
    {
        public int CartHeaderId { get; set; }

        [ForeignKey("CartHeaderId")]
        public virtual CartHeader CartHeader { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Column("Count")]
        public int Count { get; set; }
    }
}
