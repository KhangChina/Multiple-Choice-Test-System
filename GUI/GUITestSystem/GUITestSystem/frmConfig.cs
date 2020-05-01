using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Skins;

namespace GUITestSystem
{
    public partial class frmConfig : DevExpress.XtraEditors.XtraForm
    {
        public frmConfig()
        {
            InitializeComponent();
            getSkin();
        }      
        void getSkin()
        {          
            SkinContainerCollection skins = SkinManager.Default.Skins;
            for (int i = 0; i < skins.Count; i++)
            {                        
                cbxSkin.Properties.Items.Add(skins[i].SkinName);
            }
          
        }
        private void frmConfig_Load(object sender, EventArgs e)
        {
            
            
        }
        private void cbxSkin_SelectedValueChanged(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(cbxSkin.Text);
        }
        //private void lookSkin_EditValueChanged(object sender, EventArgs e)
        //{
        //    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(lookSkin.);
        //}
    }
}