using Microsoft.Office.Interop.Word;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.WindowsAPICodePack.Dialogs;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;

namespace OFF {
    /// <summary>
    /// Office帮助类
    /// </summary>
    namespace OfficeHelper {
        public class WordOperator : IDisposable {
            public void Dispose() {
                Close();
            }
            protected Word.Application app;
            protected Word.Document document;
            public WordOperator() {
                app = new Application();
                app.Visible = false;
                app.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
            }
            ~WordOperator() {
                Close();
            }
            public void Close() {
                document?.Close();
                app?.Quit();
                document = null;
                app = null;
            }
            /// <summary>
            /// 如果失败则返回null
            /// </summary>
            /// <param name="path"></param>
            /// <param name="templatePath">当目标文件路径不可用时寻找配置文件目录下是否存在</param>
            /// <returns></returns>
            public Word.Document Open( string path ) {
                var fi = new FileInfo( path );
                if ( fi.Extension.Contains( "doc" ) ) {
                    try {
                        document = app.Documents.Open( path );
                    } catch ( Exception ex ) {
                        Close();
                        return null;
                    }
                }
                return document;
            }
        }

        public class WordReplacementGenrator : WordOperator {
            public string PlainText { get; set; } = "";
            public ReplacementsManager OpenDoc( string path ) {
                if ( Open( path ) == null ) {
                    return null;
                }
                PlainText = document.Content.Text;
                string pattern = @"{{\s*[\w\.]+\s*}}";
                var m = Regex.Matches( PlainText, pattern, RegexOptions.IgnoreCase );

                if ( m.Count != 0 ) {
                    var rm = new ReplacementsManager();
                    foreach ( Match mm in m ) {
                        rm.AddReplacement( new Replacement { Key = mm.Value } );
                    }
                    rm.TargetReplaceFiles.Add( path );
                    return rm;
                } else {
                    return null;
                }
            }
        }

        public class WordReplacer : WordOperator {
            public void Replace( string path, ReplacementsManager rm ) {
                if ( Open( path ) != null ) {
                    try {
                        foreach ( var i in rm.Replacements ) {
                            var chuncks = new Dictionary<string, string>();

                            var chunckSize = 64;
                            // 字符串过大时进行分块操作
                            if ( i.Value.Length > chunckSize ) {
                                var restLength = i.Value.Length;
                                var chunckCount = ( i.Value.Length / chunckSize ) + 1;
                                var mark = "";
                                for ( int j = 0; j < chunckCount; j++ ) {
                                    var chunckKey = i.Key + j.ToString();
                                    chuncks[chunckKey] = i.Value.Substring( j * chunckSize,
                                        restLength < chunckSize ? restLength : chunckSize );
                                    mark += chunckKey;
                                    restLength -= chunckSize;
                                }

                                // 对标签进行分块标签替换
                                Word.Find ff = document.Content.Find;
                                ff.MatchWildcards = false;
                                ff.Text = i.Key;
                                ff.Replacement.Text = mark;
                                ff.Execute( Replace: Word.WdReplace.wdReplaceAll, Forward: true, Wrap: Word.WdFindWrap.wdFindContinue );

                                foreach ( var c in chuncks ) {
                                    Word.Find f = document.Content.Find;
                                    f.MatchWildcards = false;
                                    f.Text = c.Key;
                                    f.Replacement.Text = c.Value;
                                    f.Execute( Replace: Word.WdReplace.wdReplaceAll, Forward: true, Wrap: Word.WdFindWrap.wdFindContinue );
                                }
                                continue;
                            }
                            Word.Find find = document.Content.Find;
                            find.MatchWildcards = false;
                            find.Text = i.Key;
                            find.Replacement.Text = i.Value;
                            find.Execute( Replace: Word.WdReplace.wdReplaceAll, Forward: true, Wrap: Word.WdFindWrap.wdFindContinue );
                        }
                        Close();
                        return;
                    } catch ( Exception ex ) {
                        Close();
                        return;
                    }
                }
            }
        }
    }
}
