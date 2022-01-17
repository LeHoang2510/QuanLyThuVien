namespace QuanLyThuVien.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuMuonTra")]
    public partial class PhieuMuonTra
    {
        [Key]
        [StringLength(5)]
        public string MaPhieu { get; set; }

        [StringLength(5)]
        public string MaDG { get; set; }

        [StringLength(5)]
        public string MaTL { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayMuon { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayTra { get; set; }

        public int? SLMuon { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }

        public virtual DocGia DocGia { get; set; }

        public virtual TaiLieu TaiLieu { get; set; }
    }
}
