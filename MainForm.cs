using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

using System.Net;
using System.Configuration;

namespace SearchTest {
	/// <summary>
	/// Main query form
	/// </summary>
	public class MainForm : System.Windows.Forms.Form {
		// TODO: Add SQL syntax highlighting (http://www.publicjoe.f9.co.uk/csharp/articles/csc-syn1.html)
		// TODO: Add results XML syntax highlighting

		#region Variables

		// Form Controls
		private System.Windows.Forms.Label lblWebSvcUrl;
		private System.Windows.Forms.Button btnExecute;
		private System.Windows.Forms.TextBox txtWebSvcUrl;
		private System.Windows.Forms.Label lblQueryText;
		private System.Windows.Forms.TextBox txtResults;
		private System.Windows.Forms.TabControl tabsResults;
		private System.Windows.Forms.TabPage tabResults;
		private System.Windows.Forms.TabPage tabPortalInfo;
		private System.Windows.Forms.TabPage tabQueryPacket;
		private System.Windows.Forms.TextBox txtRegistrationReply;
		private System.Windows.Forms.TextBox txtPortalSearchInfo;
		private System.Windows.Forms.TextBox txtQueryPacket;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem mnuFileExit;
		private System.Windows.Forms.MenuItem mnuHelp;
		private System.Windows.Forms.MenuItem mnuHelpAbout;
		private System.Windows.Forms.TabPage tabRegistrationReply;
		private System.Windows.Forms.TabPage tabRegistrationPacket;
		private System.Windows.Forms.TextBox txtRegistrationPacket;
		private System.Windows.Forms.MenuItem mnuOptions;
		private System.Windows.Forms.MenuItem mmnOptionsContent;
		private System.Windows.Forms.MenuItem mnuOptionsContentDocument;
		private System.Windows.Forms.MenuItem mnuOptionsContentContent;
		private System.Windows.Forms.MenuItem mnuOptionsContentForm;
		private System.Windows.Forms.MenuItem mnuOptionsQuerytype;
		private System.Windows.Forms.MenuItem mnuOptionsQuerytypeKeyword;
		private System.Windows.Forms.MenuItem mnuOptionsQuerytypeSqlft;
		private System.Windows.Forms.MenuItem mnuOptionsRecordlimits;
		private ICSharpCode.TextEditor.TextEditorControl txtQueryText;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// The search logic/service object.
		/// </summary>
		private SearchLogic searchSvc = null;

		/// <summary>
		/// The first record to return from the query.
		/// </summary>
		private int recLimitStartAt = 1;

		/// <summary>
		/// The max number of records to return fro the query.
		/// </summary>
		private int recLimitMaxReturned = 1000;

		#endregion


		#region Constructors

		public MainForm() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			// Add the handler so we can enable/disable the execute query button
			txtQueryText.Document.DocumentChanged +=new ICSharpCode.TextEditor.Document.DocumentEventHandler(Document_DocumentChanged);

			searchSvc = new SearchLogic();
		}

		#endregion


