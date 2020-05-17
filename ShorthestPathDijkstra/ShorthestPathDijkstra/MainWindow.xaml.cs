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

namespace DrawingLine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Point A;
        private readonly Point B;
        private readonly Point C;
        private readonly Point D;
        private readonly Point E;
        private readonly Point F;
        private readonly Point G;
        private Line myLine;
        int counter;
        List<Point> points;
        List<Line> lines;
        private readonly int [,]  adjacencyMatrix = { { 0, 84, 0, 60, 52, 39, 0 },
                                                      { 84, 0, 75, 0, 62, 0, 0 },
                                                      { 0, 75, 0, 78, 55, 0, 0  },
                                                      { 60, 0, 78, 0, 42, 0, 30 },
                                                      { 52, 62, 55, 42, 0, 0, 0 },
                                                      { 39, 0, 0, 0, 0, 0, 63},
                                                      {0, 0, 0, 30, 0, 63, 0 } };
        private int startPointIndex;
        private int finishPointIndex;

        public MainWindow()
        {
            InitializeComponent();
            A = new Point(514, 103);
            B = new Point(514, 271);
            C = new Point(621, 271);
            D = new Point(621, 139);
            E = new Point(575, 189);
            F = new Point(468, 48);
            G = new Point(578, 76);
            myLine = new Line();
            points = new List<Point>() { A, B, C, D, E, F, G };
            lines = new List<Line>();
            this.counter = 0;            
        }
       

        private void Click_Button(object sender, RoutedEventArgs e)
        {
            //Find Path
            CalculateDijkstra();
            //Create lines
            CreateLines();
            //Draw Path
            DrawLines();
            //Show distance
            tb.Text = (DijkstrasAlgorithm.shortestDistances[finishPointIndex]).ToString();
        }

        private void ClickE(object sender, RoutedEventArgs e)
        {
            canvas.Children.Add(AddEllipse(E.Y, E.X));
            counter++;
            if (counter == 1)
            {
                startPointIndex = 4;
            }
            else if (counter == 2)
            {
                finishPointIndex = 4;
            }           
        }

        private void ClickA(object sender, RoutedEventArgs e)
        {            
            canvas.Children.Add(AddEllipse(A.Y, A.X));
            counter++;
            if (counter == 1)
            {
                startPointIndex = 0;
            }
            else if (counter == 2)
            {
                finishPointIndex = 0;
            }           
        }
        
        private void ClickB(object sender, RoutedEventArgs e)
        {
            canvas.Children.Add(AddEllipse(B.Y, B.X));
            counter++;
            if (counter == 1)
            {
                startPointIndex = 1;
            }
            else if (counter == 2)
            {
                finishPointIndex = 1;
            }
        }

        private void ClickC(object sender, RoutedEventArgs e)
        {
            canvas.Children.Add(AddEllipse(C.Y, C.X));
            counter++;
            if (counter == 1)
            {
                startPointIndex = 2;
            }
            else if (counter == 2)
            {
                finishPointIndex = 2;
            }
        }

        private void ClickD(object sender, RoutedEventArgs e)
        {
            canvas.Children.Add(AddEllipse(D.Y, D.X));
            counter++;
            if (counter == 1)
            {
                startPointIndex = 3;
            }
            else if (counter == 2)
            {
                finishPointIndex = 3;
            }
            
        }

        private void ClickF(object sender, RoutedEventArgs e)
        {
            canvas.Children.Add(AddEllipse(F.Y, F.X));
            counter++;
            if (counter == 1)
            {
                startPointIndex = 5;
            }
            else if (counter == 2)
            {
                finishPointIndex = 5;
            }
        }

        private void ClickG(object sender, RoutedEventArgs e)
        {
            canvas.Children.Add(AddEllipse(G.Y, G.X));
            counter++;
            if (counter == 1)
            {
                startPointIndex = 6;
            }
            else if (counter == 2)
            {
                finishPointIndex = 6;
            }
        }
        private static Ellipse AddEllipse(double y, double x)
        {
            Ellipse myEllipse = new Ellipse();
            myEllipse.Stroke = Brushes.Green;
            myEllipse.Fill = Brushes.Green;           
            myEllipse.Width = 12;
            myEllipse.Height = 12;
            Canvas.SetTop(myEllipse, y - (myEllipse.Width)/2);
            Canvas.SetLeft(myEllipse, x - (myEllipse.Height)/2);
            return myEllipse;
        }

        private void Click_Clear(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            counter = 0;
            lines.Clear();
            DijkstrasAlgorithm.listPath.Clear();
        }
       
        private void CreateLines()
        {
            for (int i = 0; i < DijkstrasAlgorithm.listPath.Count; i++)
            {
                lines.Add(new Line());
            }
        }

        private void DrawLines()
        {
            for (int i = 0; i < (DijkstrasAlgorithm.listPath.Count) - 1; i++)
            {
                lines[i].Stroke = Brushes.Green;
                lines[i].StrokeThickness = 2;

                lines[i].X1 = points[DijkstrasAlgorithm.listPath[i]].X;
                lines[i].Y1 = points[DijkstrasAlgorithm.listPath[i]].Y;
                lines[i].X2 = points[DijkstrasAlgorithm.listPath[i + 1]].X;
                lines[i].Y2 = points[DijkstrasAlgorithm.listPath[i + 1]].Y;

                canvas.Children.Add(lines[i]);

            }
        }

        private void CalculateDijkstra()
        {
            DijkstrasAlgorithm.dijkstra(adjacencyMatrix, startPointIndex);

            DijkstrasAlgorithm.GetChosenPath(startPointIndex, finishPointIndex,
                DijkstrasAlgorithm.shortestDistances[finishPointIndex],
                DijkstrasAlgorithm.parents);
        }

        
    }

    
}
