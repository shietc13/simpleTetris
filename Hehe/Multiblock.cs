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

                    break;
                case "I":
                    GenerateI();
                    break;
                case "J":

                    break;
                case "Z":

                    break;
                case "S":

                    break;

                case "T":

                    break;


            }

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
            this.col = Color.Orange;

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
            this.col = Color.Blue;
        }

        public void Rotate(string direction)
        {
            if (String.IsNullOrEmpty(direction))
            {
                return;
            }



        }

    }
}
