using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day07_test
{
    internal class File : IReadable, IWritable {

            public string Name;

            public File(string _Name)
            {
                Name = _Name;
            }

            public void Read()
            {
                Console.WriteLine("Reading data from: " + Name);
            }

            public void Write()
            {
                Console.WriteLine("Writing data to: " + Name);
            }
        }
}
