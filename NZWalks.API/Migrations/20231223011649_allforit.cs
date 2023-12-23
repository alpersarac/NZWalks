using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class allforit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Difficulties_difficultyId",
                table: "Walks");

            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Regions_regionId",
                table: "Walks");

            migrationBuilder.RenameColumn(
                name: "walkImageUrl",
                table: "Walks",
                newName: "WalkImageUrl");

            migrationBuilder.RenameColumn(
                name: "regionId",
                table: "Walks",
                newName: "RegionId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Walks",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "lengthInKm",
                table: "Walks",
                newName: "LengthInKm");

            migrationBuilder.RenameColumn(
                name: "difficultyId",
                table: "Walks",
                newName: "DifficultyId");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Walks",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_Walks_regionId",
                table: "Walks",
                newName: "IX_Walks_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Walks_difficultyId",
                table: "Walks",
                newName: "IX_Walks_DifficultyId");

            migrationBuilder.RenameColumn(
                name: "regionImageUrl",
                table: "Regions",
                newName: "RegionImageUrl");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Regions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Regions",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Difficulties",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), "Easy" },
                    { new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), "Medium" },
                    { new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("14ceba71-4b51-4777-9b17-46602cf66153"), "BOP", "Bay Of Plenty", null },
                    { new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"), "NTL", "Northland", null },
                    { new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "NSN", "Nelson", "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "WGN", "Wellington", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"), "STL", "Southland", null },
                    { new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "AKL", "Auckland", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Difficulties_DifficultyId",
                table: "Walks",
                column: "DifficultyId",
                principalTable: "Difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Regions_RegionId",
                table: "Walks",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Difficulties_DifficultyId",
                table: "Walks");

            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Regions_RegionId",
                table: "Walks");

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("14ceba71-4b51-4777-9b17-46602cf66153"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"));

            migrationBuilder.RenameColumn(
                name: "WalkImageUrl",
                table: "Walks",
                newName: "walkImageUrl");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                table: "Walks",
                newName: "regionId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Walks",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "LengthInKm",
                table: "Walks",
                newName: "lengthInKm");

            migrationBuilder.RenameColumn(
                name: "DifficultyId",
                table: "Walks",
                newName: "difficultyId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Walks",
                newName: "description");

            migrationBuilder.RenameIndex(
                name: "IX_Walks_RegionId",
                table: "Walks",
                newName: "IX_Walks_regionId");

            migrationBuilder.RenameIndex(
                name: "IX_Walks_DifficultyId",
                table: "Walks",
                newName: "IX_Walks_difficultyId");

            migrationBuilder.RenameColumn(
                name: "RegionImageUrl",
                table: "Regions",
                newName: "regionImageUrl");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Regions",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Regions",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Difficulties",
                newName: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Difficulties_difficultyId",
                table: "Walks",
                column: "difficultyId",
                principalTable: "Difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Regions_regionId",
                table: "Walks",
                column: "regionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
