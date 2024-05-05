using BenchmarkDotNet.Attributes;
using LogParser.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogParser.Benchmarks
{
    [MemoryDiagnoser]
    public class ParserBenchmark
    {

        public ParserBenchmark()
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            this.ExamplesPath = Path.Combine(dir, "Examples", "log");
        }

        public string ExamplesPath { get; }

        [Benchmark]
        public async Task Parse()
        {
            List<string> files = new List<string> {
                Path.Combine(ExamplesPath, "Errors.log")
            };
            Parser p = new Parser();
            await p.StartParseFiles(files);
        }
    }
}
