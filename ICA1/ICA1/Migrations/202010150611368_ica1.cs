namespace ICA1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ica1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branch_tbl",
                c => new
                    {
                        BranchNo = c.String(nullable: false, maxLength: 128),
                        Street = c.String(),
                        City = c.String(),
                        PostCode = c.String(),
                    })
                .PrimaryKey(t => t.BranchNo);
            
            CreateTable(
                "dbo.Staff_tbl",
                c => new
                    {
                        StaffNo = c.String(nullable: false, maxLength: 128),
                        Fname = c.String(),
                        Lname = c.String(),
                        Position = c.String(),
                        DateofBirth = c.DateTime(nullable: false, storeType: "date"),
                        Salary = c.Int(nullable: false),
                        RefBranchNo = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.StaffNo)
                .ForeignKey("dbo.Branch_tbl", t => t.RefBranchNo)
                .Index(t => t.RefBranchNo);
            
            CreateTable(
                "dbo.Owner_tbl",
                c => new
                    {
                        OwnerNumber = c.String(nullable: false, maxLength: 128),
                        Fname = c.String(),
                        Lname = c.String(),
                        Address = c.String(),
                        TelNo = c.String(),
                    })
                .PrimaryKey(t => t.OwnerNumber);
            
            CreateTable(
                "dbo.Rent_tbl",
                c => new
                    {
                        PropertyNo = c.String(nullable: false, maxLength: 128),
                        Street = c.String(),
                        City = c.String(),
                        Ptype = c.String(),
                        Rooms = c.Int(nullable: false),
                        RefOwnerNo = c.String(maxLength: 128),
                        RefStaffNo = c.String(maxLength: 128),
                        RefBranchNo = c.String(maxLength: 128),
                        Rents = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyNo)
                .ForeignKey("dbo.Branch_tbl", t => t.RefBranchNo)
                .ForeignKey("dbo.Owner_tbl", t => t.RefOwnerNo)
                .ForeignKey("dbo.Staff_tbl", t => t.RefStaffNo)
                .Index(t => t.RefOwnerNo)
                .Index(t => t.RefStaffNo)
                .Index(t => t.RefBranchNo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rent_tbl", "RefStaffNo", "dbo.Staff_tbl");
            DropForeignKey("dbo.Rent_tbl", "RefOwnerNo", "dbo.Owner_tbl");
            DropForeignKey("dbo.Rent_tbl", "RefBranchNo", "dbo.Branch_tbl");
            DropForeignKey("dbo.Staff_tbl", "RefBranchNo", "dbo.Branch_tbl");
            DropIndex("dbo.Rent_tbl", new[] { "RefBranchNo" });
            DropIndex("dbo.Rent_tbl", new[] { "RefStaffNo" });
            DropIndex("dbo.Rent_tbl", new[] { "RefOwnerNo" });
            DropIndex("dbo.Staff_tbl", new[] { "RefBranchNo" });
            DropTable("dbo.Rent_tbl");
            DropTable("dbo.Owner_tbl");
            DropTable("dbo.Staff_tbl");
            DropTable("dbo.Branch_tbl");
        }
    }
}
