using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicIndexeerV2.File
{
    public class Song
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public TimeSpan Duration { get; set; }
        public long FileSizeInBytes { get; set; }
    }
}
