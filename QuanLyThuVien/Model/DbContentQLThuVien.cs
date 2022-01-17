using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyThuVien.Model
{
    public partial class DbContentQLThuVien : DbContext
    {
        public DbContentQLThuVien()
            : base("name=DbContentQLThuVien")
        {
        }

        public virtual DbSet<DangNhap> DangNhap { get; set; }
        public virtual DbSet<DocGia> DocGia { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<PhieuMuonTra> PhieuMuonTra { get; set; }
        public virtual DbSet<TaiLieu> TaiLieu { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaiLieu>()
                .HasMany(e => e.PhieuMuonTra)
                .WithOptional(e => e.TaiLieu)
                .HasForeignKey(e => e.MaTL);
        }
    }
}
