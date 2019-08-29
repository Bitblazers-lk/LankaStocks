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
using System.Management;
using Microsoft.Win32;
using System.IO;
using Newtonsoft.Json;
using LankaStocks.UserControls;

namespace LankaStocks.UIForms
{
    public partial class FrmSettings : Form
    {
        List<string> DList = new List<string> { "Null" };
        public FrmSettings(bool Admin)
        {
            InitializeComponent();
            uiColourMenu.Browse.Click += MenuBrowse_Click;
            uiColourBack.Browse.Click += BackBrowse_Click;
            uiColourItem.Browse.Click += ItemBrowse_Click;
            uiColourFont.Browse.Click += FontBrowse_Click;

            uiSaveData.Save.Click += Save_Click;
            uiSaveData.RefreshAll.Click += Refresh_Click;
            uiSaveData.Cancel.Click += Cancel_Click;

            CbInterface.DataSource = new List<MenuInterfaceType> { MenuInterfaceType.Classic, MenuInterfaceType.Modern };
            cm.MenuItems.Add("Restore Default", new EventHandler(Restore_Click));
            tabControl1.ContextMenu = cm;

            SelectQuery Sq = new SelectQuery("Win32_Keyboard");
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher(Sq);
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();
            DList.Clear();
            foreach (ManagementObject mo in osDetailsCollection)
            {
                DList.Add((string)mo["Description"]);
            }
            Posbar.DataSource = DList;
            if (!Admin)
            {
                foreach (Control a in this.Controls)
                {
                    LockControls(a);
                }
            }
        }

        void LockControls(Control ctrl)
        {
            if (ctrl is TabControl || ctrl is Label || ctrl is TableLayoutPanel || ctrl is Panel||ctrl is UISaveData) ;
            else ctrl.Enabled = false;

            foreach (Control s in ctrl.Controls)
            {
                LockControls(s);
            }
        }

        bool HasChanges = false;
        bool Restart = false;
        bool load = false;

        ContextMenu cm = new ContextMenu();

        private void Restore_Click(object sender, EventArgs e)
        {

        }

