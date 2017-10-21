using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHEZ_TouchWall.configuration.modules
{
    public class canvas
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public List<MyControl> Controls { get; set; }
        public string Margin { get; set; }
        public string Padding { get; set; }
        public string TitleMargin { get; set; }
        public string TitlePadding { get; set; }
    }
}

public class MyControl
{
    public int Id { get; set; }
    public string Title { get; set; }

    public int Type { get; set; }
    public string[] images { get; set; }
    public bool Enable { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public string Margin { get; set; }
    public string Padding { get; set; }
}

