using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeGenerator.src
{
    public class GenerationCommand : Command
    {
        /// <summary>
        /// What we put into the axiom each generation.
        /// </summary>
        List<Command> GrowthList;

        public GenerationCommand(Command[] growth) : base()
        {
            GrowthList = new List<Command>();
            GrowthList.AddRange(growth);
        }

        public GenerationCommand() : base()
        {
            GrowthList = new List<Command>();
        }

        public override void Grow(List<Command> axiom)
        {
            axiom.AddRange(GrowthList.ToArray());
        }

        public override string ToString()
        {
            return "G";
        }
        /// <summary>
        /// Adds itself at the specified index to the growthArray
        /// </summary>
        /// <param name="index"></param>
        public void InsertSelf(int index)
        {
            GrowthList.Insert(index, this);
        }
        /// <summary>
        /// Adds itself to the end of the growthArray
        /// </summary>
        public void AddSelf()
        {
            GrowthList.Add(this);
        }
        /// <summary>
        /// Adds a command to the growthArray
        /// </summary>
        /// <param name="c"></param>
        public void AddCommand(Command c)
        {
            GrowthList.Add(c);
        }
        /// <summary>
        /// Adds an array of commands to the growthArray
        /// </summary>
        /// <param name="c"></param>
        public void AddCommands(Command[] c)
        {
            GrowthList.AddRange(c);
        }
    }
}
