using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo_ChangTea.Models
{
    public class DoanhThuModel
    {
        [Key]
        public string MaHD { get; set; }           // Mã hóa đơn
        public string MaDH { get; set; }           // Mã đơn hàng
        public string MaNV { get; set; }           // Mã nhân viên
        public string MaKH { get; set; }           // Mã khách hàng
        public DateTime ThoiGianLap { get; set; }  // Thời gian lập hóa đơn
        public decimal GiamGia { get; set; }       // Giảm giá
        public decimal TongBill { get; set; }      // Tổng tiền trước giảm giá
        public decimal TongBillSauGiamGia { get; set; } // Tổng tiền sau giảm giá
    }
}