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

namespace LankaStocks.UIForms
{
    public partial class FrmSettings : Form
    {
        List<string> DList = new List<string> { "Null" };
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
            var commonSettings = RemoteDBs.Settings.commonSettings.Get;

            commonSettings.MenuColor = uiColourMenu.ColourBox.BackColor;
            commonSettings.BackColor = uiColourBack.ColourBox.BackColor;
            commonSettings.FontColor = uiColourFont.ColourBox.BackColor;
            commonSettings.ItemColor = uiColourItem.ColourBox.BackColor;

            commonSettings.WarnWhen = (float)TxtWarnQty.Value;

            commonSettings.Font = new Font("Comic Sans MS", (float)TxtFontSize.Value);
            var billSetting = RemoteDBs.Settings.billSetting.Get;
            billSetting.H1 = H1.Text;
            billSetting.H2 = H2.Text;
            billSetting.H3 = H3.Text;
            billSetting.E1 = E1.Text;
            billSetting.E2 = E2.Text;
            billSetting.E3 = E3.Text;

            if (CBOAS.SelectedIndex == 0) commonSettings.OpenAtStat = false;
            else if (CBOAS.SelectedIndex == 1) commonSettings.OpenAtStat = true;

            if (CBPreview.SelectedIndex == 0) billSetting.Perview = false;
            else if (CBPreview.SelectedIndex == 1) billSetting.Perview = true;

            if (CBPrintBill.SelectedIndex == 0) billSetting.PrintBill = false;
            else if (CBPrintBill.SelectedIndex == 1) billSetting.PrintBill = true;

            if (CBNoti.SelectedIndex == 0) commonSettings.Show_Notifications = false;
            else if (CBNoti.SelectedIndex == 1) commonSettings.Show_Notifications = true;

            if (CbInterface.SelectedIndex == 0) commonSettings.Interface = MenuInterfaceType.Classic;
            else if (CbInterface.SelectedIndex == 1) commonSettings.Interface = MenuInterfaceType.Modern;


            RemoteDBs.Settings.commonSettings.Set(commonSettings);
            RemoteDBs.Settings.billSetting.Set(billSetting);

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
            load = true;
        }

        private void Ref()
        {
            var commonSettings = RemoteDBs.Settings.commonSettings.Get;
            var billSetting = RemoteDBs.Settings.billSetting.Get;

            if (commonSettings.OpenAtStat) CBOAS.SelectedIndex = 1;
            else CBOAS.SelectedIndex = 0;

            if (commonSettings.Show_Notifications) CBNoti.SelectedIndex = 1;
            else CBNoti.SelectedIndex = 0;

            if (billSetting.Perview) CBPreview.SelectedIndex = 1;
            else CBPreview.SelectedIndex = 0;

            if (billSetting.PrintBill) CBPrintBill.SelectedIndex = 1;
            else CBPrintBill.SelectedIndex = 0;

            if (commonSettings.Interface == MenuInterfaceType.Classic) CbInterface.SelectedIndex = 0;
            else CbInterface.SelectedIndex = 1;

            uiColourMenu.ColourBox.BackColor = commonSettings.MenuColor;
            uiColourBack.ColourBox.BackColor = commonSettings.BackColor;
            uiColourFont.ColourBox.BackColor = commonSettings.FontColor;
            uiColourItem.ColourBox.BackColor = commonSettings.ItemColor;
            TxtFont.Text = commonSettings.Font.Name;
            TxtFontSize.Value = (decimal)commonSettings.Font.Size;
            TxtWarnQty.Value = (decimal)commonSettings.WarnWhen;

            H1.Text = billSetting.H1;
            H2.Text = billSetting.H2;
            H3.Text = billSetting.H3;

            E1.Text = billSetting.E1;
            E2.Text = billSetting.E2;
            E3.Text = billSetting.E3;

            for (int i = 0; i < DList.Count; i++)
            {
                //if (DList[i] == RegSettings.Read("POSbar")?.ToString()) Posbar.SelectedIndex = i;
            }

            RemoteDBs.Settings.commonSettings.Set(commonSettings);
            RemoteDBs.Settings.billSetting.Set(billSetting);
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

    [Serializable]
    public class LocalSettings : DB
    {
        public LocalData Data;

        public override void CreateNewDatabase()
        {
            Data = new LocalData();
        }

        public override (dynamic, MemberType) Resolve(string expr)
        {
            return (null, MemberType.notFound);
        }
    }

    [Serializable]
    public class LocalData
    {
        public string POSBarcode;
    }
}
