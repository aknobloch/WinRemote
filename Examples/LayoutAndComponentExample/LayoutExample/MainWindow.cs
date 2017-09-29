using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Mime;
using System.Windows.Forms;

namespace LayoutExample
{
	/// <summary>
	/// A simple form that highlight some basic functionality of components,
	/// as well as using anchoring to position elements. Unforunately, there
	/// is no easy layout managers besides Docking and Anchoring, which 
	/// each have issues. From this example/test I've concluded that we 
	/// will likely be using an absolute layout rather than dynamic layout.
	/// </summary>
	
	public class MainWindow : Form
	{
		private static readonly Size DEFAULT_SIZE = new Size(1024, 768);
		
		private Button saveButton;
		private TextBox nameBox;
		private ToolTip toolTipManager;
		private PictureBox sstPicture;

		public MainWindow()
		{
			Initialize();
			AddSSTLogo();
			AddSaveButton();
			AddTextBox();
			CenterToScreen();
		}

		private void Initialize()
		{
			Text = "Layout Example";
			Size = DEFAULT_SIZE;
			
			SetResizable(true);
			SetIcon("ggc_logo.ico");
			
			toolTipManager = new ToolTip();
			saveButton = new Button();
			nameBox = new TextBox();
			sstPicture = new PictureBox();
		}
		
		/// <summary>
		/// This method adds the SST logo to the page, centering it horizontally
		/// and placing it 50 pixels from the top of the page.
		/// </summary>
		private void AddSSTLogo()
		{
			sstPicture.ImageLocation = "SST crest_small.png";
			sstPicture.SizeMode = PictureBoxSizeMode.AutoSize;
			AddTooltip(sstPicture, "GGC official SST logo.");
			
			var width = Image.FromFile("SST crest_small.png").Width;
			sstPicture.Location = new Point((DEFAULT_SIZE.Width / 2) - (width / 2), 50);
			sstPicture.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
			sstPicture.Parent = this;
		}
		
		private void AddSaveButton()
		{
			saveButton.Text = "Save";
			AddTooltip(saveButton, "Click here to save!");
			
			saveButton.Location = new Point((DEFAULT_SIZE.Width / 2) - saveButton.Width / 2, (DEFAULT_SIZE.Height / 3) * 2);
			saveButton.Anchor = AnchorStyles.Top;
			saveButton.Click += OnClick;
			saveButton.Parent = this;
		}
		
		private void AddTextBox()
		{
			AddTooltip(nameBox, "Enter a message to save here.");
			
			var textFieldSize = new Size(300, 100);
			var textFieldLocation = new Point((DEFAULT_SIZE.Width / 2) - textFieldSize.Width / 2, (DEFAULT_SIZE.Height / 2));
			nameBox.Bounds = new Rectangle(textFieldLocation, textFieldSize);
			nameBox.Anchor = AnchorStyles.Top;
			nameBox.Parent = this;
		}

		private void OnClick(object sender, EventArgs e)
		{
			string textEntered = nameBox.Text;
			Console.WriteLine("You have saved the following information: " + textEntered);
		}

		private void AddTooltip(Control component, string message)
		{	
			toolTipManager.SetToolTip(component, message);
		}

		public void SetResizable(bool isResizable)
		{
			if (isResizable)
			{
				MaximumSize = new Size();
				MinimumSize = new Size();
				SizeGripStyle = SizeGripStyle.Auto;
				MaximizeBox = true;
			}
			else
			{
				MaximumSize = new Size(Width, Height);
				MinimumSize = new Size(Width, Height);
				SizeGripStyle = SizeGripStyle.Hide;
				MaximizeBox = false;
			}
		}
		
		private void SetIcon(string filePath)
		{
			try
			{
				Icon = new Icon(filePath);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}