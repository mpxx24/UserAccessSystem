using System.Data.Entity.Migrations;

namespace UserAccessSystem.DatabaseAccess.Migrations {
    public partial class addterritoryclass : DbMigration {
        public override void Up() {
            this.CreateTable(
                "dbo.Territories",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(false),
                    ShortName = c.String(),
                    IsRequireSpecialUserAccessRights = c.Boolean(false),
                    IsAvailableForAll = c.Boolean(false)
                })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.UserTerritories",
                c => new
                {
                    User_Id = c.Int(false),
                    Territory_Id = c.Int(false)
                })
                .PrimaryKey(t => new {t.User_Id, t.Territory_Id})
                .ForeignKey("dbo.Users", t => t.User_Id, true)
                .ForeignKey("dbo.Territories", t => t.Territory_Id, true)
                .Index(t => t.User_Id)
                .Index(t => t.Territory_Id);
        }

        public override void Down() {
            this.DropForeignKey("dbo.UserTerritories", "Territory_Id", "dbo.Territories");
            this.DropForeignKey("dbo.UserTerritories", "User_Id", "dbo.Users");
            this.DropIndex("dbo.UserTerritories", new[] {"Territory_Id"});
            this.DropIndex("dbo.UserTerritories", new[] {"User_Id"});
            this.DropTable("dbo.UserTerritories");
            this.DropTable("dbo.Territories");
        }
    }
}