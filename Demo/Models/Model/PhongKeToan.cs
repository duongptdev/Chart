using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models.Model
{
    public class PhongKeToan
    {
        public Nullable<int> Tuan { get; set; }
        public Nullable<decimal> DoanhThuHN { get; set; }
        public Nullable<decimal> DoanhThuCNHCM { get; set; }
        public Nullable<decimal> CongNoHN { get; set; }
        public Nullable<decimal> CongNoCNHCM { get; set; }
        public Nullable<int> CKSKT { get; set; }
        public Nullable<int> HDDTKT { get; set; }
        public Nullable<int> EBHKT { get; set; }
        public Nullable<int> Co_VanKT { get; set; }
        public Nullable<int> MoKhoaKT { get; set; }
        public Nullable<int> DungThuKT { get; set; }
    }
}