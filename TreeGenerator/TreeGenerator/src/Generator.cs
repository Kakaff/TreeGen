using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TreeGenerator.src
{
    public class Generator
    {

        TreeData treeData;

        List<Command> GenInfo;

        float lowestX, HighestX, lowestY, highestY,lowestZ,highestZ;
        int generations;

        Vector3 treeSize;

        /// <summary>
        /// Default Constructor.
        /// </summary>
        /// <param name="GenInfo"></param>
        public Generator(Command[] GenInfo)
        {
            treeData = new TreeData();
            this.GenInfo = new List<Command>();
            this.GenInfo.AddRange(GenInfo);
            treeSize = new Vector3(0, 0, 0);
        }
        /// <summary>
        /// A collection of nodes that make up this tree.
        /// </summary>
        public List<Node> Tree
        {
            get
            {
                return treeData.Nodes;
            }
        }
        /// <summary>
        /// How many generations this tree has grown.
        /// </summary>
        public int Generations
        {
            get
            {
                return generations;
            }
        }
        /// <summary>
        /// Advances the tree one generation.
        /// </summary>
        public void Grow()
        {
            List<Command> newGen = new List<Command>();

            foreach(Command c in GenInfo)
            {
                c.Grow(newGen);
            }
            generations++;
            GenInfo = newGen;
        }

        /// <summary>
        /// Generates the tree.
        /// </summary>
        public void GenerateTree()
        {
            treeData = new TreeData();

            for (int i = 0; i  < GenInfo.Count; i++)
            {
                treeData = GenInfo[i].Trigger(treeData);
            }
        }
        /// <summary>
        /// The size of the tree in 3d space.
        /// </summary>
        public Vector3 TreeSize
        {
            get
            {
                return treeSize;
            }
        }

        public Bitmap DrawTree(int PixelsPerWorldUnit)
        {
            Node[] nodes = Tree.ToArray();
            Debugger.Debug("Drew the tree");

            //Determine the size of the tree.
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].Position.X < lowestX)
                {
                    lowestX = nodes[i].Position.X;
                } else if (nodes[i].Position.X > HighestX)
                {
                    HighestX = nodes[i].Position.X;
                }

                if (nodes[i].Position.Y > highestY)
                {
                    highestY = nodes[i].Position.Y;
                } else if (nodes[i].Position.Y < lowestY)
                {
                    lowestY = nodes[i].Position.Y;
                }

                if (nodes[i].Position.Z < lowestZ)
                {
                    lowestZ = nodes[i].Position.Z;
                } else if (nodes[i].Position.Z > highestZ)
                {
                    highestZ = nodes[i].Position.Z;
                }
            }
            //Sets the size of the tree.
            treeSize = new Vector3(Math.Abs(lowestX) + HighestX, Math.Abs(lowestY) + highestY, Math.Abs(lowestZ) + highestY);
            
            //Sets the centre of the tree, so that we can draw it at the centre of the bmp.
            int centreX = (int)((Math.Abs(Math.Ceiling(TreeSize.X) + 1)) / 2f) * PixelsPerWorldUnit;
            int centreY = (int)((Math.Abs(Math.Ceiling(TreeSize.Y) + 1)) / 2f) * PixelsPerWorldUnit;

            //Creates a new bmp with the required size.
            Bitmap bmp = new Bitmap((int)(Math.Ceiling(treeSize.X + 2)) * PixelsPerWorldUnit, (int)(Math.Ceiling(treeSize.Y + 2)) * PixelsPerWorldUnit);

            int currentYPos = 0, currentXPos = 0;
            //Draws the tree.
            
                for (int i = 1; i < nodes.Length; i++)
                {
                    if (nodes[i].Parent != null)
                    {
                        //Gets the normalized vector between the parent and the child.
                        Vector3 normalized = Vector3.Normalize(nodes[i].Position, nodes[i].Parent.Position);

                    //Draws a line from the parent to the child.
                    
                    try
                    {
                        for (int j = 0; j < (int)(Vector3.Distance(nodes[i].Parent.Position, nodes[i].Position) * PixelsPerWorldUnit); j++)
                        {
                            currentXPos = centreX + (int)(((nodes[i].Parent.Position.X * PixelsPerWorldUnit) + (j * normalized.X)) / 2f);
                            currentYPos = centreY + (int)(((nodes[i].Parent.Position.Y * PixelsPerWorldUnit) + (j * normalized.Y)) / 2f);
                            bmp.SetPixel(centreX + (int)Math.Ceiling(((nodes[i].Parent.Position.X * PixelsPerWorldUnit) + (j * normalized.X)) / 2f), centreY + (int)Math.Ceiling(((nodes[i].Parent.Position.Y * PixelsPerWorldUnit) + (j * normalized.Y)) / 2f), Color.Black);
                        }
                    } catch
                    {
                        Debugger.Debug($"Failed to set the pixel at {currentXPos}, {currentYPos}");
                        Debugger.Debug($"CentreX was equal to: {centreX} and centreY was equal to: {centreY}");
                        Debugger.Debug($"TreeSize is equal to {TreeSize}");
                    }
                    }
                }
            
            return bmp;
        }
        /// <summary>
        /// Returns the axiom as a string.
        /// </summary>
        /// <returns></returns>
        public string WriteOutAxiom()
        {
            string Axiom = System.Environment.NewLine;
            foreach(Command c in GenInfo)
            {
                Axiom += c.ToString() + "|";
            }
            return Axiom;
        }
    }
}
