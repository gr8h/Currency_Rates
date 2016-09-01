using CurrencyRates.Model;
using System;
using System.Configuration;
using System.ServiceModel;
using System.Windows.Forms;

namespace CurrencyRates.Client.Subscriber
{
    public partial class frmSubscriber : Form, IPublishing
    {
        private ISubscription _SubProxy;

        public frmSubscriber()
        {
            InitializeComponent();

            _SubProxy = CreateProxy();

            txtPairName.Text = "EURO_USD";
        }


        private ISubscription CreateProxy()
        {
            string endpointAddressInString = ConfigurationManager.AppSettings["EndpointAddress"];

            NetTcpBinding netTcpbinding = new NetTcpBinding(SecurityMode.None);
            EndpointAddress endpointAddress = new EndpointAddress(endpointAddressInString);
            InstanceContext context = new InstanceContext(this);

            DuplexChannelFactory<ISubscription> channelFactory = new DuplexChannelFactory<ISubscription>(new InstanceContext(this), netTcpbinding, endpointAddress);
            return channelFactory.CreateChannel();
        }

        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                string pairName = txtPairName.Text.Trim();
                if (string.IsNullOrEmpty(pairName))
                {
                    MessageBox.Show("Please Enter a Pair Name");
                    return;
                }
                if (_SubProxy.Subscribe(pairName))
                {
                    btnSubscribe.Visible = false;
                    btnUnSubscribe.Visible = true;
                }
                else
                {
                    MessageBox.Show("Please Try Again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUnSubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                string pairName = txtPairName.Text.Trim();
                if (string.IsNullOrEmpty(pairName))
                {
                    MessageBox.Show("Please Enter a Pair Name");
                    return;
                }
                if (_SubProxy.UnSubscribe(pairName))
                {
                    btnSubscribe.Visible = true;
                    btnUnSubscribe.Visible = false;
                }
                else
                {
                    MessageBox.Show("Please Try Again");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearAstaListView_Click(object sender, EventArgs e)
        {
            lstData.Items.Clear();
        }

        public void Publish(PubSubMessage msg)
        {
            if (msg != null)
            {
                int itemNum = (lstData.Items.Count < 1) ? 0 : lstData.Items.Count;
                lstData.Items.Add(itemNum.ToString());
                lstData.Items[itemNum].SubItems.AddRange(new string[] { msg.CurrencyPairName.ToString(), msg.CurrencyPairData });
            }
        }
    }
}
