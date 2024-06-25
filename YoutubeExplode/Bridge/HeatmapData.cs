using System.Text.Json;
using Lazy;
using YoutubeExplode.Utils.Extensions;

namespace YoutubeExplode.Bridge;

internal class HeatmapData(JsonElement content)
{
    [Lazy]
    public long TimeRangeStartMills =>
        content.GetPropertyOrNull("startMillis")?.GetInt64OrNull() ?? 0;

    [Lazy]
    public long MarkerDurationMills =>
        content.GetPropertyOrNull("durationMillis")?.GetInt64OrNull() ?? 0;

    [Lazy]
    public decimal HeatMarkerIntensityScoreNormalized =>
        content.GetPropertyOrNull("intensityScoreNormalized")?.GetDecimal() ?? 0;
}
