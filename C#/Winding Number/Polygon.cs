namespace Polygon
{

    class Polygon2D
    {
        Point[] Vertices;
        Edge[] Edges;

        private IEnumerable<Point> MakePoints(float[][] points)
        {

            for (int i=0; i<points.Count(); i++)
            {
                yield return new Point(points[i]);
            }
        }

        private IEnumerable<Edge> MakeEdges(Point[] points)
        {
            for (int i=0; i<points.Count(); i++)
            {
                yield return new Edge(points[i], points[(i+1)%points.Count()]);
            }
        }

        public Polygon2D(float[][] points)
        {
            if (points.Count() < 3)
            {
                throw new Exception("O polígono deve ter no mínimo 3 vértices.");
            }
            Edges = MakeEdges(
                Vertices = MakePoints(points).ToArray()
            ).ToArray();
        }
    
        public bool CheckPointCollide(Point point)
        {
            int laps = 0;
            
            foreach(Edge edge in Edges)
            {
                if (edge.HorizontallyBehind(point.X) && edge.BetweenYCoords(point.Y))
                {
                    laps += edge.Orientation;
                }
            }
            return laps != 0;
        }

    }

    class Point
    {
        float[] Coord;

        public float X
        {
            get { return Coord[0]; }
            set { Coord[0]=value; }
        }
        public float Y
        {
            get { return Coord[1]; }
            set { Coord[1]=value; }
        }

        public Point(float[] coords)
        {
            Coord = coords;
        }

        public Point(float x, float y)
        {
            Coord = [x, y];
        }

    }

    class Edge{
        Point Start;
        Point End;
        private int _orientation = 0;
        public int Orientation
        {
            get {return _orientation;}
        }

        public Edge(Point start,Point end)
        {
            Start = start;
            End = end;

            if (start.Y > end.Y)
            {
                _orientation = -1;
            } else
            if (end.Y > start.Y)
            {
                _orientation = 1;
            }

        }

        public bool BetweenYCoords(float Y)
        {
            return (
                (Start.Y < Y && Y < End.Y) ||
                (End.Y < Y && Y < Start.Y)
            );
        }

        public bool HorizontallyBehind(float X)
        {
            return (
                X < Math.Min(Start.X, End.X)
            );
        }
    }

}
