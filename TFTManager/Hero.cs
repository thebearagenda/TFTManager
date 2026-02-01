using System.Collections.Generic;

namespace TFTManager
{
    public class Hero
    {
        public string Name { get; set; }
        public Role Role { get; set; }
        public string Origin { get; set; }
        public string Class1 { get; set; }
        public string Class2 { get; set; }
        public List<string> GetTraitNames()
        {
            List<string> traits = new List<string> { Origin, Class1 };
            if( !string.IsNullOrEmpty( Class2 ) ) traits.Add( Class2 );
            return traits;
        }
    }
}
