using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using System;

namespace Benchmark {
    internal class Program {
        private static void Main(string[] args)
        {
#if DEBUG
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).RunAll(new DebugInProcessConfig());
#elif RELEASE
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).RunAll();
#endif
        }
    }
}
