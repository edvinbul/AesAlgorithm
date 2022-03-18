using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aes1
{
    public partial class Form1 : Form
{
        private string name;
        public Form1()
        {
        InitializeComponent();

        }


     

    public static string Encrypt(string encryptStr, string key)

    {
           

            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);

        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(encryptStr);


        RijndaelManaged rDel = new RijndaelManaged();

        rDel.Key = keyArray;

        rDel.Mode = CipherMode.ECB;

        rDel.Padding = PaddingMode.PKCS7;


        ICryptoTransform cTransform = rDel.CreateEncryptor();

        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);


        return Convert.ToBase64String(resultArray, 0, resultArray.Length);

    }

   

    internal static string Decrypt(string decryptStr, string key)

    {

        byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);

        byte[] toEncryptArray = Convert.FromBase64String(decryptStr);


        RijndaelManaged rDel = new RijndaelManaged();

        rDel.Key = keyArray;

        rDel.Mode = CipherMode.ECB;

        rDel.Padding = PaddingMode.PKCS7;


        ICryptoTransform cTransform = rDel.CreateDecryptor();

        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);


        return UTF8Encoding.UTF8.GetString(resultArray);

    }


    private void button1_Click(object sender, EventArgs e)
    {
            if (textBox4.Text == null)
            {
                MessageBox.Show("Write key");
            }
            textBox2.Text = Encrypt(textBox1.Text, textBox4.Text);
    }
        //12345678901234567890123456789012
       
        private void Form1_Load(object sender, EventArgs e)
    {

    }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == null)
            {
                MessageBox.Show("Write key");
            }
            else
            {
                resultBox.Text = Decrypt(textBox2.Text, textBox4.Text);
            }
            
            
        }

        private void Save_button_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text document(*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
                streamWriter.WriteLine(textBox2.Text);
                streamWriter.Close();
            }
            
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text document(*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = File.ReadAllText(openFileDialog1.FileName, Encoding.GetEncoding(1251) );
            }
        }
    }
}