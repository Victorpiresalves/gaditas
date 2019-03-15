﻿// <auto-generated />
using System;
using GaditasDataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gaditas.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20190119151207_incluindo_descricao_pagamento")]
    partial class incluindo_descricao_pagamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gaditas.Entities.Aluno", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(14);

                    b.Property<DateTime?>("DT_ATUALIZACAO");

                    b.Property<DateTime>("DT_CADASTRO");

                    b.Property<DateTime>("DT_NASCIMENTO");

                    b.Property<string>("NOME_COMPLETO")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.HasKey("ID");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("Gaditas.Entities.Modalidade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ATIVO");

                    b.Property<DateTime?>("DT_ATUALIZACAO");

                    b.Property<DateTime>("DT_CADASTRO");

                    b.Property<string>("NOME")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Modalidades");
                });

            modelBuilder.Entity("Gaditas.Entities.ModalidadeAluno", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DT_ATUALIZACAO");

                    b.Property<DateTime>("DT_CADASTRO");

                    b.Property<int>("ID_ALUNO");

                    b.Property<int>("ID_MODALIDADE");

                    b.HasKey("ID");

                    b.HasIndex("ID_ALUNO");

                    b.HasIndex("ID_MODALIDADE");

                    b.ToTable("Modalidades_Alunos");
                });

            modelBuilder.Entity("Gaditas.Entities.Pagamento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DESCRICAO");

                    b.Property<DateTime?>("DT_ATUALIZACAO");

                    b.Property<DateTime>("DT_CADASTRO");

                    b.Property<DateTime?>("DT_PAGAMENTO");

                    b.Property<DateTime>("DT_VENCIMENTO");

                    b.Property<int>("ID_ALUNO");

                    b.Property<int>("ID_PLANO_ALUNO");

                    b.Property<int>("NUM_PARCELA");

                    b.Property<bool>("PAGOU");

                    b.Property<int>("QTD_TOTAL_PARCELA");

                    b.Property<decimal>("VALOR");

                    b.HasKey("ID");

                    b.HasIndex("ID_ALUNO");

                    b.HasIndex("ID_PLANO_ALUNO");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("Gaditas.Entities.Plano", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DT_ATUALIZACAO");

                    b.Property<DateTime>("DT_CADASTRO");

                    b.Property<string>("NOME")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("QTD_MESES");

                    b.Property<decimal>("VALOR");

                    b.HasKey("ID");

                    b.ToTable("Planos");
                });

            modelBuilder.Entity("Gaditas.Entities.PlanoAluno", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DT_ATUALIZACAO");

                    b.Property<DateTime>("DT_CADASTRO");

                    b.Property<DateTime>("DT_INICIO");

                    b.Property<int>("ID_ALUNO");

                    b.Property<int>("ID_PLANO");

                    b.HasKey("ID");

                    b.HasIndex("ID_ALUNO");

                    b.HasIndex("ID_PLANO");

                    b.ToTable("Planos_Alunos");
                });

            modelBuilder.Entity("Gaditas.Entities.ModalidadeAluno", b =>
                {
                    b.HasOne("Gaditas.Entities.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("ID_ALUNO")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Gaditas.Entities.Modalidade", "Modalidade")
                        .WithMany()
                        .HasForeignKey("ID_MODALIDADE")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Gaditas.Entities.Pagamento", b =>
                {
                    b.HasOne("Gaditas.Entities.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("ID_ALUNO")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Gaditas.Entities.PlanoAluno", "Plano_Aluno")
                        .WithMany()
                        .HasForeignKey("ID_PLANO_ALUNO")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Gaditas.Entities.PlanoAluno", b =>
                {
                    b.HasOne("Gaditas.Entities.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("ID_ALUNO")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Gaditas.Entities.Plano", "Plano")
                        .WithMany()
                        .HasForeignKey("ID_PLANO")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
