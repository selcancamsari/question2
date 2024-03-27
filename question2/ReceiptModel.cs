using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace question2
{
    public class ReceiptModel
    {
        public string locale { get; set; }
        public string description { get; set; }
        public BoundingPoly? boundingPoly { get; set; }

    }

    public class BoundingPoly
    {
        public List<Vertices> vertices { get; set; }

        //konumu için
        public int minY
        {
            get { return vertices.Min(s => s.y); }
        }
        public int? maxY 
        {
            get { return vertices.Max(s => s.y); }
        }

        //0 sol üst 
        //1 sağ üst 
        //2 sağ alt
        //3 sol alt
    }

    public class Vertices
    {
        public int x { get; set; }
        public int y { get; set; }
    }
}