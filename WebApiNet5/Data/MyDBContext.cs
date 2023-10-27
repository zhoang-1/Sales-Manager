using Microsoft.EntityFrameworkCore;

namespace WebApiNet5.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options) { }

        #region
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang>DonHangs { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }

        #endregion

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDh);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.NguoiNhan).IsRequired().HasMaxLength(150);

            });
            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.ToTable("ChiTietDonHang");
                entity.HasKey(e => new {e.MaHh,e.MaDh });

                entity.HasOne(e => e.DonHang)
                .WithMany(e => e.ChiTietDonHangs)
                .HasForeignKey(e => e.MaDh)
                .HasConstraintName("FK_DonHangCT_DonHang");

                entity.HasOne(e => e.HangHoa)
                .WithMany(e => e.ChiTietDonHangs)
                .HasForeignKey(e => e.MaHh)
                .HasConstraintName("FK_DonHangCT_HangHoa");


            });
        }

    }
}
