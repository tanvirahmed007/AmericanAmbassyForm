﻿using AmericanAmbassyForm.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmericanAmbassyForm.Data;

public class AmericanAmbassyFormContext : IdentityDbContext<AmericanAmbassyFormUser>
{
    public AmericanAmbassyFormContext(DbContextOptions<AmericanAmbassyFormContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<AmericanAmbassyFormUser>
{
    void IEntityTypeConfiguration<AmericanAmbassyFormUser>.Configure(EntityTypeBuilder<AmericanAmbassyFormUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}