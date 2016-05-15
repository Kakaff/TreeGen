using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeGenerator.src
{
    public class Node
    {

        Vector3 pos;
        Vector3 rotation;
        int generation;

        Node parent;
        List<Node> children;
        /// <summary>
        /// The parent of this node.
        /// </summary>
        public Node Parent
        {
            get
            {
                return parent;
            }
        }
        /// <summary>
        /// The rotation of this node.
        /// </summary>
        public Vector3 Rotation
        {
            get
            {
                return rotation;
            }
        }
        /// <summary>
        /// The position of this Node.
        /// </summary>
        public Vector3 Position
        {
            get
            {
                return pos;
            }
        }
        /// <summary>
        /// The generation this node belongs to.
        /// </summary>
        public int Generation
        {
            get
            {
                return generation;
            }
        }

        public Node(Vector3 pos, Vector3 rot)
        {
            this.pos = pos;
            rotation = rot;
            children = new List<Node>();
            generation = 0;
        }

        public Node(Vector3 pos, Vector3 rot, Node parent)
        {
            this.pos = pos;
            rotation = rot;
            this.parent = parent;
            children = new List<Node>();
            generation = parent.Generation;
        }

        public Node(Vector3 pos, Vector3 rot, int generation)
        {
            this.pos = pos;
            rotation = rot;
            children = new List<Node>();
            this.generation = generation;
        }

        public Node(Vector3 pos, Vector3 rot, Node parent, int generation)
        {
            this.pos = pos;
            rotation = rot;
            this.parent = parent;
            children = new List<Node>();
            this.generation = generation;
        }

        /// <summary>
        /// Adds a child to this Node.
        /// </summary>
        /// <param name="child"></param>
        public void AddChild(Node child)
        {
            children.Add(child);
            child.parent = this;
        }
    }
}
