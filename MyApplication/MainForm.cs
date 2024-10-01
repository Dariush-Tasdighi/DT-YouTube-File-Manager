using System.Diagnostics;

namespace MyApplication;

public partial class MainForm : Form
{
	public MainForm()
	{
		InitializeComponent();
	}

	private List<YouTubeVideoItem> List { get; set; } = [];
	private OpenFileDialog MyOpenFileDialog { get; set; } = new();
	private YouTubeVideoItem? SelectedYouTubeVideoItem { get; set; }

	private void MainForm_Load(object sender, EventArgs e)
	{
		channelsPanel.Visible = false;
		channelsSplitter.Visible = false;

		// **************************************************
		AcceptButton = searchButton;

		Text = "DT YouTube File Manager - Version 1.4 - Always! Persian Gulf";

		targetPathTextBox.Text = @"D:\YouTubeDownloads";
		videoPlayerPathNameTextBox.Text = @"C:\Program Files\VideoLAN\VLC\vlc.exe";
		browserPathNameTextBox.Text = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
		// **************************************************

		// **************************************************
		// **************************************************
		// **************************************************
		channelsDataGridView.MultiSelect = false;

		channelsDataGridView.SelectionMode =
			DataGridViewSelectionMode.FullRowSelect;

		channelsDataGridView.EditMode =
			DataGridViewEditMode.EditProgrammatically;
		// **************************************************

		// **************************************************
		videosDataGridView.MultiSelect = false;

		videosDataGridView.SelectionMode =
			DataGridViewSelectionMode.FullRowSelect;

		videosDataGridView.EditMode =
			DataGridViewEditMode.EditProgrammatically;
		// **************************************************

		// **************************************************
		videosDataGridView.KeyDown += VideosDataGridView_KeyDown;
		videosDataGridView.RowEnter += VideosDataGridView_RowEnter;
		videosDataGridView.CellPainting += VideosDataGridView_CellPainting;
		videosDataGridView.CellDoubleClick += VideosDataGridView_CellDoubleClick;
		// **************************************************
		// **************************************************
		// **************************************************

		UpdateList();

		// **************************************************
		headerPanel.TabIndex = 0;
		channelsPanel.TabIndex = 1;
		channelsSplitter.TabIndex = 2;
		videosPanel.TabIndex = 3;
		footerPanel.TabIndex = 4;
		myMenuStrip.TabIndex = 5;

		videosDataGridView.TabIndex = 0;
		// **************************************************
	}

	private void UpdateButton_Click(object sender, EventArgs e)
	{
		UpdateList();
	}

	private void UpdateList()
	{
		List.Clear();
		UpdateDataGridViews();

		if (Directory.Exists(path: targetPathTextBox.Text) == false)
		{
			MessageBox.Show(text: "Path not found!");
			return;
		}

		var directoryInfo =
			new DirectoryInfo(path: targetPathTextBox.Text);

		var files =
			directoryInfo.GetFiles();

		foreach (var file in files)
		{
			try
			{
				if (file.Extension.ToLower() != ".srt")
				{
					var youTubeVideoItem =
						new YouTubeVideoItem(fileInfo: file);

					var fileNameWithoutExtension = youTubeVideoItem.FullName!
						.Substring(startIndex: 0, length: youTubeVideoItem.FullName.Length - 4);

					var captionNameWithExtension =
						$"{fileNameWithoutExtension}.srt";

					if (File.Exists(path: captionNameWithExtension))
					{
						youTubeVideoItem.HasSubtitle = true;
					}

					List.Add(item: youTubeVideoItem);
				}
			}
			catch
			{
			}
		}

		totalVideoCountTextBox.Text =
			List.Count.ToString(format: "#,##0");

		UpdateDataGridViews();
	}

	private void SearchButton_Click(object sender, EventArgs e)
	{
		UpdateDataGridViews();
	}

	private void UpdateDataGridViews()
	{
		videoUrlTextBox.Text = string.Empty;
		channelUrlTextBox.Text = string.Empty;

		List<YouTubeVideoItem> list;

		if (string.IsNullOrWhiteSpace(value: channelTitleComboBox.Text))
		{
			if (string.IsNullOrWhiteSpace(value: videoTitleTextBox.Text))
			{
				list =
					List
					.OrderBy(current => current.AuthorChannelTitle)
					.ThenByDescending(current => current.UploadedDate)
					.ToList()
					;
			}
			else
			{
				list =
					List
					.Where(current =>
						current.Title != null &&
						current.Title.ToLower().Contains(videoTitleTextBox.Text.ToLower()))
					.OrderByDescending(current => current.UploadedDate)
					.ToList()
					;
			}
		}
		else
		{
			if (string.IsNullOrWhiteSpace(value: videoTitleTextBox.Text))
			{
				list =
					List
					.Where(current =>
						current.AuthorChannelTitle != null &&
						current.AuthorChannelTitle.ToLower().Contains(channelTitleComboBox.Text.ToLower()))
					.OrderBy(current => current.AuthorChannelTitle)
					.ThenByDescending(current => current.UploadedDate)
					.ToList()
					;
			}
			else
			{
				list =
					List
					.Where(current =>
						current.AuthorChannelTitle != null &&
						current.AuthorChannelTitle.ToLower().Contains(channelTitleComboBox.Text.ToLower()))
					.Where(current =>
						current.Title != null &&
						current.Title.ToLower().Contains(videoTitleTextBox.Text.ToLower()))
					.ToList()
					;
			}
		}

		searchVideoCountTextBox.Text =
			list.Count.ToString(format: "#,##0");

		videosDataGridView.DataSource = list;

		for (int columnIndex = 0; columnIndex <= videosDataGridView.Columns.Count - 1; columnIndex++)
		{
			switch (columnIndex)
			{
				case 3:
				{
					videosDataGridView.Columns[columnIndex]
						.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
					break;
				}

				default:
				{
					videosDataGridView.Columns[columnIndex]
						.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
					break;
				}
			}
		}

		videosDataGridView.Columns[5].DefaultCellStyle
			.Alignment = DataGridViewContentAlignment.MiddleRight;
	}

