namespace OS_Lab2
{
        public partial class Form1 : Form
        {
            private  Thread thread1;
            private  Thread thread2;
            private int turn = 0;
            private string message = "";
            private int turn1;
            private bool[] interested = new bool[2] {false,false};

        public Form1()
            {
                InitializeComponent();
               
            }
            public void Stop()
            {
               thread1.Abort();
               thread2.Abort();
            }
            private void Task1()
            {
                while (true)
                {
                    while (turn != 0)
                    {
                        ;
                    }
                    // critical region (квадрат числа)
                    Action action = () => label1.Text = "Возведение в квадрат";
                    Invoke(action);
                    Thread.Sleep(1000);
                    string str = textBox1.Text;
                    int number = Convert.ToInt32(str);
                    turn = 1;
                    // noncritical region
                    action = () => textBox2.Text = Math.Pow(number, 2).ToString();
                    Invoke(action);

                }
            }
            private void Task2()
            {
                while (true)
                {
                    while (turn != 1)
                    {
                        ;
                    }

                    // critical region (звук)
                    Action action = () => label1.Text = "Воспроизведение звука";
                    Invoke(action);
                    Thread.Sleep(1000);
                    string str1 = textBox3.Text;
                    int symbol = Convert.ToInt32(str1);

                    action = () => Console.Beep(4000, 500);


                    turn = 0;

                    // noncritical region                
                    for (int i = 1; i <= symbol; i++)
                    {
                        Invoke(action);
                    }

                }
            }


        private void Task3()
        {
            while (true)
            {
                enter_region(0);
                Action action = () => label1.Text = "Возведение в квадрат1";
                Invoke(action);
                Thread.Sleep(1000);
                string str = textBox1.Text;
                double number = Convert.ToDouble(str);
                leave_region(0);
                // noncritical region
                action = () => textBox2.Text = Math.Pow(number, 2).ToString();
                Invoke(action);
            }

            
        }
        private void Task4()
        {
            while (true)
            {
                enter_region(1);
                Action action = () => label1.Text = "Воспроизведение звука1";
                Invoke(action);
                Thread.Sleep(1000);
                string str1 = textBox3.Text;
                int symbol = Convert.ToInt32(str1);

                action = () => Console.Beep(4000, 500);
                leave_region(1);

                // noncritical region                
                for (int i = 1; i <= symbol; i++)
                {
                    Invoke(action);
                }

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
            thread1 = new Thread(Task1);
            thread2 = new Thread(Task2);
            thread1.Start();
            thread2.Start();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Stop();
        }

        private void enter_region(int process)
        {
            int other;
            other = 1 - process;
            interested[process] = true;
            turn1 = process;
            while (turn1 == process && interested[other] == true) { };
        }

        void leave_region(int process)
        {
            interested[process] = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            thread1 = new Thread(Task3);
            thread2 = new Thread(Task4);
            thread1.Start();
            thread2.Start();
        }
    }
}
