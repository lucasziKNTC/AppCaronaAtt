using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PROJETO01.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace PROJETO01.Dados.EntityFramework
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = @"Data source = 201.62.57.93; 
                                     Database = dbLAB2_2020; 
                                     User ID = visualstudio; 
                                     Password = visualstudio";
            optionsBuilder.UseSqlServer(conn);
        }

        //Nome das Classes que representarão o Banco de Dados
        public DbSet<Estado> Estado { get; set; }

        public DbSet<Cidade> Cidade { get; set; }

        public DbSet<CadastroDePessoa> CadastroDePessoa { get; set; }

        public DbSet<SolicitarCarona> SolicitarCarona { get; set; }

        //Definição das características das classes com as tabelas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>()
                .ToTable("Estado")
                .HasKey("UF");

            modelBuilder.Entity<Estado>()
                .Property("UF")
                .HasColumnName("Sigla_Est")
                .HasColumnType("char(2)")
                .IsRequired();

            modelBuilder.Entity<Estado>()
                .Property("Nome")
                .HasColumnName("Nome_Est")
                .HasColumnType("varchar(100)")
                .IsRequired();

            modelBuilder.Entity<Cidade>()
             .ToTable("Cidade")
             .HasKey("CidadeId");


            modelBuilder.Entity<Cidade>()
                .Property("CidadeId")
                .HasColumnName("CidadeId")
                .HasColumnType("int")
                .IsRequired();

            modelBuilder.Entity<Cidade>()
               .Property("Nome")
               .HasColumnName("Cidade")
               .HasColumnType("varchar(100)")
               .IsRequired();

            modelBuilder.Entity<Cidade>()
              .Property("UF")
              .HasColumnName("UF")
              .HasColumnType("char(2)")
              .IsRequired();












            base.OnModelCreating(modelBuilder);
        }
    }


}
