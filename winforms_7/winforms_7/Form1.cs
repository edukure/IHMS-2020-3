using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace winforms_7
{
    public partial class Form1 : Form
    {

        private delegate void ChangeImageHandler(PictureBox pictureBox, Bitmap imagem);
        private delegate void ChangeTextHandler(Label label, string text);
        public Form1()
        {
            InitializeComponent();
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            StartButton.Enabled = false;
            await MainTask();
            StartButton.Enabled = true;
        }

        public async Task MainTask()
        {
            //2 eventos 7 (rotação) adicionados depois do evento 3 para que LEFT -> RIGHT
            //entre o segundo e terceiro evento 7, foi colocando um STAND_BY para poder diferenciar
            //visto que não é possível realizar 2 ROTATEs seguidos sem outro comando o meio
        
            //para simulação ficar de acordo com o gráfico e a máquina de estados
            //Simulação                    1, 2, 1, 6, 1, 5, 1, 7, 3, 1, 7, 1, 7, 4, 1
            int[] StateChanX = new int[] { 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0 };
            int[] StateChanY = new int[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0 };

            //                          STAND_BY, DOWN, STAND_BY, UP, STAND_BY, CLICK, 
            double[] th = new double[] { 400,     400,   400,     400,    400,   200,
             //STAND_BY ,ROTATE, LEFT, STAND_BY, ROTATE, STAND_BY, ROTATE, STAND_BY, RIGHT, STAND_BY   
                400,        200,   400,    400,    200,   400,      200,    400,      400,    400 };
            int counter = 0;

            string currentDirection = "DOWN";
            string currentEvent = "";

            await Task.Run(() =>
            {
                while (counter < StateChanX.Length)
                {
                    if (StateChanX[counter] == 1 && StateChanY[counter] == 0 & th[counter] >= 400)
                    {
                        RotacionaCursor(currentDirection);
                        currentEvent = currentDirection;

                        if (currentEvent == "DOWN")
                        {
                            VirtualMouse.Move(0, 50);
                        }
                        else if (currentEvent == "LEFT")
                        {
                            VirtualMouse.Move(-50, 0);
                        }
                        else if (currentEvent == "RIGHT")
                        {
                            VirtualMouse.Move(50, 0);
                        }
                    }

                    // UP
                    else if (StateChanY[counter] == 1 & th[counter] >= 400)
                    {
                        VirtualMouse.Move(0, -50);
                        currentDirection = "UP";
                        RotacionaCursor("UP");
                        currentEvent = currentDirection;
                    }

                    // SINGLE_CLICK
                    else if (StateChanX[counter] == 1 && StateChanY[counter] == 0 & th[counter] < 400)
                    {
                        VirtualMouse.LeftClick();
                        currentEvent = "SINGLE_CLICK";
                    }

                    // ROTATE
                    else if (StateChanY[counter] == 1 && th[counter] < 400)
                    {
                        currentDirection = NextDirection(currentDirection);
                        RotacionaCursor(currentDirection);

                        currentEvent = "ROTATE";
                    }

                    //STAND_BY
                    else if (StateChanY[counter] == 0 && StateChanX[counter] == 0 && th[counter] >= 400)
                    {
                        currentEvent = "STAND_BY";
                    }

                    ChangeText(EventLabel, currentEvent);

                    counter = counter + 1;

                    Thread.Sleep(1000);
                }

            });
        }



        #region Event Handlers
        private void ChangeImage(PictureBox pictureBox, Bitmap image)
        {
            if (pictureBox.InvokeRequired)
            {
                var d = new ChangeImageHandler(ChangeImage);
                Invoke(d, new object[] { cursorDirectionImage, image });
            }
            else
            {
                cursorDirectionImage.Image = image;
            }
        }

        private void ChangeText(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                var d = new ChangeTextHandler(ChangeText);
                Invoke(d, new object[] { EventLabel, text });
            }
            else
            {
                EventLabel.Text = $"Event: {text}";
            }
        }

        #endregion


        #region Cursor Direction
        /* sentido anti-horário
           a função não vai de LEFT para UP porque a máquina de estados
           já tem outra maneira de definir o evento UP

         (1) RIGHT -> LEFT-> DOWN -> RIGHT
         (2) UP -> LEFT
        */
        public string NextDirection(string current)
        {
            string next = "";
            if (current == "DOWN")
            {
                next = "RIGHT";
            }
            else if (current == "LEFT")
            {
                next = "DOWN";
            }
            else if (current == "UP")
            {
                next = "LEFT";
            }
            else if (current == "RIGHT")
            {
                next = "LEFT";
            }
            return next;
        }


        public void RotacionaCursor(string direction)
        {
            switch (direction)
            {
                case "DOWN":
                    ChangeImage(cursorDirectionImage, winforms_7.Properties.Resources.DOWN);
                    break;

                case "LEFT":
                    ChangeImage(cursorDirectionImage, winforms_7.Properties.Resources.LEFT);
                    break;

                case "UP":
                    ChangeImage(cursorDirectionImage, winforms_7.Properties.Resources.UP);
                    break;

                case "RIGHT":
                    ChangeImage(cursorDirectionImage, winforms_7.Properties.Resources.RIGHT);
                    break;
            }
        }

        #endregion

    }

    public static class VirtualMouse
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        public static void Move(int xDelta, int yDelta)
        {
            mouse_event(MOUSEEVENTF_MOVE, xDelta, yDelta, 0, 0);
        }
        public static void MoveTo(int x, int y)
        {
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, x, y, 0, 0);
        }
        public static void LeftClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void LeftDown()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void LeftUp()
        {
            mouse_event(MOUSEEVENTF_LEFTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void RightClick()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void RightDown()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void RightUp()
        {
            mouse_event(MOUSEEVENTF_RIGHTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }
    }
}
