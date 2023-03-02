namespace ComputerServicesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arabicColumnAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TypeModels", "ArabicTypeName", c => c.String());
            AddColumn("dbo.UsedMachineModels", "ArabicBrand", c => c.String());
            AddColumn("dbo.UsedMachineModels", "ArabicRam", c => c.String());
            AddColumn("dbo.UsedMachineModels", "ArabicHarddisk", c => c.String());
            AddColumn("dbo.UsedMachineModels", "ArabicScreenSize", c => c.String());
            AddColumn("dbo.UsedMachineModels", "ArabicModelNo", c => c.String());
            AddColumn("dbo.UsedMachineModels", "ArabicProcessor", c => c.String());
            AddColumn("dbo.UsedMachineModels", "ArabicOtherInformation", c => c.String());
            AddColumn("dbo.UsedMachineModels", "ArabicTypes_DataGroupField", c => c.String());
            AddColumn("dbo.UsedMachineModels", "ArabicTypes_DataTextField", c => c.String());
            AddColumn("dbo.UsedMachineModels", "ArabicTypes_DataValueField", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsedMachineModels", "ArabicTypes_DataValueField");
            DropColumn("dbo.UsedMachineModels", "ArabicTypes_DataTextField");
            DropColumn("dbo.UsedMachineModels", "ArabicTypes_DataGroupField");
            DropColumn("dbo.UsedMachineModels", "ArabicOtherInformation");
            DropColumn("dbo.UsedMachineModels", "ArabicProcessor");
            DropColumn("dbo.UsedMachineModels", "ArabicModelNo");
            DropColumn("dbo.UsedMachineModels", "ArabicScreenSize");
            DropColumn("dbo.UsedMachineModels", "ArabicHarddisk");
            DropColumn("dbo.UsedMachineModels", "ArabicRam");
            DropColumn("dbo.UsedMachineModels", "ArabicBrand");
            DropColumn("dbo.TypeModels", "ArabicTypeName");
        }
    }
}
