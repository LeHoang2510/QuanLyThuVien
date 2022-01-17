namespace QuanLyThuVien.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiLieu")]
    public partial class TaiLieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiLieu()
        {
            PhieuMuonTra = new HashSet<PhieuMuonTra>();
        }

        [Key]
        [StringLength(5)]
        public string MaSach { get; set; }

        [StringLength(50)]
        public string TenSach { get; set; }

        [StringLength(30)]
        public string TheLoai { get; set; }

        [StringLength(30)]
        public string TacGia { get; set; }

        [StringLength(30)]
        public string NXB { get; set; }

        public int? NamXB { get; set; }

        public int? SLNhap { get; set; }

        public int? DonGia { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuMuonTra> PhieuMuonTra { get; set; }
    }
}
