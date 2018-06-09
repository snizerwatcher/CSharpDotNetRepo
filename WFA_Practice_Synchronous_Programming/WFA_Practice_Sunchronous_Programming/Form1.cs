using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.IO;



namespace WFA_Practice_Sunchronous_Programming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_start_Click(object sender, EventArgs e)
        {

            btn_reset.PerformClick();

            string option = combo_selection_list.SelectedIndex.ToString();

            switch (option) 
            { 
                
                case "0":
                    ExecuteMultipleRequests();
                    break;
                case "1":
                    ExecuteMultipleRequests1();
                    break;
                case "2":
                    ExecuteMultipleRequests2();
                    break;
                case "3":
                    ExecuteMultipleRequests3();
                    break;
                case "4":
                    ExecuteMultipleRequestsInParallel();
                    break;
                          
                default:
                    MessageBox.Show("Please Select option form dropdow first.");
                    break;
                                
            }


        }


        public async Task ExecuteMultipleRequests()
        {
            //This function execute in separate thread and UI works in other
            //UI is responding not halt 
            //Result occurs one after another so times required the sum of three web request
            //results occurs simataneously

            HttpClient client = new HttpClient();
            string microsoft= await client.GetStringAsync(txt_bx_adrss_1.Text);
            string msdn = await client.GetStringAsync(txt_bx_adrss_2.Text);
            string blogs = await client.GetStringAsync(txt_bx_adrss_3.Text);


            txt_bx_adrss_11.Text = microsoft;
            txt_bx_adrss_12.Text = msdn;
            txt_bx_adrss_13.Text = blogs;
                        
        }

        public async Task ExecuteMultipleRequests1()
        {
            //This function execute in separate thread and UI works in other
            //UI is responding not halt 
            //Result occurs one after another so times required the sum of three web request
            //Variation of first method result comes one by one

            HttpClient client = new HttpClient();
            string microsoft = await client.GetStringAsync(txt_bx_adrss_1.Text);
            txt_bx_adrss_11.Text = microsoft;
            string msdn = await client.GetStringAsync(txt_bx_adrss_2.Text);
            txt_bx_adrss_12.Text = msdn;
            string blogs = await client.GetStringAsync(txt_bx_adrss_3.Text);
            txt_bx_adrss_13.Text = blogs;

                                    

        }

        public void ExecuteMultipleRequests2()
        {
            //This function execute in same thread in which UI works
            //UI is not responding and halt
            //Result occurs one after another so times required the sum of three web request
           
             WebRequest webRequest = WebRequest.Create(txt_bx_adrss_1.Text);
             WebResponse webResponse = webRequest.GetResponse();
             StreamReader reader = new StreamReader(webResponse.GetResponseStream());
             string microsoft = reader.ReadToEnd();
             webResponse.Close();


             webRequest = WebRequest.Create(txt_bx_adrss_2.Text);
             webResponse = webRequest.GetResponse();
             reader = new StreamReader(webResponse.GetResponseStream());
             string msdn = reader.ReadToEnd();
             webResponse.Close();

             webRequest = WebRequest.Create(txt_bx_adrss_3.Text);
             webResponse = webRequest.GetResponse();
             reader = new StreamReader(webResponse.GetResponseStream());      
             string blogs = reader.ReadToEnd();
             webResponse.Close();

            txt_bx_adrss_11.Text = microsoft;
            txt_bx_adrss_12.Text = msdn;
            txt_bx_adrss_13.Text = blogs;

        }


        public void ExecuteMultipleRequests3()
        {
            //This function execute in same thread in which UI works
            //UI is not responding and halt
            //Result occurs one after another so times required the sum of three web request
            //Results occurs one by one but it seems to occurs Simantaneosly because ui is halt

            WebRequest webRequest = WebRequest.Create(txt_bx_adrss_1.Text);
            WebResponse webResponse = webRequest.GetResponse();
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string microsoft = reader.ReadToEnd();
            txt_bx_adrss_11.Text = microsoft;
            webResponse.Close();


            webRequest = WebRequest.Create(txt_bx_adrss_2.Text);
            webResponse = webRequest.GetResponse();
            reader = new StreamReader(webResponse.GetResponseStream());
            string msdn = reader.ReadToEnd();
            txt_bx_adrss_12.Text = msdn;
            webResponse.Close();

            webRequest = WebRequest.Create(txt_bx_adrss_3.Text);
            webResponse = webRequest.GetResponse();
            reader = new StreamReader(webResponse.GetResponseStream());
            string blogs = reader.ReadToEnd();
            txt_bx_adrss_13.Text = blogs;
            webResponse.Close();
                       
         }

        public async Task ExecuteMultipleRequestsInParallel()
        {
            //Excute three request parallel
            HttpClient client = new HttpClient();
            Task<string> microsoft = client.GetStringAsync(txt_bx_adrss_1.Text);
            Task<string> msdn =  client.GetStringAsync(txt_bx_adrss_1.Text);
            Task<string> blogs = client.GetStringAsync(txt_bx_adrss_1.Text);
            await Task.WhenAll(microsoft, msdn, blogs);

            txt_bx_adrss_11.Text = await microsoft;
            txt_bx_adrss_12.Text = await msdn;
            txt_bx_adrss_13.Text = await blogs;
           
        }
        
    
        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_bx_adrss_11.ResetText();
            txt_bx_adrss_12.ResetText();
            txt_bx_adrss_13.ResetText();
        }
   

    }
}
