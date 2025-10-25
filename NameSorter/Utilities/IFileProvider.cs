using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Utilities
{
    public interface IFileProvider
    {
       IEnumerable<string> ReadAllLines(string path);
       void WriteAllLines(string path, IEnumerable<string> lines);
    }

}
