using System.Runtime.CompilerServices;

namespace Psswd_generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            numericUpDown1.Value = 8; //výchozí délka hesla 8 znaků
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool lowercase = checkBox1.Checked; //booly pro zaškrtnutí checkboxu
            bool uppercase = checkBox2.Checked;
            bool numbers = checkBox3.Checked;
            bool special = checkBox4.Checked;

            int psswdLength = Convert.ToInt32(numericUpDown1.Value); //převod hodnoty na int z komponenty numericUpDown1

            string password = GeneratePassword(lowercase, uppercase, numbers, special, psswdLength); //volání metody GeneratePassword; podle stavu boolů a int psswdLenght vygeneruje výsledné heslo po zmáčnknutí tlačítka "Generate"

        }

        private void button2_Click(object sender, EventArgs e) //tlačítko Copy to Clipboard
        {
            if (textBox1.Text != "") //pokud je v textboxu vygenerované heslo, po stisknutí tlačítka se zkopíruje do schránky
            {
                Clipboard.SetText(textBox1.Text);
        
                toolTip3.Show("Password copied to clipboard!", button2, 0, -40, 2000);

            }
            else
            {
                toolTip2.Show("No password to copy!", button2, 0, -40, 2000); //v opačném případě se uživateli zobrazí dialogové okno s chybou
            }
        }

        private string GeneratePassword(bool lenght, bool uppercase, bool numbers, bool special, int psswdLength) //metoda pro generování hesla
        {
            string password = "";
            string charSet = "";

            if (lenght)
            {
                charSet += "abcdefghijklmnopqrstuvwxyz"; //pokud je zaškrtnutý checkbox "Lowercase", přidají se do charSetu malá písmena
            }
            if (uppercase)
            {
                charSet += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";//pokud je zaškrtnutý checkbox "Uppercase", přidají se do charSetu velká písmena
            }
            if (numbers)
            {
                charSet += "0123456789"; //pokud je zaškrtnutý checkbox "Numbers", přidají se do charSetu čísla
            }
            if (special)
            {
                charSet += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";//pokud je zaškrtnutý checkbox "Special", přidají se do charSetu speciální znaky
            }

            if (charSet == "")
            {
                MessageBox.Show("No character set selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ""; //pokud není vybrán žádný znak, uživateli se zobrazí dialogové okno s chybou
            }

            Random rnd = new Random(); //vytvoření instance třídy Random
            for (int i = 0; i < psswdLength; i++)//cyklus pro generování hesla
            {
                password += charSet[rnd.Next(0, charSet.Length)];//do proměnné password se přidávají náhodně vybrané znaky z charSetu
            }

            textBox1.Text = password;
            return password;//vrácení vygenerovaného hesla
        }
    }
}
