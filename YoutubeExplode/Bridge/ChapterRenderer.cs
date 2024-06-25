using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Lazy;
using YoutubeExplode.Utils.Extensions;

namespace YoutubeExplode.Bridge;

internal class ChapterRenderer(JsonElement content)
{
    [Lazy]
    public long? TimeRangeStartMillis =>
        content
            .GetPropertyOrNull("chapterRenderer")
            ?.GetPropertyOrNull("timeRangeStartMillis")
            ?.GetInt64OrNull();

    [Lazy]
    public string? Title =>
        content
            .GetPropertyOrNull("chapterRenderer")
            ?.GetPropertyOrNull("title")
            ?.GetPropertyOrNull("simpleText")
            ?.GetStringOrNull();

    [Lazy]
    public IReadOnlyList<ThumbnailData> Thumbnails =>
        content
            .GetPropertyOrNull("chapterRenderer")
            ?.GetPropertyOrNull("thumbnail")
            ?.GetPropertyOrNull("thumbnails")
            ?.EnumerateArrayOrNull()
            ?.Select(j => new ThumbnailData(j))
            .ToArray() ?? Array.Empty<ThumbnailData>();
}
