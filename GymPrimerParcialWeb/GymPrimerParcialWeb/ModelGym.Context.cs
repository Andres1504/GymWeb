﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GymPrimerParcialWeb
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class gymEntities : DbContext
    {
        public gymEntities()
            : base("name=gymEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<actividades> actividades { get; set; }
        public virtual DbSet<domicilio> domicilio { get; set; }
        public virtual DbSet<empleado> empleado { get; set; }
        public virtual DbSet<membresia> membresia { get; set; }
        public virtual DbSet<meses> meses { get; set; }
        public virtual DbSet<precios> precios { get; set; }
        public virtual DbSet<tarjeta> tarjeta { get; set; }
        public virtual DbSet<tipo_pago> tipo_pago { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Ubicacion> Ubicacion { get; set; }
    }
}