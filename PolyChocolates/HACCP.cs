using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyChocolates
{
    public partial class HACCP : Form
    {
        PolyChocolates.ProductEntryControl.ProductRow OldProductRow;
        private PolyChocolates.DynamicProductEntryControl.ProductRow DynamicProductRow;
        private PolyChocolates.EditExistingProductEntryControl.ProductRow EditProductRow;
        RecipeDetails recipeDetails;

        public HACCP(PolyChocolates.DynamicProductEntryControl.ProductRow productRow)
        {
            InitializeComponent();
            DynamicProductRow = productRow;
            setPhoto(DynamicProductRow.HaacpBytes);
            if (haacpImage.Image != null)
            {
                panel.Width = Math.Min(haacpImage.Image.Width + 22, 1200);
                this.Width = Math.Min(panel.Width + 20, 1200);
            }

            browse.Click += new EventHandler(browse_Click);
            Add.Click += new EventHandler(AddDynamic_Click);
            exportButton.Click += new EventHandler(exportButton_Click);
        }

        public HACCP(PolyChocolates.ProductEntryControl.ProductRow productRow)
        {
            InitializeComponent();
            OldProductRow = productRow;
            setPhoto(OldProductRow.haacp);
            if (haacpImage.Image != null)
            {
                panel.Width = Math.Min(haacpImage.Image.Width + 22, 1200);
                this.Width = Math.Min(panel.Width + 20, 1200);
            }

            browse.Click += new EventHandler(browse_Click);
            Add.Click += new EventHandler(Add_Click);
            exportButton.Click += new EventHandler(exportButton_Click);
        }

        public HACCP(PolyChocolates.EditExistingProductEntryControl.ProductRow productRow)
        {
            InitializeComponent();
            EditProductRow = productRow;
            setPhoto(OldProductRow.haacp);
            if (haacpImage.Image != null)
            {
                panel.Width = Math.Min(haacpImage.Image.Width + 22, 1200);
                this.Width = Math.Min(panel.Width + 20, 1200);
            }

            browse.Click += browse_Click;
            Add.Click += AddEdit_Click;
            exportButton.Click += exportButton_Click;
        }

        public HACCP(byte[] image)
        {
            InitializeComponent();
            Add.Enabled = false;
            browse.Enabled = false;
            setPhoto(image);
            if (haacpImage.Image != null)
            {
                panel.Width = Math.Min(haacpImage.Image.Width + 22, 1500);
                this.Width = Math.Min(panel.Width + 20, 1500);
            }
        }

        public HACCP(RecipeDetails recipeDetails)
        {
            InitializeComponent();
            this.recipeDetails = recipeDetails;
            setPhoto(recipeDetails.haccp);
            if (haacpImage.Image != null)
            {
                panel.Width = Math.Min(haacpImage.Image.Width + 22, 1500);
                this.Width = Math.Min(panel.Width + 20, 1500);
            }

            browse.Click += new EventHandler(browse_Click);
            Add.Click += new EventHandler(AddRecipeClick);
            exportButton.Click += new EventHandler(exportButton_Click);
        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                haacpImage.Image = Image.FromFile(openFileDialog1.FileName);
                panel.Width = Math.Min(haacpImage.Image.Width + 22, 1500);
                this.Width = Math.Min(panel.Width + 20, 1500);
                haacpImage.Width = haacpImage.Image.Width;
                haacpImage.Height = haacpImage.Image.Height;
            }
        }

        public byte[] convertImage()
        {
            byte[] photo_aray = null;
            if (haacpImage.Image != null)
            {
                //using MemoryStream:
                MemoryStream ms = new MemoryStream();
                haacpImage.Image.Save(ms, ImageFormat.Jpeg);
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
                haacpImage.Image = Image.FromStream(ms);
                panel.Width = haacpImage.Image.Width + 22;
                haacpImage.Width = haacpImage.Image.Width;
                haacpImage.Height = haacpImage.Image.Height;
            }
        }

        private void AddDynamic_Click(object sender, EventArgs e)
        {
            DynamicProductRow.HaacpBytes = convertImage();
            this.Dispose();
        }

        private void AddEdit_Click(object sender, EventArgs e)
        {
            EditProductRow.HaacpBytes = convertImage();
            Dispose();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            OldProductRow.haacp = convertImage();
            this.Dispose();
        }

        private void AddRecipeClick(object sender, EventArgs e)
        {
            recipeDetails.haccp = convertImage();
            this.Dispose();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (haacpImage.Image != null)
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
                        haacpImage.Image.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        fstream.Close();
                    }
                }
            }
        }
    }
}