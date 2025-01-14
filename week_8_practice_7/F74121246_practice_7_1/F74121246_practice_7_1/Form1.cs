using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F74121246_practice_7_1
{
    public partial class ChildForm : Form
    {
        string filePath = "";
        public ChildForm() // 新增檔案
        {
            InitializeComponent();
        }

        public ChildForm(string filePath) // 開啟檔案
        {
            InitializeComponent();
            this.filePath = filePath;
        }

        private void Open_File() // 真 開啟檔案
        {
            string fileExtension = Path.GetExtension(filePath).ToLower();
            string fileContent = File.ReadAllText(filePath);
            //Console.WriteLine(fileContent);
            switch (fileExtension)
            {
                case ".txt":
                    txt.Text = fileContent;
                    break;
                case ".mytxt":
                    string[] lines = fileContent.Split(new[] {'\n'}, 2);
                    string[] config = lines[0].Split(new[] { ',' });
                    if (config.Length == 7) // check
                    {
                        string fontName = config[0];
                        float fontSize = float.Parse(config[1]);
                        FontStyle fontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), config[2]);
                        int A = int.Parse(config[3]);
                        int R = int.Parse(config[4]);
                        int G = int.Parse(config[5]);
                        int B = int.Parse(config[6]);
                        
                        txt.Font = new Font(fontName, fontSize, fontStyle);
                        txt.ForeColor = Color.FromArgb(A, R, G, B);
                        txt.Text = lines[1];
                    }
                    break;
            }
            txt.Select(0, 0);
            this.Focus();
        }
        private void ChildForm_Load(object sender, EventArgs e)
        {
            //Console.WriteLine("Load");
            if (menu != null)
            {
                foreach (ToolStripMenuItem item in menu.Items)
                {
                    item.MergeAction = MergeAction.Insert;
                }
                txt.Height = (this.ClientSize.Height - menu.Height);
            }
            else
            {
                Console.WriteLine("child menu null");
            }

            if (filePath != "") Open_File();
        }

        private void ChildForm_Resize(object sender, EventArgs e) // 更改視窗大小
        {
            txt.Height = (this.ClientSize.Height - menu.Height);
        }

        private void MnuExit_Click(object sender, EventArgs e) // 離開
        {
            this.Close();
        }

        private void MnuTFont_Click(object sender, EventArgs e) // 更改字型
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                txt.Font = fontDialog.Font;
            }
        }

        private void MnuTColor_Click(object sender, EventArgs e) // 更改顏色
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txt.ForeColor = colorDialog.Color;
            }
        }
        string tmpTxt = "";
        private void MnuTCut_Click(object sender, EventArgs e) // 剪下
        {
            tmpTxt = txt.SelectedText;
            txt.SelectedText = "";
        }

        private void MnuTCopy_Click(object sender, EventArgs e) // 複製
        {
            tmpTxt = txt.SelectedText;
        }

        private void MnutPaste_Click(object sender, EventArgs e) // 貼上
        {
            txt.SelectedText = tmpTxt;
        }

        private void MnuTSave_Click(object sender, EventArgs e) // 儲存
        {
            string fileExtension = "";
            if (File.Exists(filePath))
            {
                fileExtension = Path.GetExtension(filePath).ToLower();
                File.Delete(filePath);
                string savetxt = Merge_txt(fileExtension);
                File.WriteAllText(filePath, savetxt);
                MessageBox.Show("存檔成功");
            }
            else
            {
                Save_New();
            }

        }

        private void MnuTSaveNew_Click(object sender, EventArgs e) // 另存新檔
        {
            Save_New();
        }

        private void Save_New() // 真 另存新檔
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "文字檔 (*.txt)|*.txt|自訂文字檔 (*.mytxt)|*.mytxt";
            saveFileDialog.InitialDirectory = Path.GetFullPath("../../saves");
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                string fileExtension = Path.GetExtension(filePath).ToLower();
                string savetxt = Merge_txt(fileExtension);
                File.WriteAllText(filePath, savetxt);
                MessageBox.Show("創建成功");
            }
        }

        private string Merge_txt(string fileExtension) // 拿到儲存文字
        {
            string after = "";
            switch (fileExtension)
            {
                case ".txt":
                    after = txt.Text;
                    break;
                case ".mytxt":
                    after = $"{txt.Font.Name},{txt.Font.Size},{(int)txt.Font.Style},{txt.ForeColor.A},{txt.ForeColor.R},{txt.ForeColor.G},{txt.ForeColor.B}\n{txt.Text}";
                    break;
            }
            return after;
        }

        
    }
}
