using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Utilities
{
    public class FileReader : IFileProvider
    {
        public IEnumerable<string> ReadAllLines(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"File not found: {path}");

            return File.ReadAllLines(path);
        }

        public void WriteAllLines(string path, IEnumerable<string> lines)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"File not found: {path}");

            File.WriteAllLines(path, lines);
        }
    }
}
