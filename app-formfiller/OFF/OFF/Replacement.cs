using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OFF {
    public class Replacement {
        public string Key { get; set; } = "key";
        public string Value { get; set; } = "value";
        private bool matchWildCards = false;
    }

    public class ReplacementsManager {
        public static ReplacementsManager LoadFromFile( string path ) {
            var r = JsonConvert.DeserializeObject<ReplacementsManager>( File.ReadAllText( path ) );
            r.FullFileName = path;
            return r;
        }

        /// <summary>
        /// 替换数据
        /// </summary>
        public List<Replacement> Replacements { get; set; } = new List<Replacement>();
        public string FullFileName { get; set; }
        [JsonIgnore]
        public string DirectoryCur {
            get {
                var fi = new FileInfo( this.FullFileName );
                return fi.DirectoryName;
            }
        }
        [JsonIgnore]
        public string JsonFileName {
            get {
                var fi = new FileInfo( this.FullFileName );
                return fi.Name.Replace(".json","");
            }
        }
        [JsonIgnore]
        public string DirectoryTemplate {
            get {
                return Path.Combine( DirectoryCur, "templates" );
            }
        }
        [JsonIgnore]
        public string DirectoryOuput {
            get {
                var d = Path.Combine( DirectoryCur, "output" );
                if ( ! Directory.Exists( d ) ) {
                    Directory.CreateDirectory( d );
                }
                return d;
            }
        }
        public List<string> TargetReplaceFiles { get; set; } = new List<string>();
        [JsonIgnore]
        public DataGridView ReplacementsView;
        [JsonIgnore]
        public CheckedListBox TargetReplaceFilesView;
        public ReplacementsManager( DataGridView dgvView = null, CheckedListBox clbView = null, string name = "" ) {
            ReplacementsView = dgvView;
            TargetReplaceFilesView = clbView;
            FullFileName = name == "" ? "NewReplacement.json" : name;
        }
        public void Merge( ReplacementsManager rhrm ) {
            Replacements.AddRange( rhrm.Replacements );
            TargetReplaceFiles.AddRange( rhrm.TargetReplaceFiles );
        }
        public void ShowView() {
            ShowTargetReplaceFilesView();
            ShowReplacementsView();
        }
        public void ShowTargetReplaceFilesView() {
            if ( TargetReplaceFilesView == null ) {
                return;
            }
            if ( TargetReplaceFiles.Count == 0 ) {
                return;
            }
            TargetReplaceFilesView.DataSource = null;
            TargetReplaceFilesView.DataSource = TargetReplaceFiles;
            TargetReplaceFilesView.Update();
            TargetReplaceFilesView.Refresh();
        }
        public void ShowReplacementsView() {
            if ( ReplacementsView == null ) {
                return;
            }
            if ( Replacements.Count == 0 ) {
                return;
            }
            ReplacementsView.DataSource = null;
            ReplacementsView.DataSource = Replacements;
            ReplacementsView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ReplacementsView.Update();
            ReplacementsView.Refresh();
        }
        public void AddReplacement( Replacement r ) {
            if ( Replacements.Exists( m => m.Key == r.Key ) ) {
                return;
            }
            Replacements.Add( r );
        }
        public void Save() {
            File.WriteAllText( Path.Combine( FullFileName ), JsonConvert.SerializeObject( this ) );
        }
        public void SaveAs( string fileName ) {
            File.WriteAllText( Path.Combine( fileName ), JsonConvert.SerializeObject( this ) );
        }
        ~ReplacementsManager() {
        }
    }
}
