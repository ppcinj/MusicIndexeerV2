using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicIndexeerV2.Config
{
    public class Configuration
    {
        public IList<string> SearchPaths { get; set; }
        public bool UseExtendedSearchPattern { get; set; }
        public bool LoadExtendedInformation { get; set; }
    }
}
