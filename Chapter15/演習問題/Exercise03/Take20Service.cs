using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03;
public class Take20Service : ITextFileService {

    private int _count = 0;

    public void Initialize(string fname) {

    }

    public void Execute(string line) {
        if (_count < 20) {
            Console.WriteLine(line);
        }
        _count++;
    }

    public void Terminate() {

    }
}
