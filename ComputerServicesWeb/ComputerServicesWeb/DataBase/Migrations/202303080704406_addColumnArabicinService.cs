namespace ComputerServicesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnArabicinService : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServicesModels", "ArabicName", c => c.String());
            AddColumn("dbo.ServicesModels", "ArabicDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServicesModels", "ArabicDescription");
            DropColumn("dbo.ServicesModels", "ArabicName");
        }
    }
}
