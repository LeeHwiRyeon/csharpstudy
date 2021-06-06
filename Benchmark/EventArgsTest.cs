using BenchmarkDotNet.Attributes;
using System;

namespace Benchmark {

    [MarkdownExporter]
    [MemoryDiagnoser]
    public class EventArgsTest {
        public class ClassEventTestArgs : EventArgs {
            public int Handle;
        }
        public struct StructEventTestArgs {
            public int Handle;
        }
        public delegate void ClassEvent(object sender, ClassEventTestArgs e);
        public delegate void StructEvent(object sender, in StructEventTestArgs e);
        public event ClassEvent OnClassEvent;
        public event StructEvent OnStructEvent;
        public const int Count = 1000;
        public EventArgsTest()
        {
            OnClassEvent += ClassCallback;
            OnStructEvent += StructCallback;
        }

        [Benchmark]
        public void ClassEventArgsTest()
        {
            for (int i = 0; i < Count; i++) {
                OnClassEvent.Invoke(this, new ClassEventTestArgs {
                    Handle = i
                });
            }
        }
        void ClassCallback(object sender, ClassEventTestArgs e)
        {

        }

        [Benchmark]
        public void StructEventArgsTest()
        {
            for (int i = 0; i < Count; i++) {
                OnStructEvent.Invoke(this, new StructEventTestArgs {
                    Handle = i
                });
            }
        }

        public void StructCallback(object sender, in StructEventTestArgs e)
        {

        }
    }
}
