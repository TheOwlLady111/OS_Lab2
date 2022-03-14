namespace OS_Lab2
{
        public partial class Form1 : Form
        {
            private  Thread thread1;
            private  Thread thread2;
            private int turn = 0;
            private string message = "";
            private int turn1;
            private int[] interested = new int[2] {0,0};
            private bool key1;
            private bool key2;
            private bool key3;
            private bool key4;
            


             public Form1()
            {
                InitializeComponent();
               
            }

       
            public void Stop()
            {
               key1 = false;
               key2 = false;
               key3 = false;
               key4 = false;
            }
            private void Task1()
            {

            while (key1)
            {   string str = textBox1.Text;
                int number = Convert.ToInt32(str);
                while (turn != 0)
                {
                    
                }
                Thread.Sleep(1000);

                Action action = () => label1.Text = "Squaring1 (strict alternation)";
                Invoke(action);
                action = () => textBox4.Text = string.Empty;
                Invoke(action);
               
                action = () => textBox2.Text = Math.Pow(number, 2).ToString();
                Invoke(action);
                turn = 1;
            }
            }
        private void Task2()
        {

            while (key2)
            {
                string str1 = textBox3.Text;
                double symbol = Convert.ToDouble(str1);
                while (turn != 1)
                {
                    
                }
                Thread.Sleep(1000);
                Action action = () => label1.Text = "Squaring2 (strict alternation)";
                Invoke(action);
                action = () => textBox2.Text = string.Empty;
                Invoke(action);
               
                             
                action = () => textBox4.Text = Math.Pow(symbol, 2).ToString();
                Invoke(action);
                turn = 0;
            }
        }


        private void Task3()
        {
           
            while (key3)
            { 
                string str = textBox1.Text;
                double number = Convert.ToDouble(str);
                enter_region(0);
                Thread.Sleep(1000);
                Action action = () => label1.Text = "Squaring1 (peterson)";
                Invoke(action);
                //Thread.Sleep(1000);
                //action = () => textBox4.Text = string.Empty;
                Invoke(action);

               action = () => textBox4.Text = Math.Pow(number, 2).ToString();
                Invoke(action);
                leave_region(0);
            }

            
        }
        private void Task4()
        {
            while (key3)
            {   
                string str1 = textBox3.Text;
                double symbol = Convert.ToDouble(str1);
                enter_region(1);
                Thread.Sleep(1000);
                Action action = () => label1.Text = "Squaring2 (peterson)";
                
                Invoke(action);
                
                //action = () => textBox2.Text = string.Empty;
                Invoke(action);
                action = () => textBox4.Text = Math.Pow(symbol, 2).ToString();
                Invoke(action);
                leave_region(1);
            }
        }
        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        { 
            if (e.KeyChar == 13)
            {
               message = textBox1.Text;
            }
        }

        private void button1_Click_1(Object sender, EventArgs e)
        {
            Stop();
            key1 = true;
            key2 = true;
            thread1 = new Thread(Task1);
            thread2 = new Thread(Task2);
            thread1.Start();
            thread2.Start();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stop();
            key3 = true;
            key4 = true;
            thread1 = new Thread(Task3);
            thread2 = new Thread(Task4);
            thread1.Start();
            thread2.Start();
        }
        private void enter_region(int process)
        {
           
            interested[process] = 1;
            turn1 = 1 - process;
            while (turn1 == process && interested[turn1] == 1) { };
        }

        void leave_region(int process)
        {
            interested[process] = 0;
        }

       
    }
}
