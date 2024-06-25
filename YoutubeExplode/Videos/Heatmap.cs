using System;
using System.Diagnostics.CodeAnalysis;

namespace YoutubeExplode.Videos;

/// <summary>
/// Represents a heatmarker in a video.
/// </summary>
public class Heatmap(
    long timeRangeStartMills,
    long markerDurationMills,
    decimal heatMarkerIntensityScoreNormalized,
    TimeSpan markerStart
)
{
    /// <summary>
    /// Gets the start time of the heatmarker in milliseconds.
    /// </summary>
    public long TimeRangeStartMills { get; } = timeRangeStartMills;

    /// <summary>
    /// Gets the duration of the heatmarker in milliseconds.
    /// </summary>
    public long MarkerDurationMills { get; } = markerDurationMills;

    /// <summary>
    /// Gets the start time of the heatmarker.
    /// </summary>
    public TimeSpan MarkerStart { get; } = markerStart;

    /// <summary>
    /// Gets the intensity score of the heatmarker, normalized.
    /// </summary>
    public decimal HeatMarkerIntensityScoreNormalized { get; } = heatMarkerIntensityScoreNormalized;

    /// <inheritdoc />
    [ExcludeFromCodeCoverage]
    public override string ToString() =>
        $"Heatmap: {this.MarkerStart},{this.MarkerDurationMills},{this.HeatMarkerIntensityScoreNormalized}";
}
