using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LankaStocks.Setting;
using static LankaStocks.Core;
using LankaStocks.Shared;
using LankaStocks.UIHandle;

namespace LankaStocks.UIForms
{
    public partial class FrmanageData : Form
    {
        public FrmanageData()
        {
            InitializeComponent();
            TabChanged += Tab_Changed;
        }
        public FrmanageData(PersonType personType)
        {
            InitializeComponent();
            TabChanged += Tab_Changed;
            Current = personType;
        }

        private void panel2_SizeChanged(object sender, EventArgs e)
        {
            if (panel2.Width < 35)
            {
                btnConsole.Text = "";
            }
            else
            {
                btnConsole.Text = "Open Console";
            }
        }

        ContextMenuStrip Cm = new ContextMenuStrip();
        private void Tab_Changed(PersonType args)
        {
            switch (args)
            {
                case PersonType.Vendor:
                    groupBox2.Text = "Vendor's";
                    TxtBarcode.Visible = true;
                    label4.Text = "Vendor ID :";
                    DGV.DataSource = RefDGV(Current);
                    break;
                case PersonType.User:
                    groupBox2.Text = "User's";
                    TxtBarcode.Visible = true;
                    label4.Text = "User ID :";
                    DGV.DataSource = RefDGV(Current);
                    break;
                default:
                    groupBox2.Text = "Person's";
                    TxtBarcode.Visible = false;
                    label4.Text = "";
                    DGV.DataSource = RefDGV(Current);
                    break;
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (Core.user.isAdmin)
            {
                DialogResult result = MessageBox.Show("", $"LankaStocks > Remove {Current.ToString()}?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {

                }
            }
            else
            {
                MessageBox.Show($"You Don't Have Permission To Remove {Current.ToString()}'s.", $"LankaStocks > Remove {Current.ToString()}? - Access Denied!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Edit_details_Click(object sender, EventArgs e)
        {
            if (Core.user.isAdmin)
            {
                DialogResult result = MessageBox.Show("", $"LankaStocks > Edit {Current.ToString()}?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    if (DGV.CurrentCell != null && DGV.Rows?[DGV.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString() != null)
                    {
                        Forms.addData = new AddData(PersonType.User,uint.Parse(DGV.Rows?[DGV.CurrentCell.RowIndex]?.Cells?[0].Value?.ToString()));
                        FormHandle form = new FormHandle();
                        Forms.addData.FormClosing += Frm_Closing;
                        switch (Current)
                        {
                            case PersonType.Vendor:
                                form.OpenForm(Fpanel, Forms.addData, FormBorderStyle.Fixed3D, DockStyle.Top);
                                break;
                            case PersonType.User:
                                form.OpenForm(Fpanel, Forms.addData, FormBorderStyle.Fixed3D, DockStyle.Top);
                                break;
                            default:
                                form.OpenForm(Fpanel, Forms.addData, FormBorderStyle.Fixed3D, DockStyle.Top);
                                break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show($"You Don't Have Permission To Edit {Current.ToString()}'s Profiles.", $"LankaStocks > Edit {Current.ToString()}? - Access Denied!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_Closing(object sender, FormClosingEventArgs e)
        {
            DGV.DataSource = RefDGV(Current);
        }

        private object RefDGV(PersonType type)
        {
            switch (type)
            {
                case PersonType.Vendor:
                    var dataV = new List<DGV_Vendor>();
                    foreach (var s in client.ps.People.Vendors)
                    {
                        dataV.Add(new DGV_Vendor { ID = s.Value.ID, Vendor_ID = s.Value.VendorID, Name = s.Value.name, Business_Info = s.Value.BusinessInfo, Contact_Info = s.Value.contactInfo, Details = s.Value.details });
                    }
                    return dataV;
                case PersonType.User:
                    var dataU = new List<DGV_User>();
                    foreach (var s in client.ps.People.Users)
                    {
                        dataU.Add(new DGV_User { ID = s.Value.ID, User_ID = s.Value.ID, Name = s.Value.name, Contact_Info = s.Value.contactInfo, User_Name = s.Value.userName, Pass = s.Value.pass, Details = s.Value.details, Is_Admin = s.Value.isAdmin ? "Yes" : "No" });
                    }
                    return dataU;
                default:
                    var dataP = new List<DGV_Person>();
                    foreach (var s in client.ps.People.OtherPeople)
                    {
                        dataP.Add(new DGV_Person { ID = s.Value.ID, Name = s.Value.name, Contact_Info = s.Value.contactInfo, Details = s.Value.details });
                    }
                    return dataP;
            }
        }

        public PersonType Current = PersonType.User;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Forms.addData = new UIForms.AddData();
            Forms.addData.ShowDialog();
        }

        private void FrmanageData_Load(object sender, EventArgs e)
        {
            Settings.LoadCtrlSettings(this);
            PanelMenu panelMenu = new PanelMenu(panel2, btnhide, 34, panel2.Width);
            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            this.panel2.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            var handler = TabChanged;
            handler?.Invoke(Current);

            Cm.Items.Add("Refresh", Properties.Resources.recurring_appointment_24px, new EventHandler(BtnRef_Click));
            Cm.Items.Add("Edit Details", Properties.Resources.edit_24px, new EventHandler(Edit_details_Click));
            Cm.Items.Add("Remove", Properties.Resources.edit_24px, new EventHandler(Remove_Click));
            Cm.BackColor = Color.LightGray;
            //Forms.addItems = new AddItems();
            //RepeatedFunctions.OpenForm(tabPage1, Forms.addItems, FormBorderStyle.FixedDialog, DockStyle.None);
            //Forms.frmanageItems = new FrmanageItems();
            //RepeatedFunctions.OpenForm(tabPage1, Forms.frmanageItems, FormBorderStyle.Fixed3D, DockStyle.Fill);
        }

        private void btnperson_Click(object sender, EventArgs e)
        {
            Current = PersonType.Person;
            var handler = TabChanged;
            handler?.Invoke(Current);
        }

        private void btnvendor_Click(object sender, EventArgs e)
        {
            Current = PersonType.Vendor;
            var handler = TabChanged;
            handler?.Invoke(Current);
        }

        private void btnuser_Click(object sender, EventArgs e)
        {
            Current = PersonType.User;
            var handler = TabChanged;
            handler?.Invoke(Current);
        }

        public event SelectedTabChanged TabChanged;
        public delegate void SelectedTabChanged(PersonType args);

        private void BtnRef_Click(object sender, EventArgs e)
        {
            DGV.DataSource = RefDGV(Current);
        }

        private void DGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Current == PersonType.Vendor)
            {

            }
        }

        private void DGV_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.ContextMenuStrip != Cm) DGV.ContextMenuStrip = Cm;
        }

        private void DGV_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.ContextMenuStrip != null) DGV.ContextMenuStrip = null;
        }
    }

    struct DGV_Person
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Details { get; set; }
        public string Contact_Info { get; set; }
    }
    struct DGV_Vendor
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public uint Vendor_ID { get; set; }
        public string Details { get; set; }
        public string Contact_Info { get; set; }
        public string Business_Info { get; set; }
    }
    struct DGV_User
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public uint User_ID { get; set; }
        public string Details { get; set; }
        public string Contact_Info { get; set; }
        public string User_Name { get; set; }
        public string Pass { get; set; }
        public string Is_Admin { get; set; }
    }

    public enum PersonType
    {
        Person,
        Vendor,
        User
    }
}
