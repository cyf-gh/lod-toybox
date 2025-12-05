using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Json2Form.App {
    public partial class CreateRaw : Form {
        private readonly WebUtils.Core.Json2Form.Json2Form _json2form;

        public CreateRaw( WebUtils.Core.Json2Form.Json2Form json2form ) {
            InitializeComponent(); 
            CenterToScreen();
            _json2form = json2form;
        }

        private void CreateRaw_Load( Object sender, EventArgs e ) {

        }

        private void btn_create_Click( Object sender, EventArgs e ) {
            try {
                _json2form.CreateNewPrefix( tb_raw.Text, tb_wrapper.Text, tb_name.Text );
                this.Close();
            } catch( Exception ex ) {
                MessageBox.Show( ex.Message );
            }
        }
    }
}
