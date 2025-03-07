﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GroupFind.Data.Models;

namespace GroupFind.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<GroupFind.Data.Models.Category> Category { get; set; } = default!;

public DbSet<GroupFind.Data.Models.Event> Event { get; set; } = default!;

public DbSet<GroupFind.Data.Models.User> User { get; set; } = default!;
}
