using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LankaStocks.UserControls
{
    public partial class UITransaction : UserControl
    {
        public UITransaction()
        {
            InitializeComponent();

            System.Type.Items.Clear();
            foreach (var item in Enum.GetNames(typeof(Transaction.Types)))
            {
                System.Type.Items.Add(item);
            }

            System.Type.SelectedIndex = 0;
        }




        public Transaction GenerateTransaction()
        {

            if (TransactionID.Text == "") TransactionID.Text = "0";
            if (!uint.TryParse(TransactionID.Text, out uint transID))
            {
                throw new ArgumentException("Value must be a positive integer", "ItemID");
            }

            Transaction tr = new Transaction() { ID = transID };
            ApplyToTransaction(tr);


            return tr;
        }

        public void ApplyToTransaction(Transaction tr)
        {


            if (!decimal.TryParse(Total.Text, out decimal total)) { Core.Log($"Cannot parse money amount {Total.Text}"); return; }
            if (!decimal.TryParse(Paid.Text, out decimal paid)) { Core.Log($"Cannot parse money amount {Paid.Text}"); return; }

            tr.date = DateTime.Now;
            tr.confirmation = Confirm.Text;
            tr.total = total;
            tr.paid = paid;
            tr.Liability = total - paid;
            tr.note = Note.Text;
            tr.User = uiUserParty.GetPerson().ID;
            tr.SecondParty = uiSecondParty.GetPerson().ID;
            tr.type = (Transaction.Types)System.Type.SelectedIndex;

        }

        private void Paid_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(Total.Text, out decimal total))
                if (decimal.TryParse(Paid.Text, out decimal paid))
                {
                    Liability.Text = (total - paid).ToString();
                }
        }
    }
}
