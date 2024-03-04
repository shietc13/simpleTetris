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
        internal Color col {get; set;}

        public Multiblock(string id)
        {            
            ID = id;

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

            Rectangle r1 = new Rectangle(Form1.leftborder + 40, 10, 30, 30);
            Rectangle r2 = new Rectangle(r1.X + r1.Width, 10, 30, 30);
            Rectangle r3 = new Rectangle(r1.X - r1.Width, 10, 30, 30);
            Rectangle r4 = new Rectangle(r1.X , r1.Y + r1.Height, 30, 30);

            blist.Add(r1);
            blist.Add(r2);
            blist.Add(r3);
            blist.Add(r4);

            this.BlockList = blist;
            this.col = Color.Violet;
        }

        private void GenerateS()
        {
            List<Rectangle> blist = new List<Rectangle>();

            Rectangle r1 = new Rectangle(Form1.leftborder + 40, 10, 30, 30);
            Rectangle r2 = new Rectangle(r1.X - r1.Width, 10, 30, 30);
            Rectangle r3 = new Rectangle(r2.X, r2.Y - r2.Height, 30, 30);
            Rectangle r4 = new Rectangle(r3.X - r3.Width, r2.Y - r2.Height, 30, 30);

            blist.Add(r1);
            blist.Add(r2);
            blist.Add(r3);
            blist.Add(r4);

            this.BlockList = blist;
            this.col = Color.Green;
        }

        private void GenerateZ()
        {
            List<Rectangle> blist = new List<Rectangle>();

            Rectangle r1 = new Rectangle(Form1.leftborder + 40, 10, 30, 30);
            Rectangle r2 = new Rectangle(r1.X + r1.Width, 10, 30, 30);
            Rectangle r3 = new Rectangle(r2.X, r2.Y + r2.Height, 30, 30);
            Rectangle r4 = new Rectangle(r3.X + r3.Width, r2.Y + r2.Height, 30, 30);

            blist.Add(r1);
            blist.Add(r2);
            blist.Add(r3);
            blist.Add(r4);

            this.BlockList = blist;
            this.col = Color.Red;
        }

        private void GenerateJ()
        {
            List<Rectangle> blist = new List<Rectangle>();

            Rectangle r1 = new Rectangle(Form1.leftborder + 40, 10, 30, 30);
            Rectangle r2 = new Rectangle(Form1.leftborder + 40, 10 + r1.Height, 30, 30);
            Rectangle r3 = new Rectangle(Form1.leftborder + 40, 10 + (r1.Height * 2), 30, 30);
            Rectangle r4 = new Rectangle(r3.X - r3.Width, 10 + (r1.Height * 2), 30, 30);

            blist.Add(r1);
            blist.Add(r2);
            blist.Add(r3);
            blist.Add(r4);

            this.BlockList = blist;
            this.col = Color.Blue;
        }

        private void GenerateL()
        {
            List<Rectangle> blist = new List<Rectangle>();

            Rectangle r1 = new Rectangle(Form1.leftborder + 40, 10, 30, 30); 
            Rectangle r2 = new Rectangle(Form1.leftborder + 40, 10 + r1.Height, 30, 30);
            Rectangle r3 = new Rectangle(Form1.leftborder + 40, 10 + (r1.Height * 2), 30, 30);
            Rectangle r4 = new Rectangle(r3.X + r3.Width, 10 + (r1.Height * 2), 30, 30);

            blist.Add(r1);
            blist.Add(r2);
            blist.Add(r3);
            blist.Add(r4);

            this.BlockList = blist;
            this.col = Color.Orange;

        }

        private void GenerateI()
        {
            List<Rectangle> blist = new List<Rectangle>();

            Rectangle r1 = new Rectangle(Form1.leftborder + 40, 10, 30, 30); // links oben
            Rectangle r2 = new Rectangle(Form1.leftborder + 40 + r1.Height, 10, 30, 30); // links oben
            Rectangle r3 = new Rectangle(Form1.leftborder + 40 + r1.Height * 2, 10, 30, 30); // links oben
            Rectangle r4 = new Rectangle(Form1.leftborder + 40 + r1.Height * 3, 10, 30, 30); // links oben
            Rectangle r5 = new Rectangle(Form1.leftborder + 40 + r1.Height * 4, 10, 30, 30); // links oben

            blist.Add(r1);
            blist.Add(r2);
            blist.Add(r3);
            blist.Add(r4);
            blist.Add(r5);
            this.BlockList = blist;
            this.col = Color.DarkGreen;
        }

        private void GenerateO()
        {
            List<Rectangle> bList = new List<Rectangle>();
            Rectangle r1 = new Rectangle(Form1.leftborder + 40, 10, 30, 30); // links oben
            Rectangle r2 = new Rectangle(Form1.leftborder + 70, 10, 30, 30); // links 
            Rectangle r3 = new Rectangle(Form1.leftborder + 40, 40, 30, 30); // links unten
            Rectangle r4 = new Rectangle(Form1.leftborder + 70, 40, 30, 30);
            bList.Add(r1);
            bList.Add(r2);
            bList.Add(r3);
            bList.Add(r4);

            //Mutliblock test = new Mutliblock(bList, "O");
            this.BlockList = bList;
            this.col = Color.Yellow;
        }

        public void Rotate(string direction)
        {
            if (String.IsNullOrEmpty(direction))
            {
                return;
            }

            //TODO

        }

    }
}
