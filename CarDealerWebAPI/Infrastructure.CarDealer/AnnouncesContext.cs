using Core.CarDealer.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.CarDealer
{
    public partial class AnnouncesContext : DbContext
    {
        public AnnouncesContext()
        {
        }

        public AnnouncesContext(DbContextOptions<AnnouncesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<CarEquipment> CarEquipments { get; set; } = null!;
        public virtual DbSet<CarType> CarTypes { get; set; } = null!;
        public virtual DbSet<Equipment> Equipment { get; set; } = null!;
        public virtual DbSet<FuelType> FuelTypes { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<MessageTo> MessageTos { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserCar> UserCars { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-IOE64M2\\SQLEXPRESS;Database=Announces;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brand");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("car");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddingDate)
                    .HasColumnType("date")
                    .HasColumnName("adding_date");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.CarNumber)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("car_number");

                entity.Property(e => e.CarTypeId).HasColumnName("car_type_id");

                entity.Property(e => e.CilindricCapacity).HasColumnName("cilindric_capacity");

                entity.Property(e => e.Description)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.FuelType).HasColumnName("fuel_type");

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("model");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductionYear).HasColumnName("production_year");

                entity.Property(e => e.SecondHand).HasColumnName("second_hand");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__car__brand_id__4E88ABD4");

                entity.HasOne(d => d.CarType)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.CarTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__car__car_type_id__4F7CD00D");

                entity.HasOne(d => d.FuelTypeNavigation)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.FuelType)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__car__fuel_type__36B12243");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__car__user_id__35BCFE0A");
            });

            modelBuilder.Entity<CarEquipment>(entity =>
            {
                entity.ToTable("car_equipment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.CarEquipments)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__car_equip__car_i__398D8EEE");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.CarEquipments)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__car_equip__equip__3A81B327");
            });

            modelBuilder.Entity<CarType>(entity =>
            {
                entity.ToTable("car_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.ToTable("equipment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<FuelType>(entity =>
            {
                entity.ToTable("fuel_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("image");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.ImageName)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("imageName");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__image__car_id__5EBF139D");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("message");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("content");

                entity.Property(e => e.Subject)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("subject");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__message__user_id__30F848ED");
            });

            modelBuilder.Entity<MessageTo>(entity =>
            {
                entity.ToTable("message_to");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MessageId).HasColumnName("message_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.MessageTos)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__message_t__messa__4222D4EF");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MessageTos)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__message_t__user___412EB0B6");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("second_name");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__user__role_id__02FC7413");
            });

            modelBuilder.Entity<UserCar>(entity =>
            {
                entity.ToTable("user_car");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCars)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__user_car__user_i__09A971A2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
