using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Медиа_сеть_маркетинговой_компании.Models
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Логин")]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Display(Name ="повторите пароль")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Возраст")]
        public int Age { get; set; }
        [Display(Name = "Имя")]
        public string FName { get; set; }
        [Display(Name = "Фамилия")]
        public string LName { get; set; }

    }
    public class ForgotPassword
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Answer { get; set; }
    }
    public class User
    {
        [Key]
        [ForeignKey("Profile")]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
        public Profile Profile { get; set; }
    }
    public class UserContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Advert> adverts { get; set; }
        public UserContext() : base("DefaultConnection")
        {}
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Ban> Bans { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Role>().Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Ban>().Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Cat>().Property(a => a.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Advert>().Property(a => a.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //modelBuilder.Entity<Profile>().Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
    public class Profile
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Date_r { get; set; }
        public DateTime Date_s { get; set; }
        public double Balance { get; set; }
        public string Answer { get; set; }
        public string Quest { get; set; }

        public User User { get; set; }
    }
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<User> User { get; set; }
    }
    public class Ban
    {
        public int Id { get; set; }
        [Required]
        public string Reason { get; set; }
        [Required]
        public DateTime Date_b { get; set;}
        [Required]
        public DateTime Date_unb { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
