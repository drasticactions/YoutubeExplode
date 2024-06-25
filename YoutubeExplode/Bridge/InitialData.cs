using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Lazy;
using YoutubeExplode.Utils.Extensions;
using YoutubeExplode.Videos;

namespace YoutubeExplode.Bridge;

internal class InitialData(JsonElement content)
{
    public JsonElement.ArrayEnumerator? TryGetPlayerBarMarkersMap() =>
        content
            .GetPropertyOrNull("playerOverlays")
            ?.GetPropertyOrNull("playerOverlayRenderer")
            ?.GetPropertyOrNull("decoratedPlayerBarRenderer")
            ?.GetPropertyOrNull("decoratedPlayerBarRenderer")
            ?.GetPropertyOrNull("playerBar")
            ?.GetPropertyOrNull("multiMarkersPlayerBarRenderer")
            ?.GetPropertyOrNull("markersMap")
            ?.EnumerateArrayOrNull();

    private JsonElement.ArrayEnumerator? TryGetMutations() =>
        content
            .GetPropertyOrNull("frameworkUpdates")
            ?.GetPropertyOrNull("entityBatchUpdate")
            ?.GetPropertyOrNull("mutations")
            ?.EnumerateArrayOrNull();

    private JsonElement.ArrayEnumerator? TryGetMarkersMap() =>
        this.TryGetMutations()
            ?.Where(n =>
                n.GetPropertyOrNull("payload")?.GetPropertyOrNull("macroMarkersListEntity")
                    is not null
            )
            .FirstOrNull()
            ?.GetPropertyOrNull("payload")
            ?.GetPropertyOrNull("macroMarkersListEntity")
            ?.GetPropertyOrNull("markersList")
            ?.GetPropertyOrNull("markers")
            ?.EnumerateArrayOrNull();

    [Lazy]
    public IReadOnlyList<HeatmapData>? Heatmap =>
        this.TryGetMarkersMap()?.Select(j => new HeatmapData(j)).ToArray() ?? [];

    [Lazy]
    public IReadOnlyList<ChapterRenderer>? Chapters =>
        this.TryGetPlayerBarMarkersMap()
            ?.Where(n => n.GetPropertyOrNull("key")?.GetStringOrNull() == "DESCRIPTION_CHAPTERS")
            .FirstOrNull()
            ?.GetPropertyOrNull("value")
            ?.GetPropertyOrNull("chapters")
            ?.EnumerateArrayOrNull()
            ?.Select(j => new ChapterRenderer(j))
            .ToArray() ?? Array.Empty<ChapterRenderer>();

    public override string ToString()
    {
        return content.ToString();
    }
}
