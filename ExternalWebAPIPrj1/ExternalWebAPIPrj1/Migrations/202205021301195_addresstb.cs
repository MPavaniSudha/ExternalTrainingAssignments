namespace ExternalWebAPIPrj1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addresstb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        SNO = c.Int(nullable: false, identity: true),
                        DoorNo = c.String(),
                        StreetName = c.String(),
                        City = c.String(),
                        State = c.String(),
                        EmpNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SNO)
                .ForeignKey("dbo.Employees", t => t.EmpNo, cascadeDelete: true)
                .Index(t => t.EmpNo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "EmpNo", "dbo.Employees");
            DropIndex("dbo.Addresses", new[] { "EmpNo" });
            DropTable("dbo.Addresses");
        }
    }
}
