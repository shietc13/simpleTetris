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

        private Rectangle NextObject;
        private Rectangle CurrObject;
        private bool CurrObjFilled = false;
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

            CurrObject = new Rectangle(tmp, 10, 30, 30);
            g = this.CreateGraphics();
            CurrObjFilled = false;

            t.Interval = 10;
            t.Tick += new EventHandler(t_Tick);
            t.Start();

        }

        private void t_Tick(object sender, EventArgs e)
        {
            //Game loop
            g.Clear(this.BackColor);

            DrawGameField();

            CheckCurrObjAndLoadNextOne();

            DrawStaticObjects();

            MoveObjects();

            CheckIfLineIsFull(); //adds score

            UpdateDifficulty();

            CheckIfUpperLimitReached(); // game over 

            //test area
            if (!Multiblockloaded)
            {
                Multiblock test = new Multiblock("T");
                CurrMultiBlock = test;
                DrawMultiBlock(CurrMultiBlock);
                Multiblockloaded = true;
            }else
            {
                MoveMultiBlock(CurrMultiBlock);
            }
                        
            //test.Rotate("left");
            
            //end
        }

        private void MoveMultiBlock(Multiblock multiblock_p)
        {
            for(int i = multiblock_p.BlockList.Count() -1; i >= 0; i--)
            {
                Rectangle tmpVar = multiblock_p.BlockList[i];
                multiblock_p.BlockList.RemoveAt(i);
                tmpVar.Y += speed;
                g.DrawRectangle(new Pen(multiblock_p.col), tmpVar.X, tmpVar.Y, tmpVar.Width, tmpVar.Height); //doesnt move it yet -> TODO 
                multiblock_p.BlockList.Add(tmpVar);
            }
        }

        private void DrawMultiBlock(Multiblock nBlock)
        {
            foreach (Rectangle rEntry in nBlock.BlockList)
            {
                //g.DrawRectangle(new Pen(Color.Orange), rEntry);
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

        private void CheckCurrObjAndLoadNextOne()
        {
            if (CurrObjFilled == false)
            {
                Random r = new Random();
                int tmp = r.Next(leftborder, rightborder);

                CurrObject = new Rectangle(tmp, 10, 30,30);
                g.DrawRectangle(new Pen(Color.White), CurrObject);
                CurrObjFilled = true;
            }
            else
            {
                g.DrawRectangle(new Pen(Color.White), CurrObject);
            }
        }

        private void MoveObjects()
        {            
            if (CurrObjFilled)
            {
                if (CurrObject.Y + speed < lowerborder) //TODO limiter is wrong 
                {
                    CurrObject.Y += speed; //speed
                }
                else
                {
                    StaticObjectList.Add(CurrObject);
                    CurrObject = new Rectangle(0,0,0,0);
                    CurrObjFilled = false;
                }        
                g.DrawRectangle(new Pen(Color.White), CurrObject);
            }
        }


        private void CheckIfUpperLimitReached()
        {
            //throw new NotImplementedException();
            //TODO game over check
        }

        private void CheckIfLineIsFull()
        {
            //throw new NotImplementedException();
            this.Text = "Tetris - Score: " + Score + " , C.Y: " + CurrObject.Y;
            //TODO remove line and add Score
            //TODO remove other static objects all 1 line down
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (CurrObjFilled == false) return;
            
            if (e.KeyCode == Keys.W)
            {
                //rotate

            }
            if (e.KeyCode == Keys.A)
            {
                if (CurrObject.X - 3 > leftborder)
                {
                    CurrObject.X -= 3;
                }
            }
            if (e.KeyCode == Keys.S)
            {
                //go down and check for collission

            }
            if (e.KeyCode == Keys.D)
            {
                if (CurrObject.X + 3 < rightborder - CurrObject.Width)
                {
                    CurrObject.X += 3;
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
