using FluentMigrator;
using System;

namespace GuiSamples.Data.Migrations
{
    [Migration(2019091201, "Add log table - first migration")]
    public class AddLogTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Log")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Text").AsString();
        }
    }
}
