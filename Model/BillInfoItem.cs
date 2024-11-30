using System.Collections.Generic;
using System.Linq;

namespace QuanLiCaphe.Model
{

    public class BillInfoItem
    {
        public int Id { get; set; }
        public int IdBill { get; set; }
        public int IdFood { get; set; }
        public int Count { get; set; }
        public string FoodName { get; set; }
        public float Price { get; set; }
        public float TotalAmount { get; set; } // Tổng tiền của toàn bộ hóa đơn
        public float TotalPrice => Price * Count; // Tính thành tiền tự động

    
    }
}
