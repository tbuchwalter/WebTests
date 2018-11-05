using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyProject.Authorization.Roles;
using MyProject.Authorization.Users;
using MyProject.Domains;
using MyProject.Domains.Community;
using MyProject.Domains.Guideline;
using MyProject.MultiTenancy;

namespace MyProject.EntityFrameworkCore
{
    public class MyProjectDbContext : AbpZeroDbContext<Tenant, Role, User, MyProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Association> Associations { get; set; }
        public DbSet<AssociationGuidelines> AssociationGuidelines { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Builders> Builders { get; set; }
        public DbSet<BuilderPreferences> BuilderPreferences { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<CommunitySection> CommunitySections { get; set; }
        public DbSet<DraftType> DraftTypes { get; set; }
        public DbSet<GuidelineCategories> GuidelineCategories { get; set; }
        public DbSet<Guidelines> Guidelines { get; set; }
        public DbSet<GuidelineType> GuidelineTypes { get; set; }
        public DbSet<GuidelineValues> GuidelineValues { get; set; }
        public DbSet<MunicipalGuidelines> MunicipalGuidelines { get; set; }
        public DbSet<Municipalities> Municipalities { get; set; }
        public DbSet<SubDivision> SubDivisions { get; set; }
        public DbSet<UserSubDivision> UserSubDivisions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Community>().HasOne(x => x.Municipalities)
                .WithMany(x => x.Communities)
                .HasForeignKey(x => x.MunicipalitiesId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Community>().HasOne(x => x.Association)
                .WithMany(x => x.Communities)
                .HasForeignKey(x => x.AssociationId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CommunitySection>().HasOne(x => x.Community)
                .WithMany(x => x.CommunitySections)
                .HasForeignKey(x => x.CommunityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SubDivision>().HasOne(x => x.Builders)
                .WithMany(x => x.SubDivisions)
                .HasForeignKey(x => x.BuildersId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SubDivision>().HasOne(x => x.CommunitySection)
                .WithMany(x => x.SubDivisions)
                .HasForeignKey(x => x.CommunitySectionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserSubDivision>().HasOne(x => x.SubDivision)
                .WithMany(x => x.UserSubDivisions)
                .HasForeignKey(x => x.SubDivisionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Municipalities>().HasOne(x => x.Address)
                .WithMany(x => x.Municipalities)
                .HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Builders>().HasOne(x => x.Address)
                .WithMany(x => x.Builders)
                .HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AssociationGuidelines>().HasOne(x => x.GuidelineValues)
                .WithMany(x => x.AssociationGuidelines)
                .HasForeignKey(x => x.GuidelineValuesId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AssociationGuidelines>().HasOne(x => x.Association)
                .WithMany(x => x.AssociationGuidelines)
                .HasForeignKey(x => x.AssociationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AssociationGuidelines>().HasOne(x => x.CommunitySection)
                .WithMany(x => x.AssociationGuidelines)
                .HasForeignKey(x => x.CommunitySectionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MunicipalGuidelines>().HasOne(x => x.Municipalities)
                .WithMany(x => x.MunicipalGuidelines)
                .HasForeignKey(x => x.MunicipalitiesId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BuilderPreferences>().HasOne(x => x.Builder)
                .WithMany(x => x.BuilderPreferences)
                .HasForeignKey(x => x.BuilderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BuilderPreferences>().HasOne(x => x.GuidelineValue)
                .WithMany(x => x.BuilderPreferences)
                .HasForeignKey(x => x.GuidelineValueId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BuilderPreferences>().HasOne(x => x.Community)
                .WithMany(x => x.BuilderPreferences)
                .HasForeignKey(x => x.CommunityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BuilderPreferences>().HasOne(x => x.CommunitySection)
                .WithMany(x => x.BuilderPreferences)
                .HasForeignKey(x => x.SectionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Guidelines>().HasOne(x => x.Category)
                .WithMany(x => x.Guidelines)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Association>().HasOne(x => x.Address)
                .WithMany(x => x.Associations)
                .HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MunicipalGuidelines>().HasOne(x => x.Municipalities)
                .WithMany(x => x.MunicipalGuidelines)
                .HasForeignKey(x => x.MunicipalitiesId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GuidelineValues>().HasOne(x => x.Guideline)
                .WithMany(x => x.GuidelineValues)
                .HasForeignKey(x => x.GuidelineId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GuidelineType>().HasOne(x => x.DraftType)
                .WithMany(x => x.GuidelineTypes)
                .HasForeignKey(x => x.DraftTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GuidelineType>().HasOne(x => x.Guideline)
                .WithMany(x => x.GuidelineTypes)
                .HasForeignKey(x => x.GuidelineId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MunicipalGuidelines>().HasOne(x => x.GuidelineValues)
                .WithMany(x => x.MunicipalGuidelines)
                .HasForeignKey(x => x.GuidelineValuesId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options)
            : base(options)
        {
        }
    }
}
