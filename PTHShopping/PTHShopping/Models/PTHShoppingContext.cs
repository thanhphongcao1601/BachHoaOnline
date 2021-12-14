using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PTHShopping.Models
{
    public partial class PTHShoppingContext : DbContext
    {
        public PTHShoppingContext()
        {
        }

        public PTHShoppingContext(DbContextOptions<PTHShoppingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<AttributesPrice> AttributesPrices { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CtdonHang> CtdonHangs { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<Trang> Trangs { get; set; }
        public virtual DbSet<TrangThaiGiaoDich> TrangThaiGiaoDiches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-7P911SC5;Database=PTHShopping;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId)
                    .HasMaxLength(10)
                    .HasColumnName("AccountID")
                    .IsFixedLength(true);

                entity.Property(e => e.Email).HasColumnType("ntext");

                entity.Property(e => e.HoTen).HasColumnType("ntext");

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.Password).HasColumnType("ntext");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(10)
                    .HasColumnName("RoleID")
                    .IsFixedLength(true);

                entity.Property(e => e.Salt).HasColumnType("ntext");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(12)
                    .HasColumnName("SDT")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("fk_ten");
            });

            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.HasKey(e => e.AttributesId)
                    .HasName("PK__Attribut__70C5DCFD576E1B9A");

                entity.Property(e => e.AttributesId)
                    .HasMaxLength(10)
                    .HasColumnName("AttributesID")
                    .IsFixedLength(true);

                entity.Property(e => e.Name).HasColumnType("ntext");
            });

            modelBuilder.Entity<AttributesPrice>(entity =>
            {
                entity.HasKey(e => e.AttributesPricesId)
                    .HasName("PK__Attribut__5AD7413120BEF104");

                entity.Property(e => e.AttributesPricesId)
                    .HasMaxLength(10)
                    .HasColumnName("AttributesPricesID")
                    .IsFixedLength(true);

                entity.Property(e => e.AttributesId)
                    .HasMaxLength(10)
                    .HasColumnName("AttributesID")
                    .IsFixedLength(true);

                entity.Property(e => e.IdsanPham)
                    .HasMaxLength(10)
                    .HasColumnName("IDSanPham")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Attributes)
                    .WithMany(p => p.AttributesPrices)
                    .HasForeignKey(d => d.AttributesId)
                    .HasConstraintName("fk_AttributesID");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__Categori__6A1C8ADA1CBCC5E8");

                entity.Property(e => e.CatId)
                    .HasMaxLength(10)
                    .HasColumnName("CatID")
                    .IsFixedLength(true);

                entity.Property(e => e.CatName).HasColumnType("ntext");

                entity.Property(e => e.Cover).HasColumnType("ntext");

                entity.Property(e => e.KyHieu).HasColumnType("ntext");

                entity.Property(e => e.MetaDesc).HasColumnType("ntext");

                entity.Property(e => e.MetaKey).HasColumnType("ntext");

                entity.Property(e => e.MoTa).HasColumnType("ntext");

                entity.Property(e => e.ParrentId)
                    .HasMaxLength(10)
                    .HasColumnName("ParrentID")
                    .IsFixedLength(true);

                entity.Property(e => e.SchemaMarkup).HasColumnType("ntext");

                entity.Property(e => e.Thumb).HasColumnType("ntext");

                entity.Property(e => e.TieuDe).HasColumnType("ntext");
            });

            modelBuilder.Entity<CtdonHang>(entity =>
            {
                entity.HasKey(e => e.IdctdonHang)
                    .HasName("PK__CTDonHan__CD96769E4E9FE034");

                entity.ToTable("CTDonHang");

                entity.Property(e => e.IdctdonHang)
                    .HasMaxLength(10)
                    .HasColumnName("IDCTDonHang")
                    .IsFixedLength(true);

                entity.Property(e => e.IddonHang)
                    .HasMaxLength(10)
                    .HasColumnName("IDDonHang")
                    .IsFixedLength(true);

                entity.Property(e => e.IdsanPham)
                    .HasMaxLength(10)
                    .HasColumnName("IDSanPham")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayGiaoHang).HasColumnType("datetime");

                entity.HasOne(d => d.IddonHangNavigation)
                    .WithMany(p => p.CtdonHangs)
                    .HasForeignKey(d => d.IddonHang)
                    .HasConstraintName("fk_IDDonhang");

                entity.HasOne(d => d.IdsanPhamNavigation)
                    .WithMany(p => p.CtdonHangs)
                    .HasForeignKey(d => d.IdsanPham)
                    .HasConstraintName("fk_IDSanPham");
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DanhMuc");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TenDanhMuc).HasMaxLength(100);
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.IddonHang)
                    .HasName("PK__DonHang__9CA232F73E2A8D9A");

                entity.ToTable("DonHang");

                entity.Property(e => e.IddonHang)
                    .HasMaxLength(10)
                    .HasColumnName("IDDonHang")
                    .IsFixedLength(true);

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.IdkhachHang)
                    .HasMaxLength(10)
                    .HasColumnName("IDKhachHang")
                    .IsFixedLength(true);

                entity.Property(e => e.IdthanhToan)
                    .HasMaxLength(10)
                    .HasColumnName("IDThanhToan")
                    .IsFixedLength(true);

                entity.Property(e => e.IdtrangThaiGiaoDich)
                    .HasMaxLength(10)
                    .HasColumnName("IDTrangThaiGiaoDich")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayDatHang).HasColumnType("datetime");

                entity.Property(e => e.NgayGiaoHang).HasColumnType("datetime");

                entity.Property(e => e.NgayThanhToan).HasColumnType("datetime");

                entity.HasOne(d => d.IdkhachHangNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.IdkhachHang)
                    .HasConstraintName("fk_IDKhachHang");

                entity.HasOne(d => d.IdtrangThaiGiaoDichNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.IdtrangThaiGiaoDich)
                    .HasConstraintName("fk_IDTrangThaiGiaoDich");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.IdkhachHang)
                    .HasName("PK__KhachHan__5A7167B5B1D05387");

                entity.ToTable("KhachHang");

                entity.Property(e => e.IdkhachHang)
                    .HasMaxLength(10)
                    .HasColumnName("IDKhachHang")
                    .IsFixedLength(true);

                entity.Property(e => e.Avatar).HasColumnType("ntext");

                entity.Property(e => e.DiaChi).HasColumnType("ntext");

                entity.Property(e => e.Email).HasColumnType("ntext");

                entity.Property(e => e.HoTen).HasColumnType("ntext");

                entity.Property(e => e.Idvitri)
                    .HasMaxLength(10)
                    .HasColumnName("IDVitri")
                    .IsFixedLength(true);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.Phuong).HasMaxLength(50);

                entity.Property(e => e.Quan).HasMaxLength(50);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("SDT")
                    .IsFixedLength(true);

                entity.Property(e => e.SinhNhat).HasColumnType("datetime");

                entity.HasOne(d => d.IdvitriNavigation)
                    .WithMany(p => p.KhachHangs)
                    .HasForeignKey(d => d.Idvitri)
                    .HasConstraintName("fk_location");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.IdviTri)
                    .HasName("PK__Location__5252EE8C6C368933");

                entity.Property(e => e.IdviTri)
                    .HasMaxLength(10)
                    .HasColumnName("IDViTri")
                    .IsFixedLength(true);

                entity.Property(e => e.Loai).HasColumnType("ntext");

                entity.Property(e => e.NameWithType).HasColumnType("ntext");

                entity.Property(e => e.PathWithType).HasColumnType("ntext");

                entity.Property(e => e.Slug).HasColumnType("ntext");

                entity.Property(e => e.Ten).HasColumnType("ntext");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .HasMaxLength(10)
                    .HasColumnName("RoleID")
                    .IsFixedLength(true);

                entity.Property(e => e.MoTa).HasColumnType("ntext");

                entity.Property(e => e.RoleName).HasColumnType("ntext");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.IdsanPham)
                    .HasName("PK__SanPham__9D45E58AC1BD1972");

                entity.ToTable("SanPham");

                entity.Property(e => e.IdsanPham)
                    .HasMaxLength(10)
                    .HasColumnName("IDSanPham")
                    .IsFixedLength(true);

                entity.Property(e => e.CatId)
                    .HasMaxLength(10)
                    .HasColumnName("CatID")
                    .IsFixedLength(true);

                entity.Property(e => e.MetaDesc).HasColumnType("ntext");

                entity.Property(e => e.MetaKey).HasColumnType("ntext");

                entity.Property(e => e.MoTa).HasColumnType("ntext");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.ShortDesc).HasColumnType("ntext");

                entity.Property(e => e.Slban).HasColumnName("SLBan");

                entity.Property(e => e.Tags).HasColumnType("ntext");

                entity.Property(e => e.TenSanPham).HasColumnType("ntext");

                entity.Property(e => e.Thumb).HasColumnType("ntext");

                entity.Property(e => e.TieuDe).HasColumnType("ntext");

                entity.Property(e => e.Video).HasColumnType("ntext");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("fk_loai");
            });

            modelBuilder.Entity<Trang>(entity =>
            {
                entity.HasKey(e => e.Idtrang)
                    .HasName("PK__Trang__827D068022B1B376");

                entity.ToTable("Trang");

                entity.Property(e => e.Idtrang)
                    .HasMaxLength(10)
                    .HasColumnName("IDTrang")
                    .IsFixedLength(true);

                entity.Property(e => e.KiHieu).HasColumnType("ntext");

                entity.Property(e => e.MetaDesc).HasColumnType("ntext");

                entity.Property(e => e.MetaKey).HasColumnType("ntext");

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.NoiDung).HasColumnType("ntext");

                entity.Property(e => e.TenTrang).HasColumnType("ntext");

                entity.Property(e => e.Thumb).HasColumnType("ntext");

                entity.Property(e => e.TieuDe).HasColumnType("ntext");
            });

            modelBuilder.Entity<TrangThaiGiaoDich>(entity =>
            {
                entity.HasKey(e => e.IdtrangThaiGiaoDich)
                    .HasName("PK__TrangTha__052FC7422A0D3851");

                entity.ToTable("TrangThaiGiaoDich");

                entity.Property(e => e.IdtrangThaiGiaoDich)
                    .HasMaxLength(10)
                    .HasColumnName("IDTrangThaiGiaoDich")
                    .IsFixedLength(true);

                entity.Property(e => e.MoTa).HasColumnType("ntext");

                entity.Property(e => e.TrangThai).HasColumnType("ntext");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