		#region Destructors/Cleanup

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.txtWebSvcUrl = new System.Windows.Forms.TextBox();
			this.lblWebSvcUrl = new System.Windows.Forms.Label();
			this.lblQueryText = new System.Windows.Forms.Label();
			this.btnExecute = new System.Windows.Forms.Button();
			this.txtResults = new System.Windows.Forms.TextBox();
			this.tabsResults = new System.Windows.Forms.TabControl();
			this.tabResults = new System.Windows.Forms.TabPage();
			this.tabRegistrationPacket = new System.Windows.Forms.TabPage();
			this.txtRegistrationPacket = new System.Windows.Forms.TextBox();
			this.tabRegistrationReply = new System.Windows.Forms.TabPage();
			this.txtRegistrationReply = new System.Windows.Forms.TextBox();
			this.tabPortalInfo = new System.Windows.Forms.TabPage();
			this.txtPortalSearchInfo = new System.Windows.Forms.TextBox();
			this.tabQueryPacket = new System.Windows.Forms.TabPage();
			this.txtQueryPacket = new System.Windows.Forms.TextBox();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.mnuFileExit = new System.Windows.Forms.MenuItem();
			this.mnuOptions = new System.Windows.Forms.MenuItem();
			this.mmnOptionsContent = new System.Windows.Forms.MenuItem();
			this.mnuOptionsContentDocument = new System.Windows.Forms.MenuItem();
			this.mnuOptionsContentContent = new System.Windows.Forms.MenuItem();
			this.mnuOptionsContentForm = new System.Windows.Forms.MenuItem();
			this.mnuOptionsQuerytype = new System.Windows.Forms.MenuItem();
			this.mnuOptionsQuerytypeKeyword = new System.Windows.Forms.MenuItem();
			this.mnuOptionsQuerytypeSqlft = new System.Windows.Forms.MenuItem();
			this.mnuOptionsRecordlimits = new System.Windows.Forms.MenuItem();
			this.mnuHelp = new System.Windows.Forms.MenuItem();
			this.mnuHelpAbout = new System.Windows.Forms.MenuItem();
			this.txtQueryText = new ICSharpCode.TextEditor.TextEditorControl();
			this.tabsResults.SuspendLayout();
			this.tabResults.SuspendLayout();
			this.tabRegistrationPacket.SuspendLayout();
			this.tabRegistrationReply.SuspendLayout();
			this.tabPortalInfo.SuspendLayout();
			this.tabQueryPacket.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtWebSvcUrl
			// 
			this.txtWebSvcUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtWebSvcUrl.Location = new System.Drawing.Point(112, 8);
			this.txtWebSvcUrl.Name = "txtWebSvcUrl";
			this.txtWebSvcUrl.Size = new System.Drawing.Size(264, 20);
			this.txtWebSvcUrl.TabIndex = 1;
			this.txtWebSvcUrl.Text = "http://";
			this.txtWebSvcUrl.TextChanged += new System.EventHandler(this.txtWebSvcUrl_TextChanged);
			this.txtWebSvcUrl.Leave += new System.EventHandler(this.txtWebSvcUrl_Leave);
			// 
			// lblWebSvcUrl
			// 
			this.lblWebSvcUrl.CausesValidation = false;
			this.lblWebSvcUrl.Location = new System.Drawing.Point(8, 8);
			this.lblWebSvcUrl.Name = "lblWebSvcUrl";
			this.lblWebSvcUrl.TabIndex = 0;
			this.lblWebSvcUrl.Text = "Web Service URL:";
			this.lblWebSvcUrl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblQueryText
			// 
			this.lblQueryText.CausesValidation = false;
			this.lblQueryText.Location = new System.Drawing.Point(8, 32);
			this.lblQueryText.Name = "lblQueryText";
			this.lblQueryText.TabIndex = 2;
			this.lblQueryText.Text = "Query Text:";
			this.lblQueryText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnExecute
			// 
			this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExecute.Location = new System.Drawing.Point(384, 8);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.Size = new System.Drawing.Size(88, 23);
			this.btnExecute.TabIndex = 4;
			this.btnExecute.Text = "Execute Query";
			this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
			// 
			// txtResults
			// 
			this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtResults.CausesValidation = false;
			this.txtResults.Location = new System.Drawing.Point(8, 8);
			this.txtResults.Multiline = true;
			this.txtResults.Name = "txtResults";
			this.txtResults.ReadOnly = true;
			this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtResults.Size = new System.Drawing.Size(440, 256);
			this.txtResults.TabIndex = 0;
			this.txtResults.Text = "";
			// 
			// tabsResults
			// 
			this.tabsResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabsResults.CausesValidation = false;
			this.tabsResults.Controls.Add(this.tabResults);
			this.tabsResults.Controls.Add(this.tabRegistrationPacket);
			this.tabsResults.Controls.Add(this.tabRegistrationReply);
			this.tabsResults.Controls.Add(this.tabPortalInfo);
			this.tabsResults.Controls.Add(this.tabQueryPacket);
			this.tabsResults.Location = new System.Drawing.Point(8, 152);
			this.tabsResults.Name = "tabsResults";
			this.tabsResults.SelectedIndex = 0;
			this.tabsResults.Size = new System.Drawing.Size(464, 296);
			this.tabsResults.TabIndex = 8;
			// 
			// tabResults
			// 
			this.tabResults.Controls.Add(this.txtResults);
			this.tabResults.Location = new System.Drawing.Point(4, 22);
			this.tabResults.Name = "tabResults";
			this.tabResults.Size = new System.Drawing.Size(456, 270);
			this.tabResults.TabIndex = 0;
			this.tabResults.Text = "Search Results";
			// 
			// tabRegistrationPacket
			// 
			this.tabRegistrationPacket.Controls.Add(this.txtRegistrationPacket);
			this.tabRegistrationPacket.Location = new System.Drawing.Point(4, 22);
			this.tabRegistrationPacket.Name = "tabRegistrationPacket";
			this.tabRegistrationPacket.Size = new System.Drawing.Size(456, 270);
			this.tabRegistrationPacket.TabIndex = 4;
			this.tabRegistrationPacket.Text = "Registration Packet";
			// 
			// txtRegistrationPacket
			// 
			this.txtRegistrationPacket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtRegistrationPacket.CausesValidation = false;
			this.txtRegistrationPacket.Location = new System.Drawing.Point(8, 7);
			this.txtRegistrationPacket.Multiline = true;
			this.txtRegistrationPacket.Name = "txtRegistrationPacket";
			this.txtRegistrationPacket.ReadOnly = true;
			this.txtRegistrationPacket.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtRegistrationPacket.Size = new System.Drawing.Size(440, 256);
			this.txtRegistrationPacket.TabIndex = 1;
			this.txtRegistrationPacket.Text = "";
			// 
			// tabRegistrationReply
			// 
			this.tabRegistrationReply.Controls.Add(this.txtRegistrationReply);
			this.tabRegistrationReply.Location = new System.Drawing.Point(4, 22);
			this.tabRegistrationReply.Name = "tabRegistrationReply";
			this.tabRegistrationReply.Size = new System.Drawing.Size(456, 270);
			this.tabRegistrationReply.TabIndex = 1;
			this.tabRegistrationReply.Text = "Registration Reply";
			// 
			// txtRegistrationReply
			// 
			this.txtRegistrationReply.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtRegistrationReply.CausesValidation = false;
			this.txtRegistrationReply.Location = new System.Drawing.Point(8, 7);
			this.txtRegistrationReply.Multiline = true;
			this.txtRegistrationReply.Name = "txtRegistrationReply";
			this.txtRegistrationReply.ReadOnly = true;
			this.txtRegistrationReply.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtRegistrationReply.Size = new System.Drawing.Size(440, 256);
			this.txtRegistrationReply.TabIndex = 16;
			this.txtRegistrationReply.Text = "";
			// 
			// tabPortalInfo
			// 
			this.tabPortalInfo.Controls.Add(this.txtPortalSearchInfo);
			this.tabPortalInfo.Location = new System.Drawing.Point(4, 22);
			this.tabPortalInfo.Name = "tabPortalInfo";
			this.tabPortalInfo.Size = new System.Drawing.Size(456, 270);
			this.tabPortalInfo.TabIndex = 2;
			this.tabPortalInfo.Text = "Portal Search Info";
			// 
			// txtPortalSearchInfo
			// 
			this.txtPortalSearchInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPortalSearchInfo.CausesValidation = false;
			this.txtPortalSearchInfo.Location = new System.Drawing.Point(8, 7);
			this.txtPortalSearchInfo.Multiline = true;
			this.txtPortalSearchInfo.Name = "txtPortalSearchInfo";
			this.txtPortalSearchInfo.ReadOnly = true;
			this.txtPortalSearchInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtPortalSearchInfo.Size = new System.Drawing.Size(440, 256);
			this.txtPortalSearchInfo.TabIndex = 16;
			this.txtPortalSearchInfo.Text = "";
			// 
			// tabQueryPacket
			// 
			this.tabQueryPacket.Controls.Add(this.txtQueryPacket);
			this.tabQueryPacket.Location = new System.Drawing.Point(4, 22);
			this.tabQueryPacket.Name = "tabQueryPacket";
			this.tabQueryPacket.Size = new System.Drawing.Size(456, 270);
			this.tabQueryPacket.TabIndex = 3;
			this.tabQueryPacket.Text = "Query Packet";
			// 
			// txtQueryPacket
			// 
			this.txtQueryPacket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtQueryPacket.CausesValidation = false;
			this.txtQueryPacket.Location = new System.Drawing.Point(8, 7);
			this.txtQueryPacket.Multiline = true;
			this.txtQueryPacket.Name = "txtQueryPacket";
			this.txtQueryPacket.ReadOnly = true;
			this.txtQueryPacket.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtQueryPacket.Size = new System.Drawing.Size(440, 256);
			this.txtQueryPacket.TabIndex = 16;
			this.txtQueryPacket.Text = "";
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuFile,
																					 this.mnuOptions,
																					 this.mnuHelp});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mnuFileExit});
			this.menuFile.Text = "&File";
			// 
			// mnuFileExit
			// 
			this.mnuFileExit.Index = 0;
			this.mnuFileExit.Text = "E&xit";
			this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
			// 
			// mnuOptions
			// 
			this.mnuOptions.Index = 1;
			this.mnuOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mmnOptionsContent,
																					   this.mnuOptionsQuerytype,
																					   this.mnuOptionsRecordlimits});
			this.mnuOptions.Text = "&Options";
			// 
			// mmnOptionsContent
			// 
			this.mmnOptionsContent.Index = 0;
			this.mmnOptionsContent.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							  this.mnuOptionsContentDocument,
																							  this.mnuOptionsContentContent,
																							  this.mnuOptionsContentForm});
			this.mmnOptionsContent.Text = "&Content To Return";
			// 
			// mnuOptionsContentDocument
			// 
			this.mnuOptionsContentDocument.Checked = true;
			this.mnuOptionsContentDocument.Index = 0;
			this.mnuOptionsContentDocument.Text = "&Document";
			this.mnuOptionsContentDocument.Click += new System.EventHandler(this.mnuOptionsContent_Item_Click);
			// 
			// mnuOptionsContentContent
			// 
			this.mnuOptionsContentContent.Checked = true;
			this.mnuOptionsContentContent.Index = 1;
			this.mnuOptionsContentContent.Text = "&Content";
			this.mnuOptionsContentContent.Click += new System.EventHandler(this.mnuOptionsContent_Item_Click);
			// 
			// mnuOptionsContentForm
			// 
			this.mnuOptionsContentForm.Checked = true;
			this.mnuOptionsContentForm.Index = 2;
			this.mnuOptionsContentForm.Text = "&Form";
			this.mnuOptionsContentForm.Click += new System.EventHandler(this.mnuOptionsContent_Item_Click);
			// 
			// mnuOptionsQuerytype
			// 
			this.mnuOptionsQuerytype.Index = 1;
			this.mnuOptionsQuerytype.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								this.mnuOptionsQuerytypeKeyword,
																								this.mnuOptionsQuerytypeSqlft});
			this.mnuOptionsQuerytype.Text = "&Query Type";
			// 
			// mnuOptionsQuerytypeKeyword
			// 
			this.mnuOptionsQuerytypeKeyword.Checked = true;
			this.mnuOptionsQuerytypeKeyword.Index = 0;
			this.mnuOptionsQuerytypeKeyword.RadioCheck = true;
			this.mnuOptionsQuerytypeKeyword.Text = "&Keyword";
			this.mnuOptionsQuerytypeKeyword.Click += new System.EventHandler(this.mnuOptionsQuerytype_Item_Click);
			// 
			// mnuOptionsQuerytypeSqlft
			// 
			this.mnuOptionsQuerytypeSqlft.Index = 1;
			this.mnuOptionsQuerytypeSqlft.RadioCheck = true;
			this.mnuOptionsQuerytypeSqlft.Text = "&SQL Full-Text";
			this.mnuOptionsQuerytypeSqlft.Click += new System.EventHandler(this.mnuOptionsQuerytype_Item_Click);
			// 
			// mnuOptionsRecordlimits
			// 
			this.mnuOptionsRecordlimits.Index = 2;
			this.mnuOptionsRecordlimits.Text = "&Record Limits...";
			this.mnuOptionsRecordlimits.Click += new System.EventHandler(this.mnuOptionsRecordlimits_Click);
			// 
			// mnuHelp
			// 
			this.mnuHelp.Index = 2;
			this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuHelpAbout});
			this.mnuHelp.Text = "&Help";
			// 
			// mnuHelpAbout
			// 
			this.mnuHelpAbout.Index = 0;
			this.mnuHelpAbout.Text = "&About SPS Search Test...";
			this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
			// 
			// txtQueryText
			// 
			this.txtQueryText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtQueryText.Encoding = ((System.Text.Encoding)(resources.GetObject("txtQueryText.Encoding")));
			this.txtQueryText.IsIconBarVisible = false;
			this.txtQueryText.Location = new System.Drawing.Point(112, 32);
			this.txtQueryText.Name = "txtQueryText";
			this.txtQueryText.ShowEOLMarkers = true;
			this.txtQueryText.ShowInvalidLines = false;
			this.txtQueryText.ShowSpaces = true;
			this.txtQueryText.ShowTabs = true;
			this.txtQueryText.ShowVRuler = true;
			this.txtQueryText.Size = new System.Drawing.Size(360, 112);
			this.txtQueryText.TabIndex = 9;
			this.txtQueryText.Leave += new System.EventHandler(this.txtQueryText_Leave);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(480, 457);
			this.Controls.Add(this.txtQueryText);
			this.Controls.Add(this.tabsResults);
			this.Controls.Add(this.txtWebSvcUrl);
			this.Controls.Add(this.btnExecute);
			this.Controls.Add(this.lblQueryText);
			this.Controls.Add(this.lblWebSvcUrl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu;
			this.Name = "MainForm";
			this.Text = "SharePoint Portal Server Search Web Service Test";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.tabsResults.ResumeLayout(false);
			this.tabResults.ResumeLayout(false);
			this.tabRegistrationPacket.ResumeLayout(false);
			this.tabRegistrationReply.ResumeLayout(false);
			this.tabPortalInfo.ResumeLayout(false);
			this.tabQueryPacket.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		#region Main

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.Run(new MainForm());
		}

		#endregion


		#region Event Handlers

		/// <summary>
		/// Handles the "Execute Query" button click event.  Gets all the
		/// form options, sets the query, and executes.
		/// </summary>
		/// <param name="sender">The "Execute Query" button</param>
		/// <param name="e">Event args</param>
		private void btnExecute_Click(object sender, System.EventArgs e) {
			// Run the query
			ExecuteQuery();
		}


		/// <summary>
		/// The form load event handler.  Sets defaults for values and controls.
		/// </summary>
		/// <param name="sender">The main form</param>
		/// <param name="e">Event args</param>
		private void MainForm_Load(object sender, System.EventArgs e) {
			// Set the default web service URL
			if(ConfigurationSettings.AppSettings["SearchTest.SPSQueryService.QueryService"] != ""){
				txtWebSvcUrl.Text = ConfigurationSettings.AppSettings["SearchTest.SPSQueryService.QueryService"];
			}
			
			// Get custom highlighting
			ICSharpCode.TextEditor.Document.FileSyntaxModeProvider fsmp = new ICSharpCode.TextEditor.Document.FileSyntaxModeProvider(System.IO.Path.Combine(Application.StartupPath, "syntax"));
			ICSharpCode.TextEditor.Document.HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
			
			// Set the text highlighting
			SetHighlightingStrategy();

			// Update the execute button state
			UpdateExecuteButtonState();
		}


		/// <summary>
		/// File -> Exit <see cref="MenuItem"/> click handler.  Exits the app.
		/// </summary>
		/// <param name="sender">Exit <see cref="MenuItem"/></param>
		/// <param name="e">Event args</param>
		private void mnuFileExit_Click(object sender, System.EventArgs e) {
			Application.Exit();
		}


		/// <summary>
		/// Help -> About <see cref="MenuItem"/> click handler.  Shows the about box.
		/// </summary>
		/// <param name="sender">About <see cref="MenuItem"/></param>
		/// <param name="e">Event args</param>
		private void mnuHelpAbout_Click(object sender, System.EventArgs e) {
			AboutBox abox = new AboutBox();
			abox.ShowDialog(this);
			abox.Dispose();
		}

		
		/// <summary>
		/// Handles the web service URL <see cref="TextBox.Leave"/> event.
		/// </summary>
		/// <param name="sender">The web service URL <see cref="TextBox"/></param>
		/// <param name="e"></param>
		private void txtWebSvcUrl_Leave(object sender, System.EventArgs e) {
			((TextBox)sender).Text = ((TextBox)sender).Text.Trim();
			this.UpdateExecuteButtonState();
		}

		
		/// <summary>
		/// Handles the click event for any of the items in the Options -> Content menu
		/// </summary>
		/// <param name="sender">The <see cref="MenuItem"/> clicked</param>
		/// <param name="e">Event args</param>
		private void mnuOptionsContent_Item_Click(object sender, System.EventArgs e) {
			MenuItem item = (MenuItem)sender;
			
			// Toggle the checkmark on and off
			if(item.Checked){
				item.Checked = false;
			}
			else{
				item.Checked = true;
			}
		}

		
		/// <summary>
		/// Handles the click event for any of the items in the Options -> Query Type menu
		/// </summary>
		/// <param name="sender">The <see cref="MenuItem"/> clicked</param>
		/// <param name="e">Event args</param>
		private void mnuOptionsQuerytype_Item_Click(object sender, System.EventArgs e) {
			// This is radio checkmarks, so uncheck everything, then check the selected item
			foreach(MenuItem item in mnuOptionsQuerytype.MenuItems){
				item.Checked = false;
			}
			((MenuItem)sender).Checked = true;
			
			// Set the syntax highlighting on the query box
			SetHighlightingStrategy();
		}

		
		/// <summary>
		/// Handles the click event for the Options -> Record Limits <see cref="MenuItem"/>
		/// </summary>
		/// <param name="sender">The Options -> Record Limits <see cref="MenuItem"/></param>
		/// <param name="e">Event args</param>
		private void mnuOptionsRecordlimits_Click(object sender, System.EventArgs e) {
			// Open the Record Limits option dialog
			RecordLimits rl = new RecordLimits();
			rl.txtCount.Value = recLimitMaxReturned;
			rl.txtStartAt.Value = recLimitStartAt;
			
			// If the user clicked OK, process the results
			if(rl.ShowDialog(this) == DialogResult.OK){
				try{
					recLimitStartAt = Convert.ToInt32(rl.txtStartAt.Value);
				}
				catch(Exception err){
					Trace.WriteLine("Error setting Record Limit 'Start Record': " + err.Message);
				}
				try{
					recLimitMaxReturned = Convert.ToInt32(rl.txtCount.Value);
				}
				catch(Exception err){
					Trace.WriteLine("Error setting Record Limit 'Max Records Returned': " + err.Message);
				}
			}

			// Dispose of the dialog; don't need it anymore
			rl.Dispose();
		}


		/// <summary>
		/// Handles the <see cref="TextBox.TextChanged"/> event for the Web Service URL <see cref="TextBox"/>.
		/// </summary>
		/// <param name="sender">The Web Service URL <see cref="TextBox"/></param>
		/// <param name="e">Event args</param>
		private void txtWebSvcUrl_TextChanged(object sender, System.EventArgs e) {
			UpdateExecuteButtonState();
		}


		/// <summary>
		/// Handles the <see cref="Control.Leave"/> event for the Query text box.
		/// </summary>
		/// <param name="sender">The <see cref="ICSharpCode.TextEditor.TextEditorControl"/> containing the Query text.</param>
		/// <param name="e">Event args</param>
		private void txtQueryText_Leave(object sender, System.EventArgs e) {
			if(mnuOptionsQuerytypeKeyword.Checked){
				txtQueryText.Text = txtQueryText.Text.Trim();
			}
			UpdateExecuteButtonState();
		}

		
		/// <summary>
		/// Handles the <see cref="ICSharpCode.TextEditor.TextEditorControl.Document.DocumentChanged"/> event for the Query text box.
		/// </summary>
		/// <param name="sender">The <see cref="ICSharpCode.TextEditor.TextEditorControl.Document"/> with the Query text.</param>
		/// <param name="e">Event args</param>
		private void Document_DocumentChanged(object sender, ICSharpCode.TextEditor.Document.DocumentEventArgs e) {
			UpdateExecuteButtonState();
		}

		#endregion


		#region Control Building/Helper Methods

		/// <summary>
		/// Sets the syntax highlighting on the Query box.
		/// </summary>
		private void SetHighlightingStrategy(){
			if(mnuOptionsQuerytypeSqlft.Checked){
				// Set SQL highlighting
				txtQueryText.SetHighlighting("SQL");
			}
			else{
				// Set default (no) highlighting
				txtQueryText.SetHighlighting("Default");
			}
		}


		/// <summary>
		/// Executes the query against the web service and displays the results.
		/// </summary>
		private void ExecuteQuery(){
			// Clear the results boxes
			txtResults.Text = "";
			txtRegistrationPacket.Text = "";
			txtRegistrationReply.Text = "";
			txtPortalSearchInfo.Text = "";
			txtQueryPacket.Text = "";
			this.Invalidate();

			// Set the query service URL
			try{
				searchSvc.QueryService.Url = txtWebSvcUrl.Text;
			}
			catch(Exception err){
				txtResults.Text = "Error setting web service URL: " + err.Message;
				return;
			}

			
			try{
				// Set up the network credentials
				NetworkCredential Credential = CredentialCache.DefaultCredentials.GetCredential(new Uri(searchSvc.QueryService.Url), "NTLM");
				searchSvc.QueryService.Credentials = Credential;
			}
			catch(Exception err){
				txtResults.Text = "Error setting web service credentials: " + err.Message;
				return;
			}

			try{
				// Disable the Execute Query button and set the wait cursor
				btnExecute.Text = "Processing...";
				btnExecute.Enabled = false;
				Cursor.Current = Cursors.WaitCursor;

				// Register the service with the server
				string registrationResult = searchSvc.Registration();

				// Display the registration request
				txtRegistrationPacket.Text = Helper.SerializeToString(searchSvc.RegistrationPacket);

				// Display the registration results
				txtRegistrationReply.Text = registrationResult.Replace("\n", "\r\n");

				// Display the portal search info
				string portalSearchInfo = searchSvc.QueryService.GetPortalSearchInfo();
				txtPortalSearchInfo.Text = portalSearchInfo.Replace("\n", "\r\n");

				// Create the query packet
				// Set the query type
				SearchLogic.QueryType qtype;
				if(mnuOptionsQuerytypeKeyword.Checked){
					qtype = SearchLogic.QueryType.Keyword;
				}
				else{
					qtype = SearchLogic.QueryType.SQLFulltext;
				}

				// Get the content types to retrieve
				byte contentTypes = 0;
				if(mnuOptionsContentDocument.Checked){
					contentTypes |= (byte)SearchLogic.ContentType.Document;
				}
				if(mnuOptionsContentContent.Checked){
					contentTypes |= (byte)SearchLogic.ContentType.Content;
				}
				if(mnuOptionsContentForm.Checked){
					contentTypes |= (byte)SearchLogic.ContentType.Form;
				}
				searchSvc.SetQuery(txtQueryText.Text, qtype, (uint)recLimitStartAt, (uint)recLimitMaxReturned, contentTypes);

				// Display the query packet
				txtQueryPacket.Text = Helper.SerializeToString(searchSvc.QueryPacket);

				// Get and display the result
				string searchResult = searchSvc.ExecuteQuery();
				txtResults.Text = searchResult.Replace("\n", "\r\n");
			}
			catch(Exception err){
				txtResults.Text = "Error setting processing query: " + err.Message;
				return;
			}
			finally{
				// Enable the Execute Query button and reset the cursor
				btnExecute.Text = "Execute Query";
				btnExecute.Enabled = true;
				Cursor.Current = Cursors.Default;
			}
		}


		/// <summary>
		/// Updates the enabled/disabled state of the Execute Query button based on the form controls being valid.
		/// </summary>
		private void UpdateExecuteButtonState(){
			if(txtQueryText.Text.Trim() != "" && txtWebSvcUrl.Text.Trim() != ""){
				btnExecute.Enabled = true;
			}
			else{
				btnExecute.Enabled = false;
			}
		}

		#endregion
	}
}
