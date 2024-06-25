using System;
using System.Text.Json;
using Lazy;
using YoutubeExplode.Utils.Extensions;

namespace YoutubeExplode.Bridge;

internal class HeatmapData(JsonElement content)
{
    [Lazy]
    public long TimeRangeStartMills =>
        Convert.ToInt64(content.GetPropertyOrNull("startMillis")?.GetStringOrNull() ?? "0");

    [Lazy]
    public long MarkerDurationMills =>
        Convert.ToInt64(content.GetPropertyOrNull("durationMillis")?.GetStringOrNull() ?? "0");

    [Lazy]
    public decimal HeatMarkerIntensityScoreNormalized =>
        content.GetPropertyOrNull("intensityScoreNormalized")?.GetDecimal() ?? 0;
}
