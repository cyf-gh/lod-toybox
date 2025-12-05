using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace Json2Form.App {
    public partial class Main : Form {
        public Main() {
            InitializeComponent();
            CenterToScreen();
        }

        private WebUtils.Core.Json2Form.Json2Form _JsonToForm;

        /// <summary>
        /// poor way
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public bool isJson( String content ) {
            try {
                JObject jsonStr = JObject.Parse( content );
                return true;
            } catch( Exception e ) {
                return false;
            }

        }

        void JsonToForm() {
            try {
                tb_form.Text = _JsonToForm.JsonToForm( tb_json.Text, ( string )lb_all_raws.SelectedValue );
                if( cb_copytoclipboard.Checked ) {
                    Clipboard.SetDataObject( tb_form.Text );
                    MessageBox.Show( "Copied to clipboard!" );
                }
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
        }

        void Reload() {
            _JsonToForm = new WebUtils.Core.Json2Form.Json2Form();
            lb_all_raws.DataSource = new List<string>( _JsonToForm.rawFiles.Keys );
        }

        private void btn_tra_Click( Object sender, EventArgs e ) {
            JsonToForm();
        }

        private void Main_Load( Object sender, EventArgs e ) {
            Reload();
        }

        private void Main_Activated( Object sender, EventArgs e ) {
            Reload();

            string clipboardText = Clipboard.GetText();

            if( isJson( clipboardText ) ) {
                tb_json.Text = clipboardText;

                if( cb_process_when_back.Checked ) {
                    JsonToForm();
                }
            }
        }

        private void btn_create_prefix_Click( Object sender, EventArgs e ) {
            CreateRaw createRaw = new CreateRaw( _JsonToForm );
            createRaw.ShowDialog();
            Reload();
        }
    }
}
