using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App10
{
    public partial class MainPage : ContentPage
    {
       
        private string theword;
        private int n;
        private int k;
        string[] arrOfNums = new string[1];
        string[] arrOfNames = new string[1];
        string[] arrOfIds = new string[1];
        string[] arrOfPrs = new string[1];
        List<string> itmNmbers = new List<string>();
        List<string> itmNames = new List<string>();
        List<string> itmIDs = new List<string>();
        List<string> itmIsPresent = new List<string>();

        public MainPage()
        {
            InitializeComponent();
            

        }


        

        private async void loadBtn_Clicked_1(object sender, EventArgs e)
        {

            string[] linesFromFile = new string[4];
            
            
           

            try
            {
                var result = await FilePicker.PickAsync();

                loadBtn.Text = result.FileName;
                var enumLines = File.ReadLines( result.FullPath, Encoding.UTF8);

                foreach (var line in enumLines)
                {
                    n++;
                    
                }
               
               

                
                foreach (var line in enumLines)
                {
                    
                    int i;
                    int j=0;
                    char[] chars = line.ToCharArray();

                    for (i = 0; i < chars.Length; i++)
                    {
                        if (chars[i] != '\t')
                        {
                            theword = theword + chars[i];
                            if (i == chars.Length-1)
                            {
                                linesFromFile[j] = theword;
                                theword = "";
                            }
                        }
                        else
                        {
                            linesFromFile[j] = theword;
                            j++;
                            theword = "";
                        }

                    }

                    arrOfNums[k] = (linesFromFile[0]);
                    arrOfNames[k] = (linesFromFile[1]);
                    arrOfIds[k] = (linesFromFile[2]);
                   
                    arrOfPrs[k] = (linesFromFile[3]);

                    k++;
                    Array.Resize(ref arrOfNums,k+1);
                    Array.Resize(ref arrOfNames,k+1);
                    Array.Resize(ref arrOfIds, k+1);
                    Array.Resize(ref arrOfPrs, k+1);

                }

            }
            catch (Exception)
            {
                loadBtn.Text = "error!!!";
            }






            

            
            for (int i = 0; i < k; i++)
            {
                itmNmbers.Add(arrOfNums[i]);
                itmNames.Add(arrOfNames[i]);
                itmIDs.Add(arrOfIds[i]);

            }

            itemNames.ItemsSource = itmNames;

            countNum.ItemsSource = itmNmbers;
            barCodeNums.ItemsSource = itmIDs;


        
            for (int i = 0; i < k; i++)
            {
                

                if (arrOfPrs[i] == null)
                {
                    itmIsPresent.Add("0");
                }
                else
                {
                    itmIsPresent.Add(arrOfPrs[i]);
                }
            }


            isPresent.ItemsSource = itmIsPresent;

        }
      

        private void barCodeDigits_Completed(object sender, EventArgs e)
        {
            for(int i = 0; i < k; i++)
            {
            
                if (arrOfIds[i] == barCodeDigits.Text)
                {
                    arrOfPrs[i] = "1";
                    isPresent.ItemsSource = arrOfPrs;




                }
                else
                {
                    
                }

            }
        }
    }
}
