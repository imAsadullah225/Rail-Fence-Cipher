using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cipher
{
    public partial class RailFenceCipher : Form
    {
        public RailFenceCipher()
        {
            InitializeComponent();
        }

        List<char> encryptedText = new  List<char>();
        List<char> decryptedText = new List<char>();
        
        public void doEncryption(string text)
        {
            char[] charArray = text.ToArray();

            int key = Convert.ToInt32(key_TB.Text);
            int txtLength = charArray.Count();

            char[,] encrypt = new char[key, txtLength];
            int row = 0, check = 0;


            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < txtLength; j++)
                {
                    encrypt[i, j] = 'ʩ'; 
                }
            }


            for (int i = 0; i < txtLength; i++)
            {
                if(check == 0)
                {
                    encrypt[row, i] = charArray[i];
                    row++;

                    if(row == key)
                    {
                        check = 1;
                        row--;
                    }
                }
                else if(check == 1)
                {
                    row--;
                    encrypt[row, i] = charArray[i];

                    if(row == 0)
                    {
                        row = 1;
                        check = 0;
                    }
                }
            }


            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < txtLength; j++)
                {
                    if (encrypt[i, j] != 'ʩ')
                        encryptedText.Add(encrypt[i, j]);
                }
            }
        }

        public void doDecryption(string text)
        {
            char[] charArray = text.ToArray();

            int key = Convert.ToInt32(key_TB.Text);
            int txtLength = charArray.Count();

            char[,] decrypt = new char[key, txtLength];
            int row = 0, check = 0;

            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < txtLength; j++)
                {
                    decrypt[i, j] = 'ʩ';
                }
            }

            for (int i = 0; i < txtLength; i++)
            {
                if (check == 0)
                {
                    decrypt[row, i] = 'ʧ';
                    row++;

                    if (row == key)
                    {
                        check = 1;
                        row--;
                    }
                }
                else if (check == 1)
                {
                    row--;
                    decrypt[row, i] = 'ʧ';

                    if (row == 0)
                    {
                        row = 1;
                        check = 0;
                    }
                }
            }

            int c = 0;
            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < txtLength; j++)
                {
                    if (decrypt[i, j] == 'ʧ')
                    {
                        decrypt[i, j] = charArray[c];
                        c++;
                    }
                }
            }

            row = 0; 
            check = 0;
            for (int i = 0; i < txtLength; i++)
            {
                if (check == 0)
                {
                    decryptedText.Add(decrypt[row, i]);
                    row++;

                    if (row == key)
                    {
                        check = 1;
                        row--;
                    }
                }
                else if (check == 1)
                {
                    row--;
                    decryptedText.Add(decrypt[row, i]);

                    if (row == 0)
                    {
                        row = 1;
                        check = 0;
                    }
                }
            }
        }

        private void encrypt_BTN_Click(object sender, EventArgs e)
        {
            doEncryption(inputText_TB.Text);
            string encrypt = string.Join("", encryptedText);
            encryptedText_TB.Text = encrypt;
            encryptedText.Clear();
        }

        private void decrypt_BTN_Click(object sender, EventArgs e)
        {
            doDecryption(encryptedText_TB.Text);
            string decrypt = string.Join("", decryptedText);
            decryptedText_TB.Text = decrypt;
            decryptedText.Clear();
        }

        private void inputText_TB_TextChanged(object sender, EventArgs e)
        {
            encryptedText.Clear();
            decryptedText.Clear();

            encryptedText_TB.Clear();
            decryptedText_TB.Clear();
        }
    }
}