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

        internal static int LeftBorder;
        internal int RightBorder = 0;
        internal int LowerBorder = 0;

        private Multiblock NextObject;                
        private List<Rectangle> StaticObjectList = new List<Rectangle>();

        private bool Multiblockloaded = false;
        private Multiblock CurrMultiBlock;

        Timer t = new Timer();
        Graphics g;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Tetris";
            RightBorder = (this.Size.Width / 3) * 2;
            LowerBorder = (this.Size.Height - 50);
            LeftBorder = 10;
            
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
            //TODO add check for lower limit of playfield and if hit -> freeze multiblock, add to StaticObjectList and set multiblockLoaded = false

            for(int i = multiblock_p.BlockList.Count() -1; i >= 0; i--)
            {
                Rectangle tmpVar = multiblock_p.BlockList[i];
                tmpVar.Y += speed;
                if (multiblock_p.RotatingPoint == multiblock_p.BlockList[i])
                {
                    multiblock_p.RotatingPoint = tmpVar;
                }
                multiblock_p.BlockList.RemoveAt(i);
                g.DrawRectangle(new Pen(multiblock_p.Col), tmpVar.X, tmpVar.Y, tmpVar.Width, tmpVar.Height);
                multiblock_p.BlockList.Add(tmpVar);
            }
        }

        private void DrawGameField()
        {
            g.DrawLine(new Pen(Color.White), LeftBorder, 5, LeftBorder, LowerBorder); //left border line
            g.DrawLine(new Pen(Color.White), RightBorder, 5, RightBorder, LowerBorder); //rigth border line
            g.DrawLine(new Pen(Color.White), LeftBorder, LowerBorder, RightBorder, LowerBorder); //lower border line 
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
                int tmp = r.Next(LeftBorder, RightBorder-150);

                Random form = new Random();
                List<string> forms = new List<string>
                {
                    "O", "L", "I", "J", "Z", "S", "T"
                }; 

                int pos = form.Next(forms.Count());

                Multiblock newBlock = new Multiblock("L", tmp, 1); //forms[pos]
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
            this.Text = "Tetris - Score: " + Score + " , C.X: " + CurrMultiBlock.GetLeftestX() + " H: " + this.Size.Height;
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
                if (CurrMultiBlock.GetLeftestX() - 3 > LeftBorder)
                {
                    CurrMultiBlock.MoveLeft(3);
                }
            }
            if (e.KeyCode == Keys.S)
            {
                //todo go down and check for collission -> movemultiblock(currmultiblock);
                
            }
            if (e.KeyCode == Keys.D)
            {
                if (CurrMultiBlock.GetLeftestX() + 3 < RightBorder - CurrMultiBlock.GetWidth())
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

        private void Form1_Resize(object sender, EventArgs e)
        {
            RightBorder = (Size.Width / 3) * 2;
            LowerBorder = Size.Height - 50;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            RightBorder = (Size.Width / 3) * 2;
            LowerBorder = Size.Height - 50;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            RightBorder = (Size.Width / 3) * 2;
            LowerBorder = Size.Height - 50;
        }
    }
}
