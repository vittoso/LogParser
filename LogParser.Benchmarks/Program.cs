using BenchmarkDotNet.Running;
using LogParser.Benchmarks;

var summary = BenchmarkRunner.Run<ParserBenchmark>();