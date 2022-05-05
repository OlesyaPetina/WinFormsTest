namespace WinFormsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cards.CreateCardDeck(textBox1.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<string> listDeck = new();
            listDeck = Cards.ReadDeck(textBox2.Text);
            for (int i = 0; i < listDeck.Count; i++)
            {
                listBox2.Items.Add(listDeck[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cards.DeleteDeck(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(Cards.GetDecks());
        }
    }
}