using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeGenerator.src
{
    public class SaveCommand : Command
    {

        public SaveCommand() : base()
        {

        }

        public override TreeData Trigger(TreeData data)
        {
            data.Save();
            return data;
        }

        public override string ToString()
        {
            return "[";
        }
    }
}
