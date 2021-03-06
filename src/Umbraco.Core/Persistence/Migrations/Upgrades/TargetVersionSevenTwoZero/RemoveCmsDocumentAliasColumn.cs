using System.Linq;
using Umbraco.Core.Configuration;
using Umbraco.Core.Persistence.SqlSyntax;

namespace Umbraco.Core.Persistence.Migrations.Upgrades.TargetVersionSevenTwoZero
{
    [Migration("7.2.0", 2, GlobalSettings.UmbracoMigrationName)]
    public class RemoveCmsDocumentAliasColumn : MigrationBase
    {
        public override void Up()
        {
            var columns = SqlSyntaxContext.SqlSyntaxProvider.GetColumnsInSchema(Context.Database).Distinct().ToArray();

            if (columns.Any(x => x.ColumnName.InvariantEquals("alias") && x.TableName.InvariantEquals("cmsDocument")))
            {
                Delete.Column("alias").FromTable("cmsDocument");    
            }
        }

        public override void Down()
        {
        }
    }
}