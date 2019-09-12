using FluentMigrator;
using System;

namespace GuiSamples.Data.Migrations
{
    [Migration(1, "Add log table - first migration")]
    public class Migration001_AddLogTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("log")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("message").AsString();
        }
    }
}
