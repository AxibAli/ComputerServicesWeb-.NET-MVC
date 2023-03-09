namespace ComputerServicesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDataTypeofColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UsedMachineModels", "usedmachineId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UsedMachineModels", "usedmachineId", c => c.Long(nullable: false));
        }
    }
}
