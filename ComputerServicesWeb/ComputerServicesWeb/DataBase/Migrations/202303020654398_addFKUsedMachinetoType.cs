namespace ComputerServicesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFKUsedMachinetoType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UsedMachineModels", "Type", c => c.Int(nullable: false));
            CreateIndex("dbo.UsedMachineModels", "Type");
            AddForeignKey("dbo.UsedMachineModels", "Type", "dbo.TypeModels", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsedMachineModels", "Type", "dbo.TypeModels");
            DropIndex("dbo.UsedMachineModels", new[] { "Type" });
            AlterColumn("dbo.UsedMachineModels", "Type", c => c.String());
        }
    }
}
