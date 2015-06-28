namespace jsvar2xml
{
	partial class Main
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.Start = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.OutputPath = new System.Windows.Forms.TextBox();
			this.ImportPath = new System.Windows.Forms.TextBox();
			this.FileDialog = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.DebugMsg = new System.Windows.Forms.TextBox();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
			this.tableLayoutPanel1.Controls.Add(this.Start, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.OutputPath, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.ImportPath, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.FileDialog, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.DebugMsg, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(709, 437);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// Start
			// 
			this.Start.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Start.Enabled = false;
			this.Start.Location = new System.Drawing.Point(650, 36);
			this.Start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Start.Name = "Start";
			this.Start.Size = new System.Drawing.Size(56, 24);
			this.Start.TabIndex = 5;
			this.Start.Text = "Start";
			this.Start.UseVisualStyleBackColor = true;
			this.Start.Click += new System.EventHandler(this.Start_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(3, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 32);
			this.label2.TabIndex = 4;
			this.label2.Text = "Output:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// OutputPath
			// 
			this.OutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.OutputPath.Location = new System.Drawing.Point(72, 36);
			this.OutputPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.OutputPath.Name = "OutputPath";
			this.OutputPath.ReadOnly = true;
			this.OutputPath.Size = new System.Drawing.Size(572, 25);
			this.OutputPath.TabIndex = 1;
			// 
			// ImportPath
			// 
			this.ImportPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.ImportPath.Location = new System.Drawing.Point(72, 4);
			this.ImportPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ImportPath.Name = "ImportPath";
			this.ImportPath.ReadOnly = true;
			this.ImportPath.Size = new System.Drawing.Size(572, 25);
			this.ImportPath.TabIndex = 0;
			// 
			// FileDialog
			// 
			this.FileDialog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FileDialog.Location = new System.Drawing.Point(650, 4);
			this.FileDialog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.FileDialog.Name = "FileDialog";
			this.FileDialog.Size = new System.Drawing.Size(56, 24);
			this.FileDialog.TabIndex = 2;
			this.FileDialog.Text = "...";
			this.FileDialog.UseVisualStyleBackColor = true;
			this.FileDialog.Click += new System.EventHandler(this.FileDialog_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 32);
			this.label1.TabIndex = 3;
			this.label1.Text = "Import:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// DebugMsg
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.DebugMsg, 3);
			this.DebugMsg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DebugMsg.Location = new System.Drawing.Point(3, 67);
			this.DebugMsg.Multiline = true;
			this.DebugMsg.Name = "DebugMsg";
			this.DebugMsg.ReadOnly = true;
			this.DebugMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.DebugMsg.Size = new System.Drawing.Size(703, 367);
			this.DebugMsg.TabIndex = 6;
			this.DebugMsg.WordWrap = false;
			this.DebugMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DebugMsg_KeyDown);
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(709, 437);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Main";
			this.Text = "jsvar2xml";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button Start;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox OutputPath;
		private System.Windows.Forms.TextBox ImportPath;
		private System.Windows.Forms.Button FileDialog;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.TextBox DebugMsg;
	}
}

