using AmericanAmbassyForm.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmericanAmbassyForm.Data;

public class AmericanAmbassyDBContex : DbContext
{

    public AmericanAmbassyDBContex(DbContextOptions<AmericanAmbassyDBContex> options)
        : base(options)
    {
    }
    public DbSet<Models.FormInformation> FormInformations { get; set; }

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    base.OnModelCreating(builder);
    //    // Customize the ASP.NET Identity model and override the defaults if needed.
    //    // For example, you can rename the ASP.NET Identity table names and more.
    //    // Add your customizations after calling base.OnModelCreating(builder);
    //    builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    //}
}
