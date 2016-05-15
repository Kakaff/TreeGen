using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TreeGenerator.src;
using System.Drawing;

namespace TreeGenerator
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bitmap tree;

        Command[] axiom;

        Generator gen;
        GenerationCommand gencom;
        
        
        public MainWindow()
        {
            InitializeComponent();
            gencom = new GenerationCommand();
            gencom.AddCommand(new RotateCommand(new Vector3(0, 0, 22.5f)));
            gencom.AddCommand(new ForwardCommand(2f));
            gencom.AddSelf();
            Debugger.OnDebug += DebugMsg;

            axiom = new Command[] {gencom};
            gen = new Generator(axiom);
            CurrentAxiom.Text = "Axiom: " + gen.WriteOutAxiom();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            gen.GenerateTree();
            

            TreeImage.Source = Helpers.LoadBitmap(gen.DrawTree(10));

            TreeInfo.Text = "TreeInfo: "
                + Environment.NewLine + "Size: " + gen.TreeSize.ToString()
                + Environment.NewLine + "Nodes: " + gen.Tree.Count
                + Environment.NewLine + "Generations: " + gen.Generations;
        }

        private void GrowButton_Click(object sender, RoutedEventArgs e)
        {
            gen.Grow();
            CurrentAxiom.Text = "Axiom: " + gen.WriteOutAxiom();
        }

        public void DebugMsg(string msg)
        {
            DebugText.Text += msg + Environment.NewLine;
        }
    }
}
