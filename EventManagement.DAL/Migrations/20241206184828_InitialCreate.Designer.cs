﻿// <auto-generated />
using System;
using EventManagement.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventManagement.DAL.Migrations
{
    [DbContext(typeof(EventManagementContext))]
    [Migration("20241206184828_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventManagement.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK__Category__3213E83F36F0B7F9");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("EventManagement.Model.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment1")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<DateTime?>("CommentDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("commentDate")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("eventID");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userID");

                    b.HasKey("Id")
                        .HasName("PK__Comment__3213E83F725C3A62");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment", (string)null);
                });

            modelBuilder.Entity("EventManagement.Model.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("address");

                    b.Property<int?>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("capacity");

                    b.Property<int?>("Category")
                        .HasColumnType("int")
                        .HasColumnName("category");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("isActive");

                    b.Property<bool?>("IsPaid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("isPaid");

                    b.Property<bool?>("IsPrivate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("isPrivate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("price");

                    b.Property<DateTime?>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("registrationDate")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime")
                        .HasColumnName("startDate");

                    b.HasKey("Id")
                        .HasName("PK__Event__3213E83F4DBAF063");

                    b.HasIndex("Category");

                    b.ToTable("Event", (string)null);
                });

            modelBuilder.Entity("EventManagement.Model.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("eventID");

                    b.Property<bool?>("IsRead")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("isRead");

                    b.Property<string>("Message")
                        .HasColumnType("text")
                        .HasColumnName("message");

                    b.Property<DateTime?>("NotificationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("notificationDate")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Type")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("type");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userID");

                    b.HasKey("Id")
                        .HasName("PK__Notifica__3213E83FE7D1DF7F");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Notification", (string)null);
                });

            modelBuilder.Entity("EventManagement.Model.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("amount");

                    b.Property<int?>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("eventID");

                    b.Property<DateTime?>("PaymentDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("paymentDate")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("PaymentStatus")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("paymentStatus");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userID");

                    b.HasKey("Id")
                        .HasName("PK__Payment__3213E83FC48308A7");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("EventManagement.Model.PrivateEventAccess", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userID");

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("eventID");

                    b.Property<bool?>("HasAccess")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("hasAccess");

                    b.HasKey("UserId", "EventId")
                        .HasName("PK__PrivateE__49466709D34565BF");

                    b.HasIndex("EventId");

                    b.ToTable("PrivateEventAccess", (string)null);
                });

            modelBuilder.Entity("EventManagement.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.HasKey("Id")
                        .HasName("PK__Users__3213E83F434E4A77");

                    b.HasIndex(new[] { "Name" }, "UQ__Users__72E12F1BD0617FCA")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__Users__AB6E6164752929C0")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EventManagement.Model.UserEvent", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userID");

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("eventID");

                    b.Property<bool?>("HasPaid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("hasPaid");

                    b.Property<bool?>("IsCreator")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("isCreator");

                    b.Property<bool?>("OrganizerMarkAttendance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("organizerMarkAttendance");

                    b.Property<bool?>("UserMarkAttendance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("userMarkAttendance");

                    b.HasKey("UserId", "EventId")
                        .HasName("PK__UserEven__49466709C6182782");

                    b.HasIndex("EventId");

                    b.ToTable("UserEvent", (string)null);
                });

            modelBuilder.Entity("EventManagement.Model.Comment", b =>
                {
                    b.HasOne("EventManagement.Model.Event", "Event")
                        .WithMany("Comments")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK__Comment__eventID__6C190EBB");

                    b.HasOne("EventManagement.Model.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Comment__userID__6B24EA82");

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventManagement.Model.Event", b =>
                {
                    b.HasOne("EventManagement.Model.Category", "CategoryNavigation")
                        .WithMany("Events")
                        .HasForeignKey("Category")
                        .HasConstraintName("FK__Event__category__3D5E1FD2");

                    b.Navigation("CategoryNavigation");
                });

            modelBuilder.Entity("EventManagement.Model.Notification", b =>
                {
                    b.HasOne("EventManagement.Model.Event", "Event")
                        .WithMany("Notifications")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK__Notificat__event__5CD6CB2B");

                    b.HasOne("EventManagement.Model.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Notificat__userI__5BE2A6F2");

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventManagement.Model.Payment", b =>
                {
                    b.HasOne("EventManagement.Model.Event", "Event")
                        .WithMany("Payments")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK__Payment__eventID__628FA481");

                    b.HasOne("EventManagement.Model.User", "User")
                        .WithMany("Payments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Payment__userID__619B8048");

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventManagement.Model.PrivateEventAccess", b =>
                {
                    b.HasOne("EventManagement.Model.Event", "Event")
                        .WithMany("PrivateEventAccesses")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__PrivateEv__event__571DF1D5");

                    b.HasOne("EventManagement.Model.User", "User")
                        .WithMany("PrivateEventAccesses")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__PrivateEv__userI__5629CD9C");

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventManagement.Model.UserEvent", b =>
                {
                    b.HasOne("EventManagement.Model.Event", "Event")
                        .WithMany("UserEvents")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__UserEvent__event__52593CB8");

                    b.HasOne("EventManagement.Model.User", "User")
                        .WithMany("UserEvents")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__UserEvent__userI__5165187F");

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventManagement.Model.Category", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("EventManagement.Model.Event", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Notifications");

                    b.Navigation("Payments");

                    b.Navigation("PrivateEventAccesses");

                    b.Navigation("UserEvents");
                });

            modelBuilder.Entity("EventManagement.Model.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Notifications");

                    b.Navigation("Payments");

                    b.Navigation("PrivateEventAccesses");

                    b.Navigation("UserEvents");
                });
#pragma warning restore 612, 618
        }
    }
}