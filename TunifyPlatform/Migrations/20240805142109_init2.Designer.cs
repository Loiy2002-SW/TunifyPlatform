﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TunifyPlatform.Data;

#nullable disable

namespace TunifyPlatform.Migrations
{
    [DbContext(typeof(TunifyDbContext))]
    [Migration("20240805142109_init2")]
    partial class init2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TunifyPlatform.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Album 1"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Album 2"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Album 3"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Album 4"
                        });
                });

            modelBuilder.Entity("TunifyPlatform.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Artist 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Artist 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Artist 3"
                        });
                });

            modelBuilder.Entity("TunifyPlatform.Models.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Playlists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Playlist 1",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Playlist 2",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Playlist 3",
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            Name = "Playlist 4",
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            Name = "Playlist 5",
                            UserId = 5
                        });
                });

            modelBuilder.Entity("TunifyPlatform.Models.PlaylistSongs", b =>
                {
                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistId", "SongId");

                    b.HasIndex("SongId");

                    b.ToTable("PlaylistSongs");
                });

            modelBuilder.Entity("TunifyPlatform.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlbumId = 1,
                            ArtistId = 1,
                            Duration = new TimeSpan(0, 0, 3, 0, 0),
                            Genre = "Pop",
                            Title = "Song 1"
                        },
                        new
                        {
                            Id = 2,
                            AlbumId = 2,
                            ArtistId = 2,
                            Duration = new TimeSpan(0, 0, 4, 0, 0),
                            Genre = "Rock",
                            Title = "Song 2"
                        },
                        new
                        {
                            Id = 3,
                            AlbumId = 3,
                            ArtistId = 3,
                            Duration = new TimeSpan(0, 0, 5, 0, 0),
                            Genre = "Jazz",
                            Title = "Song 3"
                        },
                        new
                        {
                            Id = 4,
                            AlbumId = 4,
                            ArtistId = 1,
                            Duration = new TimeSpan(0, 0, 6, 0, 0),
                            Genre = "Hip Hop",
                            Title = "Song 4"
                        },
                        new
                        {
                            Id = 5,
                            AlbumId = 1,
                            ArtistId = 2,
                            Duration = new TimeSpan(0, 0, 3, 0, 0),
                            Genre = "Classical",
                            Title = "Song 5"
                        });
                });

            modelBuilder.Entity("TunifyPlatform.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Price = 0m,
                            Type = "Free"
                        },
                        new
                        {
                            Id = 2,
                            Price = 9.99m,
                            Type = "Premium"
                        },
                        new
                        {
                            Id = 3,
                            Price = 14.99m,
                            Type = "Family"
                        });
                });

            modelBuilder.Entity("TunifyPlatform.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "admin@example.com",
                            JoinDate = new DateTime(2024, 8, 5, 17, 21, 9, 125, DateTimeKind.Local).AddTicks(8729),
                            SubscriptionId = 1,
                            Username = "admin"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "user1@example.com",
                            JoinDate = new DateTime(2024, 7, 26, 17, 21, 9, 125, DateTimeKind.Local).AddTicks(8815),
                            SubscriptionId = 1,
                            Username = "user1"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "user2@example.com",
                            JoinDate = new DateTime(2024, 7, 16, 17, 21, 9, 125, DateTimeKind.Local).AddTicks(8823),
                            SubscriptionId = 2,
                            Username = "user2"
                        },
                        new
                        {
                            UserId = 4,
                            Email = "user3@example.com",
                            JoinDate = new DateTime(2024, 7, 6, 17, 21, 9, 125, DateTimeKind.Local).AddTicks(8825),
                            SubscriptionId = 2,
                            Username = "user3"
                        },
                        new
                        {
                            UserId = 5,
                            Email = "user4@example.com",
                            JoinDate = new DateTime(2024, 6, 26, 17, 21, 9, 125, DateTimeKind.Local).AddTicks(8827),
                            SubscriptionId = 1,
                            Username = "user4"
                        });
                });

            modelBuilder.Entity("TunifyPlatform.Models.Playlist", b =>
                {
                    b.HasOne("TunifyPlatform.Models.User", "User")
                        .WithMany("Playlists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TunifyPlatform.Models.PlaylistSongs", b =>
                {
                    b.HasOne("TunifyPlatform.Models.Playlist", "Playlist")
                        .WithMany("PlaylistSongs")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TunifyPlatform.Models.Song", "Song")
                        .WithMany("PlaylistSongs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("TunifyPlatform.Models.Song", b =>
                {
                    b.HasOne("TunifyPlatform.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TunifyPlatform.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("TunifyPlatform.Models.User", b =>
                {
                    b.HasOne("TunifyPlatform.Models.Subscription", "Subscription")
                        .WithMany("Users")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("TunifyPlatform.Models.Album", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("TunifyPlatform.Models.Artist", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("TunifyPlatform.Models.Playlist", b =>
                {
                    b.Navigation("PlaylistSongs");
                });

            modelBuilder.Entity("TunifyPlatform.Models.Song", b =>
                {
                    b.Navigation("PlaylistSongs");
                });

            modelBuilder.Entity("TunifyPlatform.Models.Subscription", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TunifyPlatform.Models.User", b =>
                {
                    b.Navigation("Playlists");
                });
#pragma warning restore 612, 618
        }
    }
}
