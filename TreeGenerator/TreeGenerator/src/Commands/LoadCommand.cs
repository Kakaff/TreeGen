using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeGenerator.src
{
    public class LoadCommand : Command
    {

        public LoadCommand() : base()
        {

        }

        public override TreeData Trigger(TreeData data)
        {
            data.Load();
            return data;
        }

        public override string ToString()
        {
            return "]";
        }
    }
}
