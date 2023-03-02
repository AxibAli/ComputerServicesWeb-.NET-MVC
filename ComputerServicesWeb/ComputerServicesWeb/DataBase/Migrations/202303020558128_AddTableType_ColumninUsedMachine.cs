namespace ComputerServicesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableType_ColumninUsedMachine : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.UsedMachineModels", "usedmachineId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsedMachineModels", "usedmachineId");
            DropTable("dbo.TypeModels");
        }
    }
}
