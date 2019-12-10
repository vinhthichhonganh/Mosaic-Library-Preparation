using System;
using System.Drawing;
using System.Windows.Forms;

namespace MosaicLibraryPreparation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int numberOfImage = Int32.Parse(textBox1.Text);
                int smallImageSize = Int32.Parse(textBox2.Text);
                string inputImagePath = textBox3.Text;
                inputImagePath = inputImagePath.Replace("\\", "/");
                string outputImagePath = textBox4.Text;
                outputImagePath = outputImagePath.Replace("\\", "/");
                for (int i = 1; i <= numberOfImage; i++)
                {
                    Bitmap bmp = new Bitmap(inputImagePath + "/picture (" + i + ").jpg");
                    if (bmp.Width <= bmp.Height)
                    {
                        Bitmap bmpNho = new Bitmap(bmp, smallImageSize, bmp.Height / (bmp.Width / smallImageSize));
                        Bitmap bmp2 = new Bitmap(smallImageSize, smallImageSize);
                        for (int width = 0; width < bmpNho.Width; width++)
                        {
                            for (int height = 0; height < bmpNho.Width; height++)
                            {
                                bmp2.SetPixel(width, height, bmpNho.GetPixel(width, height));
                            }
                        }
                        bmp2.Save(outputImagePath + "/picture (" + i + ").jpg");
                    }
                    else if (bmp.Width > bmp.Height)
                    {
                        Bitmap bmpNho = new Bitmap(bmp, bmp.Width / (bmp.Height / smallImageSize), smallImageSize);
                        Bitmap bmp2 = new Bitmap(smallImageSize, smallImageSize);
                        for (int width = 0; width < bmpNho.Height; width++)
                        {
                            for (int height = 0; height < bmpNho.Height; height++)
                            {
                                bmp2.SetPixel(width, height, bmpNho.GetPixel(width, height));
                            }
                        }
                        bmp2.Save(outputImagePath + "/picture (" + i + ").jpg");
                    }
                }
                MessageBox.Show("Success.");
            }
            catch
            {
                MessageBox.Show("Invalid input. Try again.");
            }
        }
    }
}