	private void VideosDataGridView_KeyDown(object? sender, KeyEventArgs e)
	{
		if (e.KeyValue == 13)
		{
			e.Handled = true;
			PlaySelectedVideo();
		}
	}

	private void VideosDataGridView_RowEnter
		(object? sender, DataGridViewCellEventArgs e)
	{
		SelectedYouTubeVideoItem =
			videosDataGridView.Rows[e.RowIndex].DataBoundItem
			as YouTubeVideoItem;

		if (SelectedYouTubeVideoItem is null)
		{
			return;
		}

		videoUrlTextBox.Text = SelectedYouTubeVideoItem.Url;
		videoFileNameTextBox.Text = SelectedYouTubeVideoItem.FileName;
		channelUrlTextBox.Text = SelectedYouTubeVideoItem.AuthorChannelUrl;
	}


	private void VideosDataGridView_CellPainting
		(object? sender, DataGridViewCellPaintingEventArgs e)
	{
		if (e.Value is null)
		{
			return;
		}

		string? cellValue = e.Value.ToString();

		if (Utility.IsFirstLetterIsPersian(text: cellValue))
		{
			if (e.Graphics is null ||
				e.CellStyle is null ||
				e.FormattedValue is null)
			{
				return;
			}

			e.PaintBackground(
				clipBounds: e.CellBounds,
				cellsPaintSelectionBackground: true
				);

			TextRenderer.DrawText(
				dc: e.Graphics,
				bounds: e.CellBounds,
				font: e.CellStyle.Font,
				foreColor: e.CellStyle.ForeColor,
				text: e.FormattedValue.ToString(),
				flags: TextFormatFlags.RightToLeft | TextFormatFlags.Right
				);

			e.Handled = true;
		}
	}

	private void VideosDataGridView_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
	{
		PlaySelectedVideo();
	}

	private void PlaySelectedVideo()
	{
		var selectedYouTubeVideoItems =
			videosDataGridView.SelectedRows;

		if (selectedYouTubeVideoItems.Count == 0)
		{
			return;
		}

		var selectedYouTubeVideoItem =
			selectedYouTubeVideoItems[0].DataBoundItem
			as YouTubeVideoItem;

		if (selectedYouTubeVideoItem is null)
		{
			return;
		}

		var processInfo =
			new ProcessStartInfo
			{
				FileName = videoPlayerPathNameTextBox.Text,
				Arguments = $"\"{selectedYouTubeVideoItem.FullName}\"",

				Verb = string.Empty, // Default: [""]
				WorkingDirectory = string.Empty, // Default: [""]

				ErrorDialog = false, // Default: [false]
				CreateNoWindow = false, // Default: [false]
				LoadUserProfile = false, // Default: [false]
				UseShellExecute = false,// Default: [false]

				StandardErrorEncoding = null, // Default: [null]
				StandardInputEncoding = null, // Default: [null]
				StandardOutputEncoding = null, // Default: [null]

				RedirectStandardError = false, // Default: [false]
				RedirectStandardInput = false, // Default: [false]
				RedirectStandardOutput = false, // Default: [false]

				Domain = string.Empty, // Default: [""]
				UserName = string.Empty, // Default: [""]
				Password = null, // Default: [null]
				PasswordInClearText = null, // Default: [null]
				UseCredentialsForNetworkingOnly = false, // Default: [false]

				// Note
				WindowStyle = ProcessWindowStyle.Normal, // Default: [normal]
			};

		using var process = new Process();

		process.StartInfo = processInfo;

		process.Start();
	}

