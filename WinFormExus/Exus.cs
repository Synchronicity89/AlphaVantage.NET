using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormExus
{
    public partial class Exus : Form
    {
        public Exus()
        {
            InitializeComponent();
        }

        private void Exus_Load(object sender, EventArgs e)
        {
        }

        private void btnFetchData_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:44307/api/symbols/MSFT";
            object product = GetProductAsync(url).GetAwaiter().GetResult();


            // Boolean uploadStatus = false;
            ////DialogResult dr = this.openFileDialog1.ShowDialog();
            ////if (dr == System.Windows.Forms.DialogResult.OK)
            ////{
            ////    foreach (String localFilename in openFileDialog1.FileNames)
            ////    {
            //string url = "https://localhost:44307/api/symbols/MSFT";
            ////string filePath = @"\";
            ////Random rnd = new Random();
            ////string uploadFileName = "Imag" + rnd.Next(9999).ToString();
            //uploadStatus = Fetch(url);//, filePath, localFilename, uploadFileName);
            ////    }
            ////}
            ////if (uploadStatus)
            ////{
            ////    MessageBox.Show("File Uploaded");
            ////}
            ////else
            ////{
            ////    MessageBox.Show("File Not Uploaded");
            ////}
        }


        // filepath = @"Some\Folder\"; 
        // url= "https://localhost:44307/api/symbols/MSFT"; 
        // localFilename = "c:\newProduct.jpg"  
        //uploadFileName="newFileName" 
        bool Fetch(string url)//, string filePath, string localFilename, string uploadFileName)
        {
            Boolean isFileUploaded = false;

            try
            {
                HttpClient httpClient = new HttpClient();

                //var fileStream = File.Open(localFilename, FileMode.Open);
                //var fileInfo = new FileInfo(localFilename);
                //UploadFIle uploadResult = null;
                //bool _fileUploaded = false;

                MultipartFormDataContent content = new MultipartFormDataContent();

                //content.Headers.Add("filePath", filePath);
                //content.Add(new StreamContent(fileStream), "\"file\"", string.Format("\"{0}\"", uploadFileName + fileInfo.Extension)
                //        );

                Task taskUpload = httpClient.PostAsync(url, content).ContinueWith(task =>
                {
                    if (task.Status == TaskStatus.RanToCompletion)
                    {
                        var response = task.Result;

                        if (response.IsSuccessStatusCode)
                        {
                        //    uploadResult = response.Content.ReadAsAsync<UploadFIle>().Result;
                        //    if (uploadResult != null)
                        //        _fileUploaded = true;

                        }

                    }

//                    fileStream.Dispose();
                });

                taskUpload.Wait();
                //if (_fileUploaded)
                //    isFileUploaded = true;

                httpClient.Dispose();

            }
            catch (Exception ex)
            {
                isFileUploaded = false;
            }


            return isFileUploaded;
        }
        static HttpClient client = new HttpClient();

        static async Task<object> GetProductAsync(string path)
        {
            object product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<object>();
            }
            return product;
        }


    }
}
