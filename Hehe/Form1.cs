using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Hehe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int Score = 0;
        private int Level = 0;
        private int speed = 1;

        internal static int leftborder { get; set; }
        internal int rightborder = 0;
        internal int lowerborder = 0;

        private Multiblock NextObject;                
        private List<Rectangle> StaticObjectList = new List<Rectangle>();

        private bool Multiblockloaded = false;
        private Multiblock CurrMultiBlock;

        Timer t = new Timer();
        Graphics g;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Tetris";
            rightborder = (this.Size.Width / 3) * 2;
            lowerborder = (this.Size.Height - 30);

            leftborder = 10;

            Random r = new Random();
            int tmp = r.Next(leftborder, rightborder);
            
            g = this.CreateGraphics();            

            t.Interval = 10;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            //Game loop
            g.Clear(this.BackColor);

            DrawGameField();

            LoadBlockOrMoveCurrentOne();

            DrawStaticObjects();

            CheckIfLineIsFull(); //adds score

            UpdateDifficulty();

            CheckIfUpperLimitReached(); // game over
                                        
        }

        private void MoveMultiBlock(Multiblock multiblock_p)
        {
            for(int i = multiblock_p.BlockList.Count() -1; i >= 0; i--)
            {
                Rectangle tmpVar = multiblock_p.BlockList[i];
                tmpVar.Y += speed;
                if (multiblock_p.RotatingPoint == multiblock_p.BlockList[i])
                {
                    multiblock_p.RotatingPoint = tmpVar;
                }
                multiblock_p.BlockList.RemoveAt(i);
                g.DrawRectangle(new Pen(multiblock_p.Col), tmpVar.X, tmpVar.Y, tmpVar.Width, tmpVar.Height); //doesnt move it yet -> TODO 
                multiblock_p.BlockList.Add(tmpVar);
            }
        }

        private void DrawGameField()
        {
            g.DrawLine(new Pen(Color.White), leftborder, 5, leftborder, lowerborder);
            g.DrawLine(new Pen(Color.White), rightborder, 5, rightborder, lowerborder);
            g.DrawLine(new Pen(Color.White), rightborder, lowerborder, rightborder, lowerborder);
        }

        private void DrawStaticObjects()
        {
            foreach (Rectangle obj in StaticObjectList)
            {
                g.DrawRectangle(new Pen(Color.White), obj);
            }
        }

        private void LoadBlockOrMoveCurrentOne()
        {
            if (Multiblockloaded == false)
            {
                Random r = new Random();
                int tmp = r.Next(leftborder, rightborder-150);

                Random form = new Random();
                List<string> forms = new List<string>
                {
                    "O", "L", "I", "J", "Z", "S", "T"
                }; 

                int pos = form.Next(forms.Count());

                Multiblock newBlock = new Multiblock("I", tmp, 1); //forms[pos]
                CurrMultiBlock = newBlock;
                Multiblockloaded = true;

            }
            else
            {
                MoveMultiBlock(CurrMultiBlock);
            }
        }      

        private void CheckIfUpperLimitReached()
        {
            //TODO game over check
        }

        private void CheckIfLineIsFull()
        {
            //throw new NotImplementedException();
            this.Text = "Tetris - Score: " + Score + " , C.X: " + CurrMultiBlock.GetLeftestX();
            //TODO remove line and add Score
            //TODO remove other static objects all 1 line down
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Multiblockloaded == false) return;
            
            if (e.KeyCode == Keys.W)
            {
                CurrMultiBlock.Rotate();
            }
            if (e.KeyCode == Keys.A)
            {
                if (CurrMultiBlock.GetLeftestX() - 3 > leftborder)
                {
                    CurrMultiBlock.MoveLeft(3);
                }
            }
            if (e.KeyCode == Keys.S)
            {
                //go down and check for collission
                
            }
            if (e.KeyCode == Keys.D)
            {
                if (CurrMultiBlock.GetLeftestX() + 3 < rightborder - CurrMultiBlock.GetWidth())
                {
                    CurrMultiBlock.MoveRight(3);
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (t.Enabled)
                {
                    t.Stop();
                    this.Text = "Paused";
                }
                else
                {
                    t.Start();                    
                }                
            }
        }

        private void UpdateDifficulty()
        {
            if (Score == 0) return; 

            if (Score % 10 == 0)
            {
                Level += 1;
                speed += 1;
            }
        }
    }
}
