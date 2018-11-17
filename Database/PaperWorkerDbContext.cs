using System.Data.Entity;
using Database.Models.Account;

namespace Database
{
    public class PaperWorkerDbContext : DbContext
    {
        public PaperWorkerDbContext() : base(nameof(PaperWorkerDbContext))
        {
        }

        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Fluent API
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
//            #region User
//
//            modelBuilder.Entity<User>()
//                .HasMany(user => user.Orders)
//                .WithRequired(order => order.Consumer)
//                .WillCascadeOnDelete(false);
//
//            modelBuilder.Entity<User>()
//                .HasMany(user => user.Offers)
//                .WithRequired(offer => offer.Producer)
//                .WillCascadeOnDelete(false);
//
//            #endregion
//
//            #region Offer
//
//            modelBuilder.Entity<Offer>()
//                .HasMany(offer => offer.Orders)
//                .WithRequired(order => order.Offer)
//                .WillCascadeOnDelete(false);
//
//            #endregion
//
//            #region OfferType
//
//            modelBuilder.Entity<OfferType>()
//                .HasMany(offerType => offerType.Offers)
//                .WithRequired(offer => offer.OfferType)
//                .WillCascadeOnDelete(false);
//
//            #endregion
//
//            #region Order
//
//            modelBuilder.Entity<Order>()
//                .HasOptional(order => order.OrderResult)
//                .WithRequired(orderResult => orderResult.Order)
//                .WillCascadeOnDelete(false);
//
//            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}