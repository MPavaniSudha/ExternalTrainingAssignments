namespace ExternalWebAPIPrj1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialtb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        SNo = c.Int(nullable: false, identity: true),
                        EmpNO = c.Int(nullable: false),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        EmpType = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        Bonus_Status = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.SNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
