using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watermark {
    public partial class Form1 : Form {
        public Form1()
        {
            InitializeComponent();
            InitializeOpenFileDialog();
        }

        private void InitializeOpenFileDialog()
        {
            openFileDialog1.Filter =
                "Images (*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|" +
                "All files (*.*)|*.*";

            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "选择需要添加水印的图片";
        }
        Image waterOrg = null;
        private void button1_Click( Object sender, EventArgs e )
        {
            var fdlg = new OpenFileDialog();
            fdlg.Title = "选择水印";
            fdlg.Filter =
                "Images (*.PNG)|*.PNG|" +
                "All files (*.*)|*.*";
            var dr = fdlg.ShowDialog();
            if ( dr == DialogResult.OK ) {
                try {
                    waterOrg = Image.FromFile( fdlg.FileName );
                    File.WriteAllText( "./water.txt", fdlg.FileName );
                    pictureBox1.Image = waterOrg;
                } catch ( Exception ex ) {
                    MessageBox.Show( $"打开水印错误，详细信息为\n{ex.Message}\n请重试", "错误" );
                }
            }
        }
        private static Image resizeImage( Image imgToResize, Size size )
        {
            float sourceWidth = imgToResize.Width;
            float sourceHeight = imgToResize.Height;
            int destWidth = (int)( sourceWidth / sourceHeight * size.Height );// (int)( sourceWidth * nPercent );
            int destHeight = size.Height;// (int)( sourceHeight * nPercent );
            Bitmap b = new Bitmap( destWidth, destHeight );
            Graphics g = Graphics.FromImage( b );
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage( imgToResize, 0, 0, destWidth, destHeight );
            g.Dispose();
            return b;
        }

        private void button2_Click( Object sender, EventArgs e )
        {
            if ( waterOrg == null ) {
                MessageBox.Show( "你还没有选择水印，请点击“选择水印”进行选择" );
                return;
            }
            var dr = openFileDialog1.ShowDialog();
            if ( dr == DialogResult.OK ) {
                DoProc();
            }
        }

        private void pictureBox1_Click( Object sender, EventArgs e )
        {

        }

        private void Form1_Load( Object sender, EventArgs e )
        {
            try {
                var path = File.ReadAllText( "./water.txt" );
                waterOrg = Image.FromFile( path );
                pictureBox1.Image = waterOrg;
            } catch ( Exception ex ) {
                MessageBox.Show( $"当前不存在选择的水印或水印文件已经损坏或移动，详细信息：\n{ex.Message}\n请重新选择一个水印", "错误" );
            }
        }

        void OnceProc( ref int i, ref int suc, ref int failed, string file, string folderName )
        {
            try {
                using ( var target = Image.FromFile( file ) ) {
                    var water = resizeImage( waterOrg, new Size( target.Width, target.Height ) ); // your source images - assuming they're the same size
                    if ( water.Width > target.Width ) {
                        water = CropImage( water, new Rectangle( 0, 0, target.Width, target.Height ) );
                    }
                    // var canvas = new Bitmap( target.Width, target.Height, PixelFormat.Format32bppArgb );
                    var graphics = Graphics.FromImage( target );
                    graphics.CompositingMode = CompositingMode.SourceOver; // this is the default, but just to be clear

                    Bitmap bp = (Bitmap)water;
                    bp.SetResolution( target.HorizontalResolution, target.VerticalResolution );
                    graphics.DrawImage( bp, 0, 0 );

                    ImageCodecInfo jgpEncoder = GetEncoder( ImageFormat.Jpeg );

                    System.Drawing.Imaging.Encoder myEncoder =
                        System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters myEncoderParameters = new EncoderParameters( 1 );
                    myEncoderParameters.Param[0] = new EncoderParameter( myEncoder, 40L );
                    target.Save( Path.Combine( folderName, i.ToString() ) + ".jpeg", jgpEncoder, myEncoderParameters );

                    target?.Dispose(); bp?.Dispose(); water?.Dispose();
                    graphics?.Dispose();

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }

                suc++;
            } catch ( Exception ex ) {
                MessageBox.Show( $"添加水印至图片{file}时错误，\n{ex.Message}\n请重试", "错误" );
                failed++;
            }
        }
        private ImageCodecInfo GetEncoder( ImageFormat format )
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach ( ImageCodecInfo codec in codecs ) {
                if ( codec.FormatID == format.Guid ) {
                    return codec;
                }
            }
            return null;
        }
        void DoProc()
        {
            var folderName = "./" + DateTime.Now.Ticks.ToString();
            var dir = Directory.CreateDirectory( folderName );
            Process.Start( dir.FullName );

            int i = 0;
            int failed = 0, suc = 0;

            foreach ( String file in openFileDialog1.FileNames ) {
                i++;
                OnceProc( ref i, ref suc, ref failed, file, folderName );
                label2.Text = $"失败：{failed} 成功：{suc} / 总数：{openFileDialog1.FileNames.Length}";
            }
            MessageBox.Show( $"失败：{failed} 成功：{suc} / 总数：{openFileDialog1.FileNames.Length}" );
        }

        static Bitmap CropImage( Image orgImg, Rectangle cropRect )
        {
            Bitmap target = new Bitmap( cropRect.Width, cropRect.Height );

            using ( Graphics g = Graphics.FromImage( target ) ) {
                g.DrawImage( orgImg, new Rectangle( 0, 0, target.Width, target.Height ),
                                 cropRect,
                                 GraphicsUnit.Pixel );
            }
            return target;
        }

        private void backgroundWorker1_DoWork( Object sender, DoWorkEventArgs e )
        {
            DoProc();
        }
    }
}
