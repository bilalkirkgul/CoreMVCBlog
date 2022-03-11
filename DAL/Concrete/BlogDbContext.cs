using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    class BlogDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Database yolunu belirttik.
            optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS01; database=CoreBlogDB2022; uid=bilal; pwd=123");
            base.OnConfiguring(optionsBuilder);
        }

       
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRayting> BlogRaytings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageTwo> MessageTwos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {      
            modelBuilder.Entity<MessageTwo>()
                .HasOne(a => a.SenderUser)
                .WithMany(b => b.WriterSender)
                .HasForeignKey(c => c.SenderID).OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<MessageTwo>()
                .HasOne(a => a.ReceiverUser)
                .WithMany(b => b.WriterReceiver)
                .HasForeignKey(c => c.ReceiverID).OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
     
        }

    }
}
