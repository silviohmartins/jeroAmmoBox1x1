using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Utils;
using SPTarkov.Server.Core.Servers;

namespace jeroAmmoBox1x1;

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 10)]
public class AmmoBox1x1(ISptLogger<AmmoBox1x1> logger, DatabaseServer databaseServer) : IOnLoad
{
    // Ammo Box Parent ID
    private const string Parent = "543be5cb4bdc2deb348b4568";
    private Dictionary<MongoId, TemplateItem>? _itemsDb;

    public Task OnLoad()
    {
        var ammoBox = 0;
        _itemsDb = databaseServer.GetTables().Templates.Items;

        foreach (var item in _itemsDb.Where(item => item.Value.Parent.Equals(Parent)))
        {
            if (item.Value.Properties is null) continue;

            // Change size to 1x1
            if (item.Value.Properties.Width == 2 && item.Value.Properties.Height == 1)
            {
                item.Value.Properties.Width = 1;
                ammoBox++;
            }

            // Change background color based on rarity
            if (item.Value.Properties.RarityPvE == "Superrare")
            {
                item.Value.Properties.BackgroundColor = "violet";
            }
            else if (item.Value.Properties.RarityPvE == "rare")
            {
                item.Value.Properties.BackgroundColor = "blue";
            }
            else
            {
                item.Value.Properties.BackgroundColor = "yellow";
            }
        }

        logger.Info($"[JERO] {ammoBox} ammo boxes adjusted!");
        return Task.CompletedTask;
    }
}