	private void OpenVideoUrlButton_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(value: videoUrlTextBox.Text))
		{
			return;
		}

		var processInfo =
			new ProcessStartInfo
			{
				Arguments = videoUrlTextBox.Text,
				FileName = browserPathNameTextBox.Text,

				Verb = string.Empty, // Default: [""]
				WorkingDirectory = string.Empty, // Default: [""]

				ErrorDialog = false, // Default: [false]
				CreateNoWindow = false, // Default: [false]
				LoadUserProfile = false, // Default: [false]
				UseShellExecute = false,// Default: [false]

				StandardErrorEncoding = null, // Default: [null]
				StandardInputEncoding = null, // Default: [null]
				StandardOutputEncoding = null, // Default: [null]

				RedirectStandardError = false, // Default: [false]
				RedirectStandardInput = false, // Default: [false]
				RedirectStandardOutput = false, // Default: [false]

				Domain = string.Empty, // Default: [""]
				UserName = string.Empty, // Default: [""]
				Password = null, // Default: [null]
				PasswordInClearText = null, // Default: [null]
				UseCredentialsForNetworkingOnly = false, // Default: [false]

				// Note
				WindowStyle = ProcessWindowStyle.Normal, // Default: [normal]
			};

		using var process = new Process();

		process.StartInfo = processInfo;

		process.Start();
	}

	private void OpenChannelUrlButton_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(value: videoUrlTextBox.Text))
		{
			return;
		}

		var processInfo =
			new ProcessStartInfo
			{
				Arguments = channelUrlTextBox.Text,
				FileName = browserPathNameTextBox.Text,

				Verb = string.Empty, // Default: [""]
				WorkingDirectory = string.Empty, // Default: [""]

				ErrorDialog = false, // Default: [false]
				CreateNoWindow = false, // Default: [false]
				LoadUserProfile = false, // Default: [false]
				UseShellExecute = false,// Default: [false]

				StandardErrorEncoding = null, // Default: [null]
				StandardInputEncoding = null, // Default: [null]
				StandardOutputEncoding = null, // Default: [null]

				RedirectStandardError = false, // Default: [false]
				RedirectStandardInput = false, // Default: [false]
				RedirectStandardOutput = false, // Default: [false]

				Domain = string.Empty, // Default: [""]
				UserName = string.Empty, // Default: [""]
				Password = null, // Default: [null]
				PasswordInClearText = null, // Default: [null]
				UseCredentialsForNetworkingOnly = false, // Default: [false]

				// Note
				WindowStyle = ProcessWindowStyle.Normal, // Default: [normal]
			};

		using var process = new Process();

		process.StartInfo = processInfo;

		process.Start();
	}

	private void SelectFileInExplorerButton_Click(object sender, EventArgs e)
	{
		if (SelectedYouTubeVideoItem is null)
		{
			return;
		}

		if (File.Exists(path: SelectedYouTubeVideoItem.FullName) == false)
		{
			return;
		}

		var processInfo =
			new ProcessStartInfo
			{
				FileName = "explorer.exe",
				Arguments = $"/select, \"{SelectedYouTubeVideoItem.FullName}\"",

				Verb = string.Empty, // Default: [""]
				WorkingDirectory = string.Empty, // Default: [""]

				ErrorDialog = false, // Default: [false]
				CreateNoWindow = false, // Default: [false]
				LoadUserProfile = false, // Default: [false]
				UseShellExecute = false,// Default: [false]

				StandardErrorEncoding = null, // Default: [null]
				StandardInputEncoding = null, // Default: [null]
				StandardOutputEncoding = null, // Default: [null]

				RedirectStandardError = false, // Default: [false]
				RedirectStandardInput = false, // Default: [false]
				RedirectStandardOutput = false, // Default: [false]

				Domain = string.Empty, // Default: [""]
				UserName = string.Empty, // Default: [""]
				Password = null, // Default: [null]
				PasswordInClearText = null, // Default: [null]
				UseCredentialsForNetworkingOnly = false, // Default: [false]

				// Note
				WindowStyle = ProcessWindowStyle.Normal, // Default: [normal]
			};

		using var process = new Process();

		process.StartInfo = processInfo;

		process.Start();
	}

	private void SelectBrowserPathNameButton_Click(object sender, EventArgs e)
	{
		MyOpenFileDialog.Multiselect = false;
		MyOpenFileDialog.CheckFileExists = true;
		MyOpenFileDialog.CheckPathExists = true;
		MyOpenFileDialog.InitialDirectory = @"C:\Program Files";
		MyOpenFileDialog.Filter = "Executable Files|*.exe|All Files|*.*";

		var result =
			MyOpenFileDialog.ShowDialog();

		if (result == DialogResult.OK)
		{
			browserPathNameTextBox.Text = MyOpenFileDialog.FileName;
		}
	}

	private void SelectVideoPlayerPathNameButton_Click(object sender, EventArgs e)
	{
		MyOpenFileDialog.Multiselect = false;
		MyOpenFileDialog.CheckFileExists = true;
		MyOpenFileDialog.CheckPathExists = true;
		MyOpenFileDialog.InitialDirectory = @"C:\Program Files";
		MyOpenFileDialog.Filter = "Executable Files|*.exe|All Files|*.*";

		var result =
			MyOpenFileDialog.ShowDialog();

		if (result == DialogResult.OK)
		{
			videoPlayerPathNameTextBox.Text = MyOpenFileDialog.FileName;
		}
	}
}
