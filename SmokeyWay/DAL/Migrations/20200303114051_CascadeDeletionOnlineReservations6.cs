﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class CascadeDeletionOnlineReservations6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineTableReservation_User_UserId",
                table: "OnlineTableReservation");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineTableReservation_User_UserId",
                table: "OnlineTableReservation",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineTableReservation_User_UserId",
                table: "OnlineTableReservation");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineTableReservation_User_UserId",
                table: "OnlineTableReservation",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
