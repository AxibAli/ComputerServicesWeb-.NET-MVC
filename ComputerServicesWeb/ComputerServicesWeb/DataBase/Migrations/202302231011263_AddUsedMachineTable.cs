namespace ComputerServicesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsedMachineTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsedMachineModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PicturePath = c.String(),
                        Type = c.String(),
                        Brand = c.String(),
                        Ram = c.String(),
                        Harddisk = c.String(),
                        ScreenSize = c.String(),
                        ModelNo = c.String(),
                        Processor = c.String(),
                        OtherInformation = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UsedMachineModels");
        }
    }
}
