namespace ComputerServicesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeArabicTypeColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UsedMachineModels", "ArabicTypes_DataGroupField");
            DropColumn("dbo.UsedMachineModels", "ArabicTypes_DataTextField");
            DropColumn("dbo.UsedMachineModels", "ArabicTypes_DataValueField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsedMachineModels", "ArabicTypes_DataValueField", c => c.String());
            AddColumn("dbo.UsedMachineModels", "ArabicTypes_DataTextField", c => c.String());
            AddColumn("dbo.UsedMachineModels", "ArabicTypes_DataGroupField", c => c.String());
        }
    }
}
