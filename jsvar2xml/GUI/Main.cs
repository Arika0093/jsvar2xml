using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jsvar2xml
{
	public partial class Main : Form
	{
		private Convert_Js2Xml Cv = new Convert_Js2Xml();

		// init
		public Main()
		{
			// initalize
			InitializeComponent();
		}

		// form closing
		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(backgroundWorker1.IsBusy) {
				e.Cancel = MessageBox.Show("Process is running now, Do you close Window?",
					"Warning", MessageBoxButtons.YesNo) == DialogResult.No;
			}
		}

		// text box full select
		private void DebugMsg_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.Control && e.KeyCode == Keys.A)
				DebugMsg.SelectAll();
		}

		// open
		private void FileDialog_Click(object sender, EventArgs e)
		{
			// create instance
			OpenFileDialog ofd = new OpenFileDialog();
			// set value
			ofd.Filter = "Javascript Variable File(*.js)|*.js|All File(*.*)|*.*";
			// show
			if(ofd.ShowDialog() == DialogResult.OK) {
				Cv.ExportPath = "";
				Cv.ImportPath = ofd.FileName;
				ImportPath.Text = Cv.ImportPath;
				OutputPath.Text = Cv.ExportPath;
				Start.Enabled = true;
			}
		}

		// start
		private void Start_Click(object sender, EventArgs e)
		{
			if(backgroundWorker1.IsBusy) {
				return;
			}
			FileDialog.Enabled = false;
			Start.Enabled = false;
			DebugMsg.Text = "Process Started...\r\n";
			backgroundWorker1.RunWorkerAsync();
		}

		// process start
		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			Cv.Convert();
		}

		// process end
		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			DebugMsg.Text += Cv.DebugMessage;
			if(e.Cancelled) {
				DebugMsg.Text += "[Finished] Process Cancelled...\r\n";
			}
			else if(e.Error == null) {
				DebugMsg.Text += "[Finished] Process Success.\r\n";
			}
			FileDialog.Enabled = true;
			Start.Enabled = true;
		}
	}
}
