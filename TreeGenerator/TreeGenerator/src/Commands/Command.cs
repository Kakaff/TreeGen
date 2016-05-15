using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeGenerator.src
{
    public class Command
    {
        public Command()
        {

        }
        /// <summary>
        /// Modifies the treedata through this command.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual TreeData Trigger(TreeData data)
        {
            return data;
        }
        /// <summary>
        /// Modifies the axiom through this command.
        /// </summary>
        /// <param name="axiom"></param>
        public virtual void Grow(List<Command> axiom)
        {
            axiom.Add(this);
        }
    }
}
