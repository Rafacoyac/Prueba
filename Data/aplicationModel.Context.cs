﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class aplicationEntities1 : DbContext
    {
        public aplicationEntities1()
            : base("name=aplicationEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<dia> dias { get; set; }
        public virtual DbSet<Especialidad> Especialidads { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<Horario> Horarios { get; set; }
        public virtual DbSet<Maestro_Materia> Maestro_Materia { get; set; }
        public virtual DbSet<Maestro> Maestros { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }
        public virtual DbSet<OpcionCurso> OpcionCursoes { get; set; }
        public virtual DbSet<Salone> Salones { get; set; }
        public virtual DbSet<Semestre> Semestres { get; set; }
        public virtual DbSet<tokene> tokenes { get; set; }
    }
}
