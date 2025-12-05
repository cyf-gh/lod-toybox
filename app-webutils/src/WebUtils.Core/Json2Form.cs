using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace WebUtils.Core.Json2Form {
    public class Json2Form {
        class ConfigModel {
            public string InputName { get; set; }
            public string InputType { get; set; }
            public string HeadTailSpliter { get; set; }
        }

        private string filePath = Path.Combine( Environment.CurrentDirectory, "json2form" );

        private ConfigModel config = new ConfigModel();

        const string rawFileSuffix = "*.j2f.raw";
        const string wrapperFileSuffix = "*.j2f.raw.wrapper";

        public Dictionary<string, string> rawFiles { set; get; } = new Dictionary<string, string>();
        public Dictionary<string, string> rawFilesWrapper { set; get; } = new Dictionary<string, string>();

        public Json2Form() {
            try {
                // load raw files
                DirectoryInfo folder = new DirectoryInfo( filePath );
                foreach( FileInfo file in folder.GetFiles( rawFileSuffix ) ) {
                    rawFiles.Add( file.Name.Substring( 0, file.Name.IndexOf( '.' ) ), File.ReadAllText( file.FullName ) );
                }
                foreach( FileInfo file in folder.GetFiles( wrapperFileSuffix ) ) {
                    rawFilesWrapper.Add( file.Name.Substring( 0, file.Name.IndexOf( '.' ) ), File.ReadAllText( file.FullName ) );
                }
                // load config
                config = JsonConvert.DeserializeObject<ConfigModel>( File.ReadAllText( Path.Combine( filePath, "a.j2f.config" ) ) );
            } catch( Exception ) {
                throw;
            }
        }

        public void CreateNewPrefix( string raw, string wrapper, string fileName ) {
            try {
                File.WriteAllText( Path.Combine( filePath, rawFileSuffix.Replace( "*", fileName ) ), raw );
                File.WriteAllText( Path.Combine( filePath, wrapperFileSuffix.Replace( "*", fileName ) ), wrapper );
            } catch {
                throw;
            }
        }


        private string GetInputType( string value ) {
            if( Regex.IsMatch( value, @"^[0-9]*$" ) ) { return "number"; }
            if( Regex.IsMatch( value, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ) ) { return "email"; }

            return "text";
        }

        /// <summary>
        /// 将一个json字符串转化为Form表单字符串
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string JsonToForm( string json, string rawName ) {
            try {
                string targetForm = "";
                Dictionary<string, string> series = JsonConvert.DeserializeObject<Dictionary<string, string>>( json );
                foreach( var single in series ) {
                    targetForm += ( rawFiles[rawName].Replace( config.InputName, single.Key ).Replace( config.InputType, GetInputType( single.Value ) ) + "\n\n" );
                }

                if( rawFilesWrapper.ContainsKey( rawName ) ) {
                    targetForm = rawFilesWrapper[rawName].Replace( config.HeadTailSpliter, targetForm );
                }

                return targetForm;
            } catch {
                throw;
            }
        }
    }
}
