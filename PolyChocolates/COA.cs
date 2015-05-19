using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace PolyChocolates
{
    public partial class COA : Form
    {
        PolyChocolates.InventoryControl.InventoryRow row;

        public COA(PolyChocolates.InventoryControl.InventoryRow row)
        {
            this.row = row;
            InitializeComponent();
            setPhoto(row.coa);
            if (certificate.Image != null)
            {
                panel.Width = Math.Min(certificate.Image.Width + 22, 1200);
                this.Width = Math.Min(panel.Width + 20, 1200);
            }
        }

        public COA(PolyChocolates.PastInventoriesControl.InventoryRow row)
        {
            InitializeComponent();
            Add.Enabled = false;
            browse.Enabled = false;
            setPhoto(row.coa);
            if (certificate.Image != null)
            {
                panel.Width = Math.Min(certificate.Image.Width + 22, 1500);
                this.Width = Math.Min(certificate.Image.Width + 22, 1500);
            }
        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                certificate.Image = Image.FromFile(openFileDialog1.FileName);
                panel.Width = Math.Min(certificate.Image.Width + 22, 1500);
                this.Width = Math.Min(panel.Width + 20, 1500);
                certificate.Width = certificate.Image.Width;
                certificate.Height = certificate.Image.Height;
            } 
        }

        public byte[] convertImage()
        {
            byte[] photo_aray = null;
            if (certificate.Image != null)
            {
                //using MemoryStream:
                MemoryStream ms = new MemoryStream();
                certificate.Image.Save(ms, ImageFormat.Jpeg);
                photo_aray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_aray, 0, photo_aray.Length);
            }
            return photo_aray;
        }

        public void setPhoto(byte[] photo_aray)
        {
            if (photo_aray != null && photo_aray.Length > 0)
            {
                MemoryStream ms = new MemoryStream(photo_aray);
                certificate.Image = Image.FromStream(ms);
                panel.Width = certificate.Image.Width + 22;
                certificate.Width = certificate.Image.Width;
                certificate.Height = certificate.Image.Height;
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            row.coa = convertImage();
            this.Dispose();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (certificate.Image != null)
            {
                SaveFileDialog s = new SaveFileDialog();
                s.FileName = "Image";// Default file name
                s.DefaultExt = ".Jpg";// Default file extension
                s.Filter = "Image (.jpg)|*.jpg"; // Filter files by extension

                // Below are two examples of setting the initial (default) folder - choose one

                // 1. example of setting the default folder to a special folder
                s.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                // setting the RestoreDirectory property to true causes the
                // dialog to restore the current directory before closing
                s.RestoreDirectory = true;
                // Show save file dialog box
                // Process save file dialog box results
                if (s.ShowDialog() == DialogResult.OK)
                {
                    // Save Image
                    string filename = s.FileName;
                    // the using statement causes the FileStream's dispose method to be
                    // called when the object goes out of scope
                    using (System.IO.FileStream fstream = new System.IO.FileStream(filename, System.IO.FileMode.Create))
                    {
                        certificate.Image.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        fstream.Close();
                    }
                }
            }
        }
    }
}
