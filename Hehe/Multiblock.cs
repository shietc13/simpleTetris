using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hehe
{
    internal class Multiblock
    {

        internal List<Rectangle> BlockList { get; set; }
        internal string ID { get; set; }
        internal Color Col {get; set;}
        internal int StartX { get; set;}
        internal int StartY { get; set;}
        internal int CWidth { get; set;}
        internal int CHeight { get; set;}

        internal Rectangle RotatingPoint;

        public Multiblock(string id, int startX, int startY)
        {            
            ID = id;
            StartX = startX;
            StartY = startY;
            CWidth = 30;
            CHeight = 30;

            GenerateList();
        }

        private void GenerateList()
        {
            if (String.IsNullOrEmpty(this.ID)) throw new ApplicationException("Errror what");

            switch (this.ID)
            {
                case "O":
                    GenerateO();
                    break;
                case "L":
                    GenerateL();
                    break;
                case "I":
                    GenerateI();
                    break;
                case "J":
                    GenerateJ();
                    break;
                case "Z":
                    GenerateZ();
                    break;
                case "S":
                    GenerateS();
                    break;
                case "T":
                    GenerateT();
                    break;

            }

        }

        private void GenerateT()
        {
            List<Rectangle> blist = new List<Rectangle>();

            Rectangle r1 = new Rectangle(StartX + 40, StartY, CWidth, CHeight);
            Rectangle r2 = new Rectangle(r1.X + CWidth, StartY, CWidth, CHeight);
            Rectangle r3 = new Rectangle(r1.X - CWidth, StartY, CWidth, CHeight);
            Rectangle r4 = new Rectangle(r1.X , r1.Y + CHeight, CWidth, CHeight);

            RotatingPoint = r1;

            blist.Add(r1);
            blist.Add(r2);
            blist.Add(r3);
            blist.Add(r4);

            this.BlockList = blist;
            this.Col = Color.Violet;

            Random rnd = new Random();
            int pos = rnd.Next(1);
            if (pos == 0) { Rotate(); };            
        } 

        private void GenerateS()
        {
            List<Rectangle> blist = new List<Rectangle>();

            Rectangle r1 = new Rectangle(StartX + 40, StartY, CWidth, CHeight);
            Rectangle r2 = new Rectangle(r1.X - CWidth, StartY, CWidth, CHeight);
            Rectangle r3 = new Rectangle(r2.X, r2.Y - CHeight, CWidth, CHeight);
            Rectangle r4 = new Rectangle(r3.X - CWidth, r2.Y - CHeight, CWidth, CHeight);

            RotatingPoint = r3;

            blist.Add(r1);
            blist.Add(r2);
            blist.Add(r3);
            blist.Add(r4);

            this.BlockList = blist;
            this.Col = Color.Green;

            Random rnd = new Random();
            int pos = rnd.Next(1);
            if (pos == 0) { Rotate(); };
        } 

        private void GenerateZ()
        {
            List<Rectangle> blist = new List<Rectangle>();

            Rectangle r1 = new Rectangle(StartX + 40, StartY, CWidth, CHeight);
            Rectangle r2 = new Rectangle(r1.X + CWidth, StartY, CWidth, CHeight);
            Rectangle r3 = new Rectangle(r2.X, r2.Y + CHeight, CWidth, CHeight);
            Rectangle r4 = new Rectangle(r3.X + CWidth, r2.Y + CHeight, CWidth, CHeight);

            RotatingPoint = r3;

            blist.Add(r1);
            blist.Add(r2);
            blist.Add(r3);
            blist.Add(r4);

            this.BlockList = blist;
            this.Col = Color.Red;

            Random rnd = new Random();
            int pos = rnd.Next(1);
            if (pos == 0) { Rotate(); };
        } 

        private void GenerateJ()
        {
            List<Rectangle> blist = new List<Rectangle>();

            Rectangle r1 = new Rectangle(StartX + 40, StartY, CWidth, CHeight);
            Rectangle r2 = new Rectangle(StartX + 40, StartY + CHeight, CWidth, CHeight);
            Rectangle r3 = new Rectangle(StartX + 40, StartY + (CHeight * 2), CWidth, CHeight);
            Rectangle r4 = new Rectangle(r3.X - CWidth, StartY + (CHeight * 2), CWidth, CHeight);

            RotatingPoint = r2;

            blist.Add(r1);
            blist.Add(r2);
            blist.Add(r3);
            blist.Add(r4);

            this.BlockList = blist;
            this.Col = Color.Blue;

            Random rnd = new Random();
            int pos = rnd.Next(1);
            if (pos == 0) { Rotate(); };
        } 

        private void GenerateL()
        {
            List<Rectangle> blist = new List<Rectangle>();

            Rectangle r1 = new Rectangle(StartX + 40, StartY, CWidth, CHeight); 
            Rectangle r2 = new Rectangle(StartX + 40, StartY + CHeight, CWidth, CHeight);
            Rectangle r3 = new Rectangle(StartX + 40, StartY + (CHeight * 2), CWidth, CHeight);
            Rectangle r4 = new Rectangle(r3.X + CWidth, StartY + (CHeight * 2), CWidth, CHeight);

            RotatingPoint = r2;

            blist.Add(r1);
            blist.Add(r2);
            blist.Add(r3);
            blist.Add(r4);

            this.BlockList = blist;
            this.Col = Color.Orange;

            Random rnd = new Random();
            int pos = rnd.Next(1);
            if (pos == 0) { Rotate(); };
        } 

        private void GenerateI() 
        {
            List<Rectangle> blist = new List<Rectangle>();

            Rectangle r1 = new Rectangle(StartX + 40, StartY, CWidth, CHeight); 
            Rectangle r2 = new Rectangle(StartX + 40 + CHeight, StartY, CWidth, CHeight); 
            Rectangle r3 = new Rectangle(StartX + 40 + CHeight * 2, StartY, CWidth, CHeight); 
            Rectangle r4 = new Rectangle(StartX + 40 + CHeight * 3, StartY, CWidth, CHeight); 
            Rectangle r5 = new Rectangle(StartX + 40 + CHeight * 4, StartY, CWidth, CHeight); 

            RotatingPoint = r3;

            blist.Add(r1);
            blist.Add(r2);
            blist.Add(r3);
            blist.Add(r4);
            blist.Add(r5);
            this.BlockList = blist;
            this.Col = Color.DarkGreen;

            Random rnd = new Random();
            int pos = rnd.Next(1);
            if (pos == 0) { Rotate(); };
        }

        private void GenerateO()
        {
            List<Rectangle> bList = new List<Rectangle>();
            Rectangle r1 = new Rectangle(StartX + 40, StartY, CWidth, CHeight); 
            Rectangle r2 = new Rectangle(StartX + 40 + CWidth, StartY, CWidth, CHeight); 
            Rectangle r3 = new Rectangle(StartX + 40, StartY + 30, CWidth, CHeight); 
            Rectangle r4 = new Rectangle(StartX + 40 + CWidth, StartY + 30, CWidth, CHeight);

            RotatingPoint = r2;

            bList.Add(r1);
            bList.Add(r2);
            bList.Add(r3);
            bList.Add(r4);

            this.BlockList = bList;
            this.Col = Color.Yellow;
        }

        internal int GetWidth()
        {
            //return width of the whole multiblock 
            int newWidth = 0;
            int smallestX = 9999;
            int biggestX = 0;
            int oneBlockWidth = 0;

            foreach(Rectangle r in this.BlockList)
            {
                if (r.X < smallestX)
                {
                    smallestX = r.X;
                }
                if (r.X > biggestX)
                {
                    biggestX = r.X;
                }
                oneBlockWidth = r.Width;
            }
            if ((smallestX != 9999) && (biggestX != 0))
            {
                newWidth = (biggestX + oneBlockWidth) - smallestX;
            }
            return newWidth;
        }

        public void Rotate()
        {
            List<Rectangle> newList = new List<Rectangle>();
            int currX = 0;
            int currY = 0;

            switch (this.ID) //TODO
            {
                case "O":
                    //don't rotate the O
                    break;
                case "L":

                    newList.Clear();

                    foreach(Rectangle r in this.BlockList)
                    {
                        //int[][] PosList = new int[4][];
                        currX = 0;
                        currY = 0;

                        Rectangle r2 = r;
                        currX = r2.X;
                        currY = r2.Y;
                        r2.Y = currX;
                        r2.X = currY;
                        newList.Add(r2);

                        //PosList[i][j] = r.X;
                        //PosList[1][0] = r.Y;
                    }
                    BlockList = newList;
                    break;
                case "I":
                    newList.Clear();
                    currX = 9999;
                    currY = 0;                    
                    
                    if (IposIsVertical())
                    {
                        //I is vertical 
                        currX = this.RotatingPoint.X;
                        currY = this.RotatingPoint.Y; // y becomes static position

                        newList.Add(this.RotatingPoint);

                        Rectangle r1 = new Rectangle(currX - CWidth, currY, CWidth, CHeight);
                        Rectangle r2 = new Rectangle(currX - (2 * CWidth), currY, CWidth, CHeight);
                        Rectangle r3 = new Rectangle(currX + CWidth, currY, CWidth, CHeight);
                        Rectangle r4 = new Rectangle(currX + (2 * CWidth), currY, CWidth, CHeight);

                        newList.Add(r1);
                        newList.Add(r2);
                        newList.Add(r3);
                        newList.Add(r4);
                    }
                    else
                    {
                        //I is currently horizontal 
                        currX = this.RotatingPoint.X; //x becomes static position
                        currY = this.RotatingPoint.Y;
                        newList.Add(this.RotatingPoint);

                        Rectangle r1 = new Rectangle(currX, currY + (2*CHeight), CWidth, CHeight);
                        Rectangle r2 = new Rectangle(currX, currY + CHeight, CWidth, CHeight);
                        Rectangle r3 = new Rectangle(currX, currY - CHeight, CWidth, CHeight);
                        Rectangle r4 = new Rectangle(currX, currY - (2* CHeight), CWidth, CHeight);

                        newList.Add(r1);
                        newList.Add(r2);
                        newList.Add(r3);
                        newList.Add(r4);
                    }
                    BlockList.Clear();
                    BlockList = newList;
                    break;
                case "J":
                    newList.Clear();

                    foreach (Rectangle r in this.BlockList)
                    {
                        //int[][] PosList = new int[4][];
                        currX = 0;
                        currY = 0;

                        Rectangle r2 = r;
                        currX = r2.X;
                        currY = r2.Y;
                        r2.Y = currX;
                        r2.X = currY;
                        newList.Add(r2);

                        //PosList[i][j] = r.X;
                        //PosList[1][0] = r.Y;
                    }
                    BlockList = newList;
                    break;
                case "Z":
                    newList.Clear();

                    foreach (Rectangle r in this.BlockList)
                    {
                        //int[][] PosList = new int[4][];
                        currX = 0;
                        currY = 0;

                        Rectangle r2 = r;
                        currX = r2.X;
                        currY = r2.Y;
                        r2.Y = currX;
                        r2.X = currY;
                        newList.Add(r2);

                        //PosList[i][j] = r.X;
                        //PosList[1][0] = r.Y;
                    }
                    BlockList = newList;
                    break;
                case "S":
                    newList.Clear();

                    foreach (Rectangle r in this.BlockList)
                    {
                        //int[][] PosList = new int[4][];
                        currX = 0;
                        currY = 0;

                        Rectangle r2 = r;
                        currX = r2.X;
                        currY = r2.Y;
                        r2.Y = currX;
                        r2.X = currY;
                        newList.Add(r2);

                        //PosList[i][j] = r.X;
                        //PosList[1][0] = r.Y;
                    }
                    BlockList = newList;
                    break;
                case "T":
                    newList.Clear();
                    List<Rectangle> blocksAround = new List<Rectangle>();
                    Rectangle addThis = new Rectangle();
                    List<Rectangle> addList = new List<Rectangle>();

                    foreach (Rectangle r in this.BlockList)
                    {
                        //add all recs to list which aren't fixed point/rotating point
                        if(r != RotatingPoint)
                        {
                            newList.Add(r);
                        }
                        else
                        {
                            //generate recs around rotating point
                            Rectangle rA1 = r;
                            Rectangle rA2 = new Rectangle(rA1.X + CWidth, rA1.Y, CWidth, CHeight);
                            Rectangle rA3 = new Rectangle(rA1.X - CWidth, rA1.Y, CWidth, CHeight);
                            Rectangle rA4 = new Rectangle(rA1.X, rA1.Y + CHeight, CWidth, CHeight);
                            Rectangle rA5 = new Rectangle(rA1.X, rA1.Y - CHeight, CWidth, CHeight);

                            //blocksAround.Add(rA1); dont add rotating point
                            blocksAround.Add(rA2);
                            blocksAround.Add(rA3);
                            blocksAround.Add(rA4);
                            blocksAround.Add(rA5);
                        }                       
                    }
                    //compare blocksAround with newList, if rect not covering rect2 then insert to newList and delete one from newList
                    foreach (Rectangle rs in newList)
                    {
                        for(int i = 0; i < blocksAround.Count; i++)
                        {
                            if (blocksAround[i] == rs)
                            {
                                if(i+1 == blocksAround.Count)
                                {
                                    //do nothing
                                }
                                else
                                {
                                    addList.Add(rs);
                                }
                            }
                            else
                            {
                                addList.Add(blocksAround[i]);
                            }
                        }
                    }

                    BlockList = addList;
                    break;
            }

        //https://gamedev.stackexchange.com/questions/17974/how-to-rotate-blocks-in-tetris
            //General formula for rotating around origin is

            //xNew = x * cos(a) - y * sin(a)
            //yNew = x * sin(a) + y * cos(a)


            //For 90 degrees it becomes


            //xNew = -y
            //yNew = x


            //So, firstly get brick center coordinates relatively to pivot point:


            //x = xBrickCenter - xPivot
            //y = yBrickCenter - yPivot


            //Then rotate them around pivot point:


            //x1 = -y = yPivot - yBrickCenter
            //y1 = x = xBrickCenter - xPivot

            //And then add pivot coordinates to rotated point:


            //newXBrickCenter = xPivot + x1 = xPivot + yPivot - yBrickCenter
            //newYBrickCenter = yPivot + y1 = yPivot - xPivot + xBrickCenter

        }

        private bool IposIsVertical()
        {
            int posX = 9999;
            foreach (Rectangle r in this.BlockList)
            {
                if (posX == 9999)
                {
                    posX = r.X;
                }
                else
                {
                    if (posX == r.X)
                    {
                        //I is vertical
                        return true;
                    }
                    else
                    {
                        //I is horizontal
                        return false;
                    }
                }
            }
            throw new Exception("wat");
            //return false;
        }

        internal int GetLeftestX()
        {
            //return most left X coordinate
            int leftbound = 9999;

            foreach (Rectangle r in this.BlockList)
            {
                if (r.X < leftbound)
                {
                    leftbound = r.X;
                }
            }
            return leftbound;
        }

        internal void MoveLeft(int change)
        {
            if (change == 0) return;
            
            List<Rectangle> newBlockList = new List<Rectangle>();
            
            foreach (Rectangle r in this.BlockList)
            {
                Rectangle r2 = r;
                r2.X -= change;
                newBlockList.Add(r2);
            }
            this.BlockList = newBlockList;
        }
        internal void MoveRight(int change)
        {
            if (change == 0) return;

            List<Rectangle> newBlockList = new List<Rectangle>();

            foreach (Rectangle r in this.BlockList)
            {
                Rectangle r2 = r;
                r2.X += change;
                newBlockList.Add(r2);
            }
            this.BlockList = newBlockList;
        }
        internal void MoveDown(int change)
        {
            if (change == 0) return;

            List<Rectangle> newBlockList = new List<Rectangle>();

            foreach (Rectangle r in this.BlockList)
            {
                Rectangle r2 = r;
                r2.Y += change;
                newBlockList.Add(r2);
            }
            this.BlockList = newBlockList;
        }
    }
}