        private void MenuBrowse_Click(object sender, EventArgs e)
        {
            CD.AllowFullOpen = true;
            CD.AnyColor = true;
            CD.SolidColorOnly = true;
            //  CD.Color = se
            if (CD.ShowDialog() == DialogResult.OK)
            {
                uiColourMenu.ColourBox.BackColor = CD.Color;
                HasChanges = true;
                Restart = true;
            }
        }
        private void BackBrowse_Click(object sender, EventArgs e)
        {
            CD.AllowFullOpen = true;
            CD.AnyColor = true;
            CD.SolidColorOnly = true;
            //  CD.Color = se
            if (CD.ShowDialog() == DialogResult.OK)
            {
                uiColourBack.ColourBox.BackColor = CD.Color;
                HasChanges = true;
                Restart = true;
            }
        }
        private void ItemBrowse_Click(object sender, EventArgs e)
        {
            CD.AllowFullOpen = true;
            CD.AnyColor = true;
            CD.SolidColorOnly = true;
            //  CD.Color = se
            if (CD.ShowDialog() == DialogResult.OK)
            {
                uiColourItem.ColourBox.BackColor = CD.Color;
                HasChanges = true;
                Restart = true;
            }
        }
        private void FontBrowse_Click(object sender, EventArgs e)
        {
            CD.AllowFullOpen = true;
            CD.AnyColor = true;
            CD.SolidColorOnly = true;
            //  CD.Color = se
            if (CD.ShowDialog() == DialogResult.OK)
            {
                uiColourFont.ColourBox.BackColor = CD.Color;
                HasChanges = true;
                Restart = true;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (HasChanges)
            {
                DialogResult result = MessageBox.Show("Click :\n\n\tOK - To Apply Changes!\n\tCancel - To Discard Changes!", "LankaStocks > Save Settings?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    SaveData();
                    HasChanges = false;
                }
                else
                {
                    Ref();
                }
            }
            else
            {
                MessageBox.Show("There Are No Changes To Save!", "LankaStocks > Save Settings? - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (Restart)
            {
                DialogResult result = MessageBox.Show("Restart LankaStocks To Apply Changes...\n\nClick :\n\n\tOK - To Restart Now!\n\tCancel - To Restart Later!\n*Note : (Some Changes Will Apply)", "LankaStocks > Restart?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    Core.Shutdown();
                    Application.Restart();
                }
            }
        }

        private void SaveData()
        {
            RemoteDBs.Settings.commonSettings.GetSet.MenuColor = uiColourMenu.ColourBox.BackColor;
            RemoteDBs.Settings.commonSettings.GetSet.BackColor = uiColourBack.ColourBox.BackColor;
            RemoteDBs.Settings.commonSettings.GetSet.FontColor = uiColourFont.ColourBox.BackColor;
            RemoteDBs.Settings.commonSettings.GetSet.ItemColor = uiColourItem.ColourBox.BackColor;

            RemoteDBs.Settings.commonSettings.GetSet.WarnWhen = (float)TxtWarnQty.Value;

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

            if (CbInterface.SelectedIndex == 0) RemoteDBs.Settings.commonSettings.GetSet.Interface = MenuInterfaceType.Classic;
            else if (CbInterface.SelectedIndex == 1) RemoteDBs.Settings.commonSettings.GetSet.Interface = MenuInterfaceType.Modern;

            //RegSettings.Write("POSbar", DList[Posbar.SelectedIndex]);

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
            else
            {
                SelectQuery Sq = new SelectQuery("Win32_Keyboard");
                ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher(Sq);
                ManagementObjectCollection osDetailsCollection = objOSDetails.Get();
                DList.Clear();
                foreach (ManagementObject mo in osDetailsCollection)
                {
                    DList.Add((string)mo["Description"]);
                }
                Posbar.DataSource = DList;
                Ref();
            }
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {

            Settings.LoadCtrlSettings(this);

            Ref();
            uiSaveData.Save.Enabled = true;
            uiSaveData.RefreshAll.Enabled = true;
            uiSaveData.Cancel.Enabled = true;
            Posbar.Enabled = true;
            load = true;
        }

        private void Ref()
        {
            if (RemoteDBs.Settings.commonSettings.Get.OpenAtStat) CBOAS.SelectedIndex = 1;
            else CBOAS.SelectedIndex = 0;

            if (RemoteDBs.Settings.commonSettings.Get.Show_Notifications) CBNoti.SelectedIndex = 1;
            else CBNoti.SelectedIndex = 0;

            if (RemoteDBs.Settings.billSetting.Get.Perview) CBPreview.SelectedIndex = 1;
            else CBPreview.SelectedIndex = 0;

            if (RemoteDBs.Settings.billSetting.Get.PrintBill) CBPrintBill.SelectedIndex = 1;
            else CBPrintBill.SelectedIndex = 0;

            if (RemoteDBs.Settings.commonSettings.Get.Interface == MenuInterfaceType.Classic) CbInterface.SelectedIndex = 0;
            else CbInterface.SelectedIndex = 1;

            uiColourMenu.ColourBox.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            uiColourBack.ColourBox.BackColor = RemoteDBs.Settings.commonSettings.Get.BackColor;
            uiColourFont.ColourBox.BackColor = RemoteDBs.Settings.commonSettings.Get.FontColor;
            uiColourItem.ColourBox.BackColor = RemoteDBs.Settings.commonSettings.Get.ItemColor;
            TxtFont.Text = RemoteDBs.Settings.commonSettings.Get.Font.Name;
            TxtFontSize.Value = (decimal)RemoteDBs.Settings.commonSettings.Get.Font.Size;
            TxtWarnQty.Value = (decimal)RemoteDBs.Settings.commonSettings.Get.WarnWhen;

            H1.Text = RemoteDBs.Settings.billSetting.Get.H1;
            H2.Text = RemoteDBs.Settings.billSetting.Get.H2;
            H3.Text = RemoteDBs.Settings.billSetting.Get.H3;

            E1.Text = RemoteDBs.Settings.billSetting.Get.E1;
            E2.Text = RemoteDBs.Settings.billSetting.Get.E2;
            E3.Text = RemoteDBs.Settings.billSetting.Get.E3;

            for (int i = 0; i < DList.Count; i++)
            {
                //if (DList[i] == RegSettings.Read("POSbar")?.ToString()) Posbar.SelectedIndex = i;
            }
        }

        #region Get Changes
        private void CbInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (load)
            {
                Restart = true;
                HasChanges = true;
            }
        }

        private void TxtFontSize_ValueChanged(object sender, EventArgs e)
        {
            if (load)
            {
                Restart = true;
                HasChanges = true;
            }
        }

        private void CBOAS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (load)
                HasChanges = true;
        }

        private void btnFontBrowse_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
        }

        private void H1_TextChanged(object sender, EventArgs e)
        {
            if (load)
                HasChanges = true;
        }

        private void CBPrintBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (load)
                HasChanges = true;
        }

        private void CBPreview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (load)
                HasChanges = true;
        }

        private void TxtWarnQty_ValueChanged(object sender, EventArgs e)
        {
            if (load)
                HasChanges = true;
        }

        private void Poskey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (load)
                HasChanges = true;
        }

        private void Posbar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (load)
                HasChanges = true;
        }
        #endregion
    }
    public enum MenuInterfaceType
    {
        Classic = 0,
        Modern
    }
    public static class LocalSettings
    {
        private static string DBdir = @"DB\\";
        private static string DBpath = @"DB\\DBSettings.json";

        public static void Read(LocalData data)
        {
            X:
            if (!Directory.Exists(DBdir)) Directory.CreateDirectory(DBdir);
            if (!File.Exists(DBpath)) File.Create(DBpath);


            // StreamReader reader = new StreamReader(DBpath);
        }

        public static void Save(LocalData data)
        {
            X:
            if (!Directory.Exists(DBdir)) Directory.CreateDirectory(DBdir);
            if (!File.Exists(DBpath)) File.Create(DBpath);

            // StreamReader reader = new StreamReader(DBpath);
        }
    }
    public class LocalData
    {
        public string POSBarcode;
    }
}
