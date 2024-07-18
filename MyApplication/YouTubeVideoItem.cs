using System.ComponentModel;

namespace MyApplication;

internal class YouTubeVideoItem : object
{
	public YouTubeVideoItem() : base()
	{
	}

	public YouTubeVideoItem(FileInfo fileInfo) : base()
	{
		FileName = fileInfo.Name;
		FileLength = fileInfo.Length;
		FullName = fileInfo.FullName;

		var fileName = fileInfo.Name;

		AuthorChannelId =
			fileName
			.Substring(startIndex: 0, length: 24);

		fileName =
			fileName
			.Substring(startIndex: 25);

		UploadedDate =
			fileName
			.Replace(oldValue: "_", newValue: "/")
			.Substring(startIndex: 0, length: 10);

		fileName =
			fileName
			.Substring(startIndex: 11);

		Id =
			fileName
			.Substring(startIndex: 0, length: 11);

		fileName =
			fileName
			.Substring(startIndex: 12);

		var parts =
			fileName.Split(separator: '_');

		AuthorChannelTitle = parts[0];

		Title = parts[1];

		Quality =
			Convert.ToInt32(parts[2]);

		var subParts =
			parts[3].Split(separator: '.');

		QualityFramerate =
			Convert.ToInt32(subParts[0]);

		FileExtension = subParts[1];

		Url = $"https://www.youtube.com/watch?v={Id}";
		AuthorChannelUrl = $"https://www.youtube.com/channel/{AuthorChannelId}";
	}

	[DisplayName(displayName: "Channel Title")]
	public string? AuthorChannelTitle { get; set; }

	[DisplayName(displayName: "Subtitle")]
	public bool HasSubtitle { get; set; }

	[DisplayName(displayName: "Upload")]
	public string? UploadedDate { get; set; }

	public string? Title { get; set; }

	[DisplayName(displayName: "Extension")]
	public string? FileExtension { get; set; }

	[Browsable(browsable: false)]
	public long FileLength { get; set; }

	[DisplayName(displayName: "Length")]
	public string FileLengthString
	{
		get
		{
			var result =
				Convert.ToInt32((double)FileLength / ((double)1024 * (double)1024))
				.ToString(format: "#,##0.00 MB");

			return result;
		}
	}

	[Browsable(browsable: false)]
	public int Quality { get; set; }

	[Browsable(browsable: false)]
	public int QualityFramerate { get; set; }

	[DisplayName(displayName: "Quality")]
	public string DisplayQualityAndFramerate
	{
		get
		{
			var result =
				$"{Quality}p{QualityFramerate}";

			return result;
		}
	}

	[Browsable(browsable: false)]
	public string? Id { get; set; }

	[Browsable(browsable: false)]
	public string? Url { get; set; }

	[Browsable(browsable: false)]
	public string? FileName { get; set; }

	[Browsable(browsable: false)]
	public string? FullName { get; set; }

	[Browsable(browsable: false)]
	public string? AuthorChannelId { get; set; }

	[Browsable(browsable: false)]
	public string? AuthorChannelUrl { get; set; }
}
