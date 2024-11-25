using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using Newtonsoft.Json;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        async void add(object s, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string url = "http://127.1.1.1:4444/rockets";

            try
            {
                var jsonObject = new
                {
                    name = name.Text,
                    enginename = enginename.Text,
                    engines = engines.Text
                };

                string jsonData = JsonConvert.SerializeObject(jsonObject);
                StringContent data = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, data);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
            //MessageBox.Show($"Added {name.Text} with {engines.Text} {enginename.Text} engines");
        }
    }
}
