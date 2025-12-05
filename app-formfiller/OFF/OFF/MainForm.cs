using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.WindowsAPICodePack.Dialogs;

using OFF.OfficeHelper;

namespace OFF {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load( object sender, EventArgs e ) {

        }
        ReplacementsManager rpm;
        private void newToolStripMenuItem_Click( object sender, EventArgs e ) {
            rpm = new ReplacementsManager( dgv_Replacements );
            rpm.ShowView();
        }

        private void addToolStripMenuItem_Click( object sender, EventArgs e ) {
            if ( rpm == null ) {
                return;
            }
            rpm.Replacements.Add( new Replacement() );
            rpm.ShowView();
        }

        void SetViewOnRPM() {
            rpm.ReplacementsView = dgv_Replacements;
            rpm.TargetReplaceFilesView = checkedListBox1;
        }

        private void generateFromDocToolStripMenuItem_Click( object sender, EventArgs e ) {
            using ( var g = new WordReplacementGenrator() ) {
                OpenFileDialog( ( fileName ) => {
                    if ( File.Exists( fileName ) ) {
                        var t = g.OpenDoc( fileName );
                        if ( t == null ) {
                            return null;
                        }
                        if ( rpm == null ) {
                            rpm = t;
                        } else {
                            rpm.Merge( t );
                        }
                        SetViewOnRPM();
                        rpm.ShowView();
                    }
                    return null;
                } );
            }
        }

        public delegate object OpenFileDialogDelegate( string fileName );
        object OpenFileDialog( OpenFileDialogDelegate openFileDialogDelegate, bool isFolderPicker = false ) {
            using ( var d = new CommonOpenFileDialog() ) {
                d.IsFolderPicker = isFolderPicker;
                var result = d.ShowDialog();
                if ( result == CommonFileDialogResult.Ok && !string.IsNullOrWhiteSpace( d.FileName ) ) {
                    return openFileDialogDelegate.Invoke( d.FileName );
                }
                return null;
            }
        }

        private void saveToolStripMenuItem_Click( object sender, EventArgs e ) {
            using ( var sfd = new SaveFileDialog() ) {
                sfd.Filter = "JSON File|*.json";
                sfd.Title = "Save Replacement File";
                sfd.ShowDialog();

                if ( sfd.FileName != "" ) {
                    rpm?.SaveAs( sfd.FileName );
                }
            }
        }

        private void menuStrip1_ItemClicked( object sender, ToolStripItemClickedEventArgs e ) {

        }

        private void deleteToolStripMenuItem_Click( object sender, EventArgs e ) {
        }

        private void invokeReplacementsToolStripMenuItem_Click( object sender, EventArgs e ) {
            var ds = new Dictionary<string, string>();
            foreach ( var f in rpm.TargetReplaceFiles ) {
                using ( var drp = new WordReplacer() ) {
                    var fi = new FileInfo( f );
                    var path = "";
                    // 如果不存在，试着找找template目录下是否存在该文件
                    path = !File.Exists( f ) ? Path.Combine( rpm.DirectoryTemplate, fi.Name ) : f;
                    if ( !File.Exists( path ) ) {
                        MessageBox.Show( $"{fi.Name}文件未找到" );
                        continue;
                    } else {
                        ds[f] = path;
                    }
                    var newFile = Path.Combine( rpm.DirectoryOuput, $"{fi.Name} {rpm.JsonFileName} {DateTime.Now.ToString( "MM-dd-yyyy-HH-mm" )} {fi.Extension}" );
                    if ( File.Exists( newFile ) ) {
                        File.Delete( newFile );
                    }
                    File.Copy( path, newFile );
                    drp.Replace( newFile, rpm );
                }
            }
            for ( int i = 0; i < rpm.TargetReplaceFiles.Count; i++ ) {
                var f = rpm.TargetReplaceFiles[i];
                if ( ds.ContainsKey( f ) ) {
                    rpm.TargetReplaceFiles[i] = ds[f];
                }
            }
            rpm.ShowView();
            rpm.Save();
            GC.Collect();
        }

        private void loadToolStripMenuItem_Click( object sender, EventArgs e ) {
            OpenFileDialog( ( fileName ) => {
                rpm = ReplacementsManager.LoadFromFile( fileName );
                SetViewOnRPM();
                rpm.ShowView();
                return null;
            } );
        }

        private void openOutputFolderToolStripMenuItem_Click( object sender, EventArgs e ) {
            Process.Start( rpm?.DirectoryOuput );
        }

        private void openTemplatesFolderToolStripMenuItem_Click( object sender, EventArgs e ) {
            Process.Start( rpm?.DirectoryTemplate );
        }
    }
}
