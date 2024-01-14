using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewEntitiy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryUserEntity_AspNetUsers_UserId",
                table: "CategoryUserEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryUserEntity_Category_CategoryId",
                table: "CategoryUserEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryUserEntity",
                table: "CategoryUserEntity");

            migrationBuilder.RenameTable(
                name: "CategoryUserEntity",
                newName: "CategoryUser");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryUserEntity_UserId",
                table: "CategoryUser",
                newName: "IX_CategoryUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryUserEntity_CategoryId",
                table: "CategoryUser",
                newName: "IX_CategoryUser_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryUser",
                table: "CategoryUser",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Introduction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IntroductionPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroductionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntroductionImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntroductionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Introduction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Introduction_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Introduction_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Introduction_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Placement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlacementFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlacementNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlacementDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlacementImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Placement_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Placement_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Placement_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Recruitment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecruitmentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecruitmentPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecruitmentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecruitmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecruitmentTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecruitmentImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruitment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recruitment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recruitment_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recruitment_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillIntroduction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IntroductionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillIntroduction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillIntroduction_Introduction_IntroductionId",
                        column: x => x.IntroductionId,
                        principalTable: "Introduction",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SkillIntroduction_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Introduction_CityId",
                table: "Introduction",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Introduction_ProvinceId",
                table: "Introduction",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Introduction_UserId",
                table: "Introduction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Placement_CityId",
                table: "Placement",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Placement_ProvinceId",
                table: "Placement",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Placement_UserId",
                table: "Placement",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitment_CityId",
                table: "Recruitment",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitment_ProvinceId",
                table: "Recruitment",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitment_UserId",
                table: "Recruitment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillIntroduction_IntroductionId",
                table: "SkillIntroduction",
                column: "IntroductionId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillIntroduction_SkillId",
                table: "SkillIntroduction",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryUser_AspNetUsers_UserId",
                table: "CategoryUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryUser_Category_CategoryId",
                table: "CategoryUser",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryUser_AspNetUsers_UserId",
                table: "CategoryUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryUser_Category_CategoryId",
                table: "CategoryUser");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Placement");

            migrationBuilder.DropTable(
                name: "Recruitment");

            migrationBuilder.DropTable(
                name: "SkillIntroduction");

            migrationBuilder.DropTable(
                name: "Introduction");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryUser",
                table: "CategoryUser");

            migrationBuilder.RenameTable(
                name: "CategoryUser",
                newName: "CategoryUserEntity");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryUser_UserId",
                table: "CategoryUserEntity",
                newName: "IX_CategoryUserEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryUser_CategoryId",
                table: "CategoryUserEntity",
                newName: "IX_CategoryUserEntity_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryUserEntity",
                table: "CategoryUserEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryUserEntity_AspNetUsers_UserId",
                table: "CategoryUserEntity",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryUserEntity_Category_CategoryId",
                table: "CategoryUserEntity",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
