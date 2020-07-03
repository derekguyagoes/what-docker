using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace ReactDotnet.Models
{
    public class Container
    {
        public string Image { get; set; }
        public string Names { get; set; }
        public string Ports { get; set; }
    }
}