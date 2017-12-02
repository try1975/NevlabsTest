using System.Data.Entity.Migrations;

namespace Try1975.Nevlabs.Migrations
{
    public partial class V01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Persons",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Fullname = c.String(maxLength: 250),
                        Birthday = c.DateTime(storeType: "date"),
                        Email = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50)
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Persons");
        }
    }
}