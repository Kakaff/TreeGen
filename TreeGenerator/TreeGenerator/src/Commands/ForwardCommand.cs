using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeGenerator.src
{
    public class ForwardCommand : Command
    {
        float dist;

        /// <summary>
        /// The distance from the parent this command will place a node.
        /// </summary>
        public float Dist
        {
            get
            {
                return dist;
            }
        }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        /// <param name="Dist"></param>
        public ForwardCommand(float Dist) : base()
        {
            this.dist = Dist;
        }


        public override TreeData Trigger(TreeData data)
        {
            Vector3 newPos = Vector3.Rotate(new Vector3(data.CurrentPos) + (new Vector3(0,-1f * dist, 0)),data.CurrentRotation);
            //Rotate this by the rot thingie majubby. then add it to the newPos.
            data.CreateNewNode(newPos, data.CurrentRotation);
            return data;
        }

        public override string ToString()
        {
            return $"F;{dist}";
        }
    }
}
