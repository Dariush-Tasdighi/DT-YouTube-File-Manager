namespace MyApplication;

partial class MainForm
{
	private System.ComponentModel.IContainer components = null;

	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}

		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	private void InitializeComponent()
	{
		myMenuStrip = new MenuStrip();
		headerPanel = new Panel();
		selectVideoPlayerPathNameButton = new Button();
		selectBrowserPathNameButton = new Button();
		videoCountTextBox = new TextBox();
		browserPathNameLabel = new Label();
		browserPathNameTextBox = new TextBox();
		searchLabel = new Label();
		videoPlayerPathNameLabel = new Label();
		videoPlayerPathNameTextBox = new TextBox();
		searchButton = new Button();
		searchTextBox = new TextBox();
		updateButton = new Button();
		targetPathTextBox = new TextBox();
		targetPathLabel = new Label();
		footerPanel = new Panel();
		videoUrlLabel = new Label();
		openVideoButton = new Button();
		videoUrlTextBox = new TextBox();
		channelUrlLabel = new Label();
		openChannelButton = new Button();
		channelUrlTextBox = new TextBox();
		channelsPanel = new Panel();
		channelsDataGridView = new DataGridView();
		channelsSplitter = new Splitter();
		videosPanel = new Panel();
		videosDataGridView = new DataGridView();
		headerPanel.SuspendLayout();
		footerPanel.SuspendLayout();
		channelsPanel.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)channelsDataGridView).BeginInit();
		videosPanel.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)videosDataGridView).BeginInit();
		SuspendLayout();
		// 
		// myMenuStrip
		// 
		myMenuStrip.ImageScalingSize = new Size(20, 20);
		myMenuStrip.Location = new Point(0, 0);
		myMenuStrip.Name = "myMenuStrip";
		myMenuStrip.Size = new Size(1105, 24);
		myMenuStrip.TabIndex = 0;
		myMenuStrip.Text = "menuStrip1";
		// 
		// headerPanel
		// 
		headerPanel.Controls.Add(selectVideoPlayerPathNameButton);
		headerPanel.Controls.Add(selectBrowserPathNameButton);
		headerPanel.Controls.Add(videoCountTextBox);
		headerPanel.Controls.Add(browserPathNameLabel);
		headerPanel.Controls.Add(browserPathNameTextBox);
		headerPanel.Controls.Add(searchLabel);
		headerPanel.Controls.Add(videoPlayerPathNameLabel);
		headerPanel.Controls.Add(videoPlayerPathNameTextBox);
		headerPanel.Controls.Add(searchButton);
		headerPanel.Controls.Add(searchTextBox);
		headerPanel.Controls.Add(updateButton);
		headerPanel.Controls.Add(targetPathTextBox);
		headerPanel.Controls.Add(targetPathLabel);
		headerPanel.Dock = DockStyle.Top;
		headerPanel.Location = new Point(0, 24);
		headerPanel.Name = "headerPanel";
		headerPanel.Size = new Size(1105, 140);
		headerPanel.TabIndex = 1;
		// 
		// selectVideoPlayerPathNameButton
		// 
		selectVideoPlayerPathNameButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		selectVideoPlayerPathNameButton.Location = new Point(1072, 70);
		selectVideoPlayerPathNameButton.Name = "selectVideoPlayerPathNameButton";
		selectVideoPlayerPathNameButton.Size = new Size(30, 24);
		selectVideoPlayerPathNameButton.TabIndex = 9;
		selectVideoPlayerPathNameButton.Text = "...";
		selectVideoPlayerPathNameButton.UseVisualStyleBackColor = true;
		selectVideoPlayerPathNameButton.Click += SelectVideoPlayerPathNameButton_Click;
		// 
		// selectBrowserPathNameButton
		// 
		selectBrowserPathNameButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		selectBrowserPathNameButton.Location = new Point(1072, 37);
		selectBrowserPathNameButton.Name = "selectBrowserPathNameButton";
		selectBrowserPathNameButton.Size = new Size(30, 24);
		selectBrowserPathNameButton.TabIndex = 6;
		selectBrowserPathNameButton.Text = "...";
		selectBrowserPathNameButton.UseVisualStyleBackColor = true;
		selectBrowserPathNameButton.Click += SelectBrowserPathNameButton_Click;
		// 
		// videoCountTextBox
		// 
		videoCountTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		videoCountTextBox.Location = new Point(915, 3);
		videoCountTextBox.Name = "videoCountTextBox";
		videoCountTextBox.ReadOnly = true;
		videoCountTextBox.Size = new Size(87, 27);
		videoCountTextBox.TabIndex = 2;
		// 
		// browserPathNameLabel
		// 
		browserPathNameLabel.AutoSize = true;
		browserPathNameLabel.Location = new Point(3, 39);
		browserPathNameLabel.Name = "browserPathNameLabel";
		browserPathNameLabel.Size = new Size(138, 20);
		browserPathNameLabel.TabIndex = 4;
		browserPathNameLabel.Text = "Browser Path Name";
		// 
		// browserPathNameTextBox
		// 
		browserPathNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		browserPathNameTextBox.Location = new Point(177, 36);
		browserPathNameTextBox.Name = "browserPathNameTextBox";
		browserPathNameTextBox.Size = new Size(889, 27);
		browserPathNameTextBox.TabIndex = 5;
		// 
		// searchLabel
		// 
		searchLabel.AutoSize = true;
		searchLabel.Location = new Point(3, 105);
		searchLabel.Name = "searchLabel";
		searchLabel.Size = new Size(53, 20);
		searchLabel.TabIndex = 10;
		searchLabel.Text = "Search";
		// 
		// videoPlayerPathNameLabel
		// 
		videoPlayerPathNameLabel.AutoSize = true;
		videoPlayerPathNameLabel.Location = new Point(3, 72);
		videoPlayerPathNameLabel.Name = "videoPlayerPathNameLabel";
		videoPlayerPathNameLabel.Size = new Size(168, 20);
		videoPlayerPathNameLabel.TabIndex = 7;
		videoPlayerPathNameLabel.Text = "Video Player Path Name";
		// 
		// videoPlayerPathNameTextBox
		// 
		videoPlayerPathNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		videoPlayerPathNameTextBox.Location = new Point(177, 69);
		videoPlayerPathNameTextBox.Name = "videoPlayerPathNameTextBox";
		videoPlayerPathNameTextBox.Size = new Size(889, 27);
		videoPlayerPathNameTextBox.TabIndex = 8;
		// 
		// searchButton
		// 
		searchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		searchButton.Location = new Point(1008, 102);
		searchButton.Name = "searchButton";
		searchButton.Size = new Size(94, 27);
		searchButton.TabIndex = 12;
		searchButton.Text = "&Search";
		searchButton.UseVisualStyleBackColor = true;
		searchButton.Click += SearchButton_Click;
		// 
		// searchTextBox
		// 
		searchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		searchTextBox.Location = new Point(177, 102);
		searchTextBox.Name = "searchTextBox";
		searchTextBox.Size = new Size(825, 27);
		searchTextBox.TabIndex = 11;
		// 
		// updateButton
		// 
		updateButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		updateButton.Location = new Point(1008, 3);
		updateButton.Name = "updateButton";
		updateButton.Size = new Size(94, 27);
		updateButton.TabIndex = 3;
		updateButton.Text = "&Update";
		updateButton.UseVisualStyleBackColor = true;
		updateButton.Click += UpdateButton_Click;
		// 
		// targetPathTextBox
		// 
		targetPathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		targetPathTextBox.Location = new Point(177, 3);
		targetPathTextBox.Name = "targetPathTextBox";
		targetPathTextBox.Size = new Size(732, 27);
		targetPathTextBox.TabIndex = 1;
		// 
		// targetPathLabel
		// 
		targetPathLabel.AutoSize = true;
		targetPathLabel.Location = new Point(3, 6);
		targetPathLabel.Name = "targetPathLabel";
		targetPathLabel.Size = new Size(82, 20);
		targetPathLabel.TabIndex = 0;
		targetPathLabel.Text = "Target Path";
		// 
		// footerPanel
		// 
		footerPanel.Controls.Add(videoUrlLabel);
		footerPanel.Controls.Add(openVideoButton);
		footerPanel.Controls.Add(videoUrlTextBox);
		footerPanel.Controls.Add(channelUrlLabel);
		footerPanel.Controls.Add(openChannelButton);
		footerPanel.Controls.Add(channelUrlTextBox);
		footerPanel.Dock = DockStyle.Bottom;
		footerPanel.Location = new Point(0, 568);
		footerPanel.Name = "footerPanel";
		footerPanel.Size = new Size(1105, 75);
		footerPanel.TabIndex = 3;
		// 
		// videoUrlLabel
		// 
		videoUrlLabel.AutoSize = true;
		videoUrlLabel.Location = new Point(3, 9);
		videoUrlLabel.Name = "videoUrlLabel";
		videoUrlLabel.Size = new Size(78, 20);
		videoUrlLabel.TabIndex = 3;
		videoUrlLabel.Text = "Video URL";
		// 
		// openVideoButton
		// 
		openVideoButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		openVideoButton.Location = new Point(1008, 6);
		openVideoButton.Name = "openVideoButton";
		openVideoButton.Size = new Size(94, 27);
		openVideoButton.TabIndex = 5;
		openVideoButton.Text = "Browse";
		openVideoButton.UseVisualStyleBackColor = true;
		openVideoButton.Click += OpenVideoButton_Click;
		// 
		// videoUrlTextBox
		// 
		videoUrlTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		videoUrlTextBox.Location = new Point(177, 6);
		videoUrlTextBox.Name = "videoUrlTextBox";
		videoUrlTextBox.ReadOnly = true;
		videoUrlTextBox.Size = new Size(825, 27);
		videoUrlTextBox.TabIndex = 4;
		// 
		// channelUrlLabel
		// 
		channelUrlLabel.AutoSize = true;
		channelUrlLabel.Location = new Point(3, 42);
		channelUrlLabel.Name = "channelUrlLabel";
		channelUrlLabel.Size = new Size(92, 20);
		channelUrlLabel.TabIndex = 0;
		channelUrlLabel.Text = "Channel URL";
		// 
		// openChannelButton
		// 
		openChannelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		openChannelButton.Location = new Point(1008, 39);
		openChannelButton.Name = "openChannelButton";
		openChannelButton.Size = new Size(94, 27);
		openChannelButton.TabIndex = 2;
		openChannelButton.Text = "Browse";
		openChannelButton.UseVisualStyleBackColor = true;
		openChannelButton.Click += OpenChannelButton_Click;
		// 
		// channelUrlTextBox
		// 
		channelUrlTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		channelUrlTextBox.Location = new Point(177, 39);
		channelUrlTextBox.Name = "channelUrlTextBox";
		channelUrlTextBox.ReadOnly = true;
		channelUrlTextBox.Size = new Size(825, 27);
		channelUrlTextBox.TabIndex = 1;
		// 
		// channelsPanel
		// 
		channelsPanel.Controls.Add(channelsDataGridView);
		channelsPanel.Dock = DockStyle.Top;
		channelsPanel.Location = new Point(0, 164);
		channelsPanel.Name = "channelsPanel";
		channelsPanel.Size = new Size(1105, 112);
		channelsPanel.TabIndex = 4;
		// 
		// channelsDataGridView
		// 
		channelsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		channelsDataGridView.Dock = DockStyle.Fill;
		channelsDataGridView.Location = new Point(0, 0);
		channelsDataGridView.Name = "channelsDataGridView";
		channelsDataGridView.RowHeadersWidth = 51;
		channelsDataGridView.Size = new Size(1105, 112);
		channelsDataGridView.TabIndex = 0;
		// 
		// channelsSplitter
		// 
		channelsSplitter.Dock = DockStyle.Top;
		channelsSplitter.Location = new Point(0, 276);
		channelsSplitter.Name = "channelsSplitter";
		channelsSplitter.Size = new Size(1105, 10);
		channelsSplitter.TabIndex = 2;
		channelsSplitter.TabStop = false;
		// 
		// videosPanel
		// 
		videosPanel.Controls.Add(videosDataGridView);
		videosPanel.Dock = DockStyle.Fill;
		videosPanel.Location = new Point(0, 286);
		videosPanel.Name = "videosPanel";
		videosPanel.Size = new Size(1105, 282);
		videosPanel.TabIndex = 6;
		// 
		// videosDataGridView
		// 
		videosDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		videosDataGridView.Dock = DockStyle.Fill;
		videosDataGridView.Location = new Point(0, 0);
		videosDataGridView.Name = "videosDataGridView";
		videosDataGridView.RowHeadersWidth = 51;
		videosDataGridView.Size = new Size(1105, 282);
		videosDataGridView.TabIndex = 0;
		// 
		// MainForm
		// 
		AutoScaleDimensions = new SizeF(8F, 20F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(1105, 643);
		Controls.Add(videosPanel);
		Controls.Add(channelsSplitter);
		Controls.Add(channelsPanel);
		Controls.Add(footerPanel);
		Controls.Add(headerPanel);
		Controls.Add(myMenuStrip);
		MainMenuStrip = myMenuStrip;
		Name = "MainForm";
		StartPosition = FormStartPosition.CenterScreen;
		WindowState = FormWindowState.Maximized;
		Load += MainForm_Load;
		headerPanel.ResumeLayout(false);
		headerPanel.PerformLayout();
		footerPanel.ResumeLayout(false);
		footerPanel.PerformLayout();
		channelsPanel.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)channelsDataGridView).EndInit();
		videosPanel.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)videosDataGridView).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private MenuStrip myMenuStrip;
	private Panel headerPanel;
	private Panel footerPanel;
	private Panel channelsPanel;
	private Splitter channelsSplitter;
	private Panel videosPanel;
	private TextBox targetPathTextBox;
	private Label targetPathLabel;
	private Button updateButton;
	private DataGridView channelsDataGridView;
	private DataGridView videosDataGridView;
	private Button searchButton;
	private TextBox searchTextBox;
	private Label searchLabel;
	private Label videoPlayerPathNameLabel;
	private TextBox videoPlayerPathNameTextBox;
	private Label channelUrlLabel;
	private Button openChannelButton;
	private TextBox channelUrlTextBox;
	private Label videoUrlLabel;
	private Button openVideoButton;
	private TextBox videoUrlTextBox;
	private Label browserPathNameLabel;
	private TextBox browserPathNameTextBox;
	private TextBox videoCountTextBox;
	private Button selectVideoPlayerPathNameButton;
	private Button selectBrowserPathNameButton;
}
