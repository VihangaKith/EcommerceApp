namespace ICA1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IC : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Staff_tbl", "DateofBirth", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Staff_tbl", "DateofBirth", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
