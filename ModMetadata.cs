﻿using SPTarkov.Server.Core.Models.Spt.Mod;
using Range = SemanticVersioning.Range;
using Version = SemanticVersioning.Version;

namespace SlimmerMagazines;

public record ModMetadata : AbstractModMetadata
{
    public override string ModGuid { get; init; } = "com.jero.ammobox1x1";
    public override string Name { get; init; } = "AmmoBox1x1";
    public override string Author { get; init; } = "jero";
    public override List<string>? Contributors { get; init; }
    public override Version Version { get; init; } = new("1.0.0");
    public override Range SptVersion { get; init; } = new("~4.0.1");
    public override List<string>? Incompatibilities { get; init; }
    public override Dictionary<string, Range>? ModDependencies { get; init; }
    public override string? Url { get; init; }
    public override bool? IsBundleMod { get; init; }
    public override string License { get; init; } = "MIT";
}