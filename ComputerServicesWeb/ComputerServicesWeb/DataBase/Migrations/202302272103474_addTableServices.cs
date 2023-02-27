namespace ComputerServicesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableServices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServicesModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PicturePath = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ServicesModels");
        }
    }
}
