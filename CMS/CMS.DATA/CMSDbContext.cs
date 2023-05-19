using CMS.DATA.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CMS.DATA;
public class CMSDbContext : IdentityDbContext<ApplicationUser>
{
    public CMSDbContext(DbContextOptions<CMSDbContext> options):base(options) {}
}

