using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeGenerator.src
{
    public class TreeData
    {
        List<Node> nodes;

        List<int> savedPositions;

        int currentNode;
        /// <summary>
        /// The position of the currently selected node.
        /// </summary>
        public Vector3 CurrentPos
        {
            get
            {
                return nodes[currentNode].Position;
            }
        }
        /// <summary>
        /// The rotation of the currently selected node.
        /// </summary>
        public Vector3 CurrentRotation
        {
            get
            {
                return nodes[currentNode].Rotation;
            }
        }

        /// <summary>
        /// The nodes that make up this tree.
        /// </summary>
        public List<Node> Nodes
        {
            get
            {
                return nodes;
            }
        }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public TreeData()
        {
            nodes = new List<Node>();
            savedPositions = new List<int>();
            nodes.Add(new Node(new Vector3(0, 0, 0), new Vector3(0, 0, 0), null, 0));
        }
        /// <summary>
        /// Saves the current position.
        /// </summary>
        public void Save()
        {
            savedPositions.Add(nodes.Count - 1);
        }
        /// <summary>
        /// Loads the last saved position.
        /// </summary>
        public void Load()
        {
            currentNode = savedPositions.Last();
            savedPositions.Remove(savedPositions.Last());
        }

        public void CreateNewNode(Vector3 pos, Vector3 rot)
        {
            nodes.Add(new Node(pos, rot, nodes[currentNode]));
            currentNode = nodes.Count - 1;
        }

        public void CreateNewNode(Vector3 pos)
        {
            nodes.Add(new Node(pos, CurrentRotation,nodes[currentNode]));
            currentNode = nodes.Count - 1;
        }

        public void RotateNode(Vector3 rot)
        {
            Node _n = new Node(CurrentPos, CurrentRotation + rot,nodes[currentNode].Parent,nodes[currentNode].Generation);
            nodes.Remove(nodes.Last());
            nodes.Add(_n);
        }
    }
}
