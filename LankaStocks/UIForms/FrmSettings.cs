using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LankaStocks.DataBases;
using LankaStocks;
using LankaStocks.Setting;
using static LankaStocks.Core;

namespace LankaStocks.UIForms
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
            uiColourMenu.Browse.Click += MenuBrowse_Click;
            uiColourBack.Browse.Click += BackBrowse_Click;
            uiColourItem.Browse.Click += ItemBrowse_Click;
            uiColourFont.Browse.Click += FontBrowse_Click;

            uiSaveData.Save.Click += Save_Click;
            uiSaveData.RefreshAll.Click += Refresh_Click;
            uiSaveData.Cancel.Click += Cancel_Click;
        }

        bool HasChanges = false;

        private void MenuBrowse_Click(object sender, EventArgs e)
        {
            CD.AllowFullOpen = false;
            CD.AnyColor = true;
            CD.SolidColorOnly = false;
            //  CD.Color = se
            if (CD.ShowDialog() == DialogResult.OK)
            {
                uiColourMenu.ColourBox.BackColor = CD.Color;
                HasChanges = true;
            }
        }
        private void BackBrowse_Click(object sender, EventArgs e)
        {
            CD.AllowFullOpen = false;
            CD.AnyColor = true;
            CD.SolidColorOnly = false;
            //  CD.Color = se
            if (CD.ShowDialog() == DialogResult.OK)
            {
                uiColourBack.ColourBox.BackColor = CD.Color;
                HasChanges = true;
            }
        }
        private void ItemBrowse_Click(object sender, EventArgs e)
        {
            CD.AllowFullOpen = false;
            CD.AnyColor = true;
            CD.SolidColorOnly = false;
            //  CD.Color = se
            if (CD.ShowDialog() == DialogResult.OK)
            {
                uiColourItem.ColourBox.BackColor = CD.Color;
                HasChanges = true;
            }
        }
        private void FontBrowse_Click(object sender, EventArgs e)
        {
            CD.AllowFullOpen = false;
            CD.AnyColor = true;
            CD.SolidColorOnly = false;
            //  CD.Color = se
            if (CD.ShowDialog() == DialogResult.OK)
            {
                uiColourFont.ColourBox.BackColor = CD.Color;
                HasChanges = true;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {

            SaveData();

        }

        private void SaveData()
        {
            RemoteDBs.Settings.commonSettings.GetSet.MenuColor = uiColourMenu.ColourBox.BackColor;
            RemoteDBs.Settings.commonSettings.GetSet.BackColor = uiColourBack.ColourBox.BackColor;
            RemoteDBs.Settings.commonSettings.GetSet.FontColor = uiColourFont.ColourBox.BackColor;
            RemoteDBs.Settings.commonSettings.GetSet.ItemColor = uiColourItem.ColourBox.BackColor;

            RemoteDBs.Settings.commonSettings.GetSet.Font = new Font("Comic Sans MS", (float)TxtFontSize.Value);

            RemoteDBs.Settings.billSetting.GetSet.H1 = H1.Text;
            RemoteDBs.Settings.billSetting.GetSet.H2 = H2.Text;
            RemoteDBs.Settings.billSetting.GetSet.H3 = H3.Text;
            RemoteDBs.Settings.billSetting.GetSet.E1 = E1.Text;
            RemoteDBs.Settings.billSetting.GetSet.E2 = E2.Text;
            RemoteDBs.Settings.billSetting.GetSet.E3 = E3.Text;

            if (CBOAS.SelectedIndex == 0) RemoteDBs.Settings.commonSettings.GetSet.OpenAtStat = false;
            else if (CBOAS.SelectedIndex == 1) RemoteDBs.Settings.commonSettings.GetSet.OpenAtStat = true;

            if (CBPreview.SelectedIndex == 0) RemoteDBs.Settings.billSetting.GetSet.Perview = false;
            else if (CBPreview.SelectedIndex == 1) RemoteDBs.Settings.billSetting.GetSet.Perview = true;

            if (CBPrintBill.SelectedIndex == 0) RemoteDBs.Settings.billSetting.GetSet.PrintBill = false;
            else if (CBPrintBill.SelectedIndex == 1) RemoteDBs.Settings.billSetting.GetSet.PrintBill = true;

            if (CBNoti.SelectedIndex == 0) RemoteDBs.Settings.commonSettings.GetSet.Show_Notifications = false;
            else if (CBNoti.SelectedIndex == 1) RemoteDBs.Settings.commonSettings.GetSet.Show_Notifications = true;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            if (HasChanges)
            {
                DialogResult result = MessageBox.Show("There Are Some Unsaved Changes. Do You Realy Want To Refresh Now?", "LankaStocks - Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK) Ref();
            }
            else Ref();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                Settings.LoadCtrlSettings(ctrl);
            }
            Ref();
        }

        private void Ref()
        {
            if (RemoteDBs.Settings.commonSettings.GetSet.OpenAtStat) CBOAS.SelectedIndex = 1;
            else CBOAS.SelectedIndex = 0;

            if (RemoteDBs.Settings.commonSettings.GetSet.Show_Notifications) CBNoti.SelectedIndex = 1;
            else CBNoti.SelectedIndex = 0;

            if (RemoteDBs.Settings.billSetting.GetSet.Perview) CBPreview.SelectedIndex = 1;
            else CBPreview.SelectedIndex = 0;

            if (RemoteDBs.Settings.billSetting.GetSet.PrintBill) CBPrintBill.SelectedIndex = 1;
            else CBPrintBill.SelectedIndex = 0;

            uiColourMenu.ColourBox.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            uiColourBack.ColourBox.BackColor = RemoteDBs.Settings.commonSettings.Get.BackColor;
            uiColourFont.ColourBox.BackColor = RemoteDBs.Settings.commonSettings.Get.FontColor;
            uiColourItem.ColourBox.BackColor = RemoteDBs.Settings.commonSettings.Get.ItemColor;
            TxtFont.Text = RemoteDBs.Settings.commonSettings.Get.Font.Name;
            TxtFontSize.Value = (decimal)RemoteDBs.Settings.commonSettings.Get.Font.Size;
            TxtWarnQty.Value = (decimal)RemoteDBs.Settings.commonSettings.Get.WarnWhen;

            H1.Text = RemoteDBs.Settings.billSetting.GetSet.H1;
            H2.Text = RemoteDBs.Settings.billSetting.GetSet.H2;
            H3.Text = RemoteDBs.Settings.billSetting.GetSet.H3;

            E1.Text = RemoteDBs.Settings.billSetting.GetSet.E1;
            E2.Text = RemoteDBs.Settings.billSetting.GetSet.E2;
            E3.Text = RemoteDBs.Settings.billSetting.GetSet.E3;
        }
    }
}
