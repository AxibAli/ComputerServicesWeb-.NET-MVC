namespace ComputerServicesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnStatusinBothTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServicesModels", "Status", c => c.String());
            AddColumn("dbo.UsedMachineModels", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsedMachineModels", "Status");
            DropColumn("dbo.ServicesModels", "Status");
        }
    }
}
