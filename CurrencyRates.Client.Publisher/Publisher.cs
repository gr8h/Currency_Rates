using CurrencyRates.Model;
using System;
using System.Configuration;
using System.ServiceModel;
using System.Windows.Forms;

namespace CurrencyRates.Client.Publisher
{
    public partial class frmPublisher : Form
    {
        private IPublishing _PubProxy;

        public frmPublisher()
        {
            InitializeComponent();

            _PubProxy = CreateProxy();

            txtPairName.Text = "EURO_USD";
            txtPairData.Text = "1 Euro equals 1.12 US Dollar";
        }

        private IPublishing CreateProxy()
        {
            string endpointAddressInString = ConfigurationManager.AppSettings["EndpointAddress"];
            EndpointAddress endpointAddress = new EndpointAddress(endpointAddressInString);
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            return ChannelFactory<IPublishing>.CreateChannel(netTcpBinding, endpointAddress);
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            try
            {
                string pairName = txtPairName.Text.Trim();
                if (string.IsNullOrEmpty(pairName))
                {
                    MessageBox.Show("Please Enter a Pair Name");
                    return;
                }

                PubSubMessage alertData = PrepareEvent();
                _PubProxy.Publish(alertData);

                MessageBox.Show("Message Sent");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private PubSubMessage PrepareEvent()
        {
            PubSubMessage msg = new PubSubMessage();
            msg.CurrencyPairName = txtPairName.Text;
            msg.CurrencyPairData = txtPairData.Text;
            return msg;
        }
    }
}
