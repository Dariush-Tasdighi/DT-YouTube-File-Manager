using System.Diagnostics;

namespace MyApplication;

public partial class MainForm : Form
{
	public MainForm()
	{
		InitializeComponent();
	}

	private List<YouTubeVideoItem> List { get; set; } = [];

	private void MainForm_Load(object sender, EventArgs e)
	{
		channelsPanel.Visible = false;
		channelsSplitter.Visible = false;

		// **************************************************
		AcceptButton = searchButton;

		Text = "DT YouTube File Manager - Version 1.1 - Always! Persian Gulf";

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

		videoCountTextBox.Text =
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

		if(string.IsNullOrWhiteSpace(value: channelTitleComboBox.Text))
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

		videosDataGridView.DataSource = list;

		for (int columnIndex = 0; columnIndex <= videosDataGridView.Columns.Count - 1; columnIndex++)
		{
			switch (columnIndex)
			{
				case 3:
				{
					videosDataGridView.Columns[columnIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
					break;
				}

				default:
				{
					videosDataGridView.Columns[columnIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
					break;
				}
			}
		}
	}

	private void VideosDataGridView_KeyDown(object? sender, KeyEventArgs e)
	{
		if (e.KeyValue == 13)
		{
			e.Handled = true;
			PlaySelectedVideo();
		}
	}

	private void VideosDataGridView_RowEnter(object? sender, DataGridViewCellEventArgs e)
	{
		var selectedYouTubeVideoItem =
			videosDataGridView.Rows[e.RowIndex].DataBoundItem as YouTubeVideoItem;

		if (selectedYouTubeVideoItem is null)
		{
			return;
		}

		videoUrlTextBox.Text = selectedYouTubeVideoItem.Url;
		channelUrlTextBox.Text = selectedYouTubeVideoItem.AuthorChannelUrl;
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
			selectedYouTubeVideoItems[0].DataBoundItem as YouTubeVideoItem;

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

	private void OpenVideoButton_Click(object sender, EventArgs e)
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

	private void OpenChannelButton_Click(object sender, EventArgs e)
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

	private OpenFileDialog MyOpenFileDialog { get; set; } = new();

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
