namespace ComputerServicesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnSoldPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsedMachineModels", "Price", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsedMachineModels", "Price");
        }
    }
}
