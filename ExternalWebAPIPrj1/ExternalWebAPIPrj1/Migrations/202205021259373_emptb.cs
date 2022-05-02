namespace ExternalWebAPIPrj1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emptb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpNO = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        EmpType = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        Bonus_Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmpNO);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
