using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 屏幕工具.Bean
{
    public class Vertexes_locationItem
    {
        public int x { get; set; }
        public int y { get; set; }
    }
    public class BodyItem
    {
        public int column { get; set; }
        public double probability { get; set; }
        public int row { get; set; }
        public List<Vertexes_locationItem> vertexes_location { get; set; }
        public string words { get; set; } //目
    }
    public class FooterItem
    {
        public int column { get; set; }
        public double probability { get; set; }
        public int row { get; set; }
        public List<Vertexes_locationItem> vertexes_location { get; set; }
        public string words { get; set; }
    }
    public class HeaderItem
    {
        public int column { get; set; }
        public double probability { get; set; }
        public int row { get; set; }
        public List<Vertexes_locationItem> vertexes_location { get; set; }
        public string words { get; set; } //29月
    }
    public class Forms_resultItem
    {
        public List<BodyItem> body { get; set; }
        public List<FooterItem> footer { get; set; }
        public List<HeaderItem> header { get; set; }
        public List<Vertexes_locationItem> vertexes_location { get; set; }
    }
    public class OcrExcelBean
    {
        public long log_id { get; set; }
        public int forms_result_num { get; set; }
        public List<Forms_resultItem> forms_result { get; set; }
    }
}
