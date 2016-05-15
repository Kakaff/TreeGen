using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeGenerator.src
{
    public class RotateCommand : Command
    {
        Vector3 rot;

        public Vector3 Rot
        {
            get
            {
                return rot;
            }
        }

        public RotateCommand(Vector3 rot) : base()
        {
            this.rot = rot;
        }

        public override string ToString()
        {
            return $"R;{rot.ToString()}";
        }

        public override TreeData Trigger(TreeData data)
        {
            data.RotateNode(rot);
            return data;
        }
    }
}
