using System.Data.Entity.Migrations;

namespace UserAccessSystem.DatabaseAccess.Migrations {
    public partial class changeUserIdtype : DbMigration {
        public override void Up() {
            DropPrimaryKey("dbo.Users");
            DropColumn("dbo.Users", "Id");
            AddColumn("dbo.Users", "Id", c => c.Int(false, true));
            AddPrimaryKey("dbo.Users", "Id");
        }

        public override void Down() {
            DropPrimaryKey("dbo.Users");
            DropColumn("dbo.Users", "Id");
            AddColumn("dbo.Users", "Id", c => c.Guid(false));
            AddPrimaryKey("dbo.Users", "Id");
        }
    }
}