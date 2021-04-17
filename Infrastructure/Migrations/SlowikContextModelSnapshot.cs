﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(SlowikContext))]
    partial class SlowikContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.Chunk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("ChunklistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("XmlChunkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChunklistId");

                    b.ToTable("Chunks");
                });

            modelBuilder.Entity("Domain.Models.ChunkList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("ChunkListMetaDataId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CorpusId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ChunkListMetaDataId");

                    b.HasIndex("CorpusId");

                    b.ToTable("Chunklists");
                });

            modelBuilder.Entity("Domain.Models.ChunkListMetaData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("NumberOfChunks")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfSentences")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfTokens")
                        .HasColumnType("int");

                    b.Property<string>("XmlDictionaryLookUp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChunkListMetaData");
                });

            modelBuilder.Entity("Domain.Models.Corpus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("Id");

                    b.ToTable("Corpuses");
                });

            modelBuilder.Entity("Domain.Models.CorpusMetaData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("CorpusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("NumberOfChunkLists")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfProcessedFiles")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CorpusId");

                    b.ToTable("CorpusesMetaDataXml");
                });

            modelBuilder.Entity("Domain.Models.Sentence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("ChunkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Xml")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("XmlSentenceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChunkId");

                    b.ToTable("Sentences");
                });

            modelBuilder.Entity("Domain.Models.Chunk", b =>
                {
                    b.HasOne("Domain.Models.ChunkList", "Chunklist")
                        .WithMany("Chunks")
                        .HasForeignKey("ChunklistId");

                    b.Navigation("Chunklist");
                });

            modelBuilder.Entity("Domain.Models.ChunkList", b =>
                {
                    b.HasOne("Domain.Models.ChunkListMetaData", "ChunkListMetaData")
                        .WithMany()
                        .HasForeignKey("ChunkListMetaDataId");

                    b.HasOne("Domain.Models.Corpus", "Corpus")
                        .WithMany("ChunkLists")
                        .HasForeignKey("CorpusId");

                    b.Navigation("ChunkListMetaData");

                    b.Navigation("Corpus");
                });

            modelBuilder.Entity("Domain.Models.CorpusMetaData", b =>
                {
                    b.HasOne("Domain.Models.Corpus", "Corpus")
                        .WithMany()
                        .HasForeignKey("CorpusId");

                    b.Navigation("Corpus");
                });

            modelBuilder.Entity("Domain.Models.Sentence", b =>
                {
                    b.HasOne("Domain.Models.Chunk", "Chunk")
                        .WithMany("Sentences")
                        .HasForeignKey("ChunkId");

                    b.Navigation("Chunk");
                });

            modelBuilder.Entity("Domain.Models.Chunk", b =>
                {
                    b.Navigation("Sentences");
                });

            modelBuilder.Entity("Domain.Models.ChunkList", b =>
                {
                    b.Navigation("Chunks");
                });

            modelBuilder.Entity("Domain.Models.Corpus", b =>
                {
                    b.Navigation("ChunkLists");
                });
#pragma warning restore 612, 618
        }
    }
}
