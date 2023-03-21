using Microsoft.EntityFrameworkCore;
using Proyecto.Server.Models;

namespace Proyecto.Server.Context;

public interface IMyDbContext
{

   DbSet<UsuarioRol> UsuariosRoles { get; set; }
    DbSet<Usuario> Usuarios { get; set; }  
     DbSet<Cliente> Clientes { set; get; }
     DbSet<Listaventas> Listas { set; get; } 
    DbSet<Productos> Producto { set; get; } 

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public class MyDbContext : DbContext, IMyDbContext
{
    private readonly IConfiguration config;

    public MyDbContext(IConfiguration _config)
    {
        config = _config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(config.GetConnectionString("Proyecto"));
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    #region Tablas de mi base de datos
    public DbSet<UsuarioRol> UsuariosRoles { set; get; } = null!;
    public DbSet<Usuario> Usuarios { set; get; } = null!;
    public DbSet<Cliente> Clientes { set; get; } = null!;
    public DbSet<Listaventas> Listas { set; get; } = null!;
    public DbSet<Productos> Producto { set; get; } = null!;
    
    #endregion
}