using System;
using System.Collections.Generic;
using YoutubeExplode.Common;

namespace YoutubeExplode.Videos;

/// <summary>
/// Chapter Descriptions.
/// </summary>
public class ChapterDescription(string title, long time, IReadOnlyList<Thumbnail> thumbnails)
{
    /// <summary>
    /// Gets the chapter title.
    /// </summary>
    public string Title { get; } = title;

    /// <summary>
    /// Gets time Range Starting in Milliseconds.
    /// </summary>
    public long TimeRangeStartMillis { get; } = time;

    /// <summary>
    /// Gets the chapter description thumbnails.
    /// </summary>
    public IReadOnlyList<Thumbnail> Thumbnails { get; } = thumbnails;

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{Title} - {TimeSpan.FromMilliseconds(TimeRangeStartMillis).ToString()}";
    }
}
