using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagement.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__3213E83F36F0B7F9", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3213E83F434E4A77", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    startDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    capacity = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    isPrivate = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    registrationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    isPaid = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    category = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Event__3213E83F4DBAF063", x => x.id);
                    table.ForeignKey(
                        name: "FK__Event__category__3D5E1FD2",
                        column: x => x.category,
                        principalTable: "Category",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: true),
                    eventID = table.Column<int>(type: "int", nullable: true),
                    comment = table.Column<string>(type: "text", nullable: false),
                    commentDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comment__3213E83F725C3A62", x => x.id);
                    table.ForeignKey(
                        name: "FK__Comment__eventID__6C190EBB",
                        column: x => x.eventID,
                        principalTable: "Event",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Comment__userID__6B24EA82",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: true),
                    eventID = table.Column<int>(type: "int", nullable: true),
                    message = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    notificationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    isRead = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__3213E83FE7D1DF7F", x => x.id);
                    table.ForeignKey(
                        name: "FK__Notificat__event__5CD6CB2B",
                        column: x => x.eventID,
                        principalTable: "Event",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Notificat__userI__5BE2A6F2",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: true),
                    eventID = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    paymentDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    paymentStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payment__3213E83FC48308A7", x => x.id);
                    table.ForeignKey(
                        name: "FK__Payment__eventID__628FA481",
                        column: x => x.eventID,
                        principalTable: "Event",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Payment__userID__619B8048",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PrivateEventAccess",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false),
                    eventID = table.Column<int>(type: "int", nullable: false),
                    hasAccess = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PrivateE__49466709D34565BF", x => new { x.userID, x.eventID });
                    table.ForeignKey(
                        name: "FK__PrivateEv__event__571DF1D5",
                        column: x => x.eventID,
                        principalTable: "Event",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__PrivateEv__userI__5629CD9C",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "UserEvent",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false),
                    eventID = table.Column<int>(type: "int", nullable: false),
                    userMarkAttendance = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    organizerMarkAttendance = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    isCreator = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    hasPaid = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserEven__49466709C6182782", x => new { x.userID, x.eventID });
                    table.ForeignKey(
                        name: "FK__UserEvent__event__52593CB8",
                        column: x => x.eventID,
                        principalTable: "Event",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__UserEvent__userI__5165187F",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_eventID",
                table: "Comment",
                column: "eventID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_userID",
                table: "Comment",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_category",
                table: "Event",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_eventID",
                table: "Notification",
                column: "eventID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_userID",
                table: "Notification",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_eventID",
                table: "Payment",
                column: "eventID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_userID",
                table: "Payment",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateEventAccess_eventID",
                table: "PrivateEventAccess",
                column: "eventID");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvent_eventID",
                table: "UserEvent",
                column: "eventID");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__72E12F1BD0617FCA",
                table: "Users",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__AB6E6164752929C0",
                table: "Users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "PrivateEventAccess");

            migrationBuilder.DropTable(
                name: "UserEvent");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
