using System;
using UnityEngine.Profiling;

// See UnityEngine.TestTools.Constraints.AllocatingGCMemoryConstraint
// and https://maingauche.games/devlog/20230504-counting-allocations-in-unity/
namespace UnityUtils {
    public class AllocCounter {
        UnityEngine.Profiling.Recorder rec;

        public AllocCounter() {
            rec = Recorder.Get("GC.Alloc");
            rec.enabled = false;

#if !UNITY_WEBGL
            rec.FilterToCurrentThread();
#endif

            rec.enabled = true;
        }

        public int Stop() {
            if (rec == null) throw new InvalidOperationException("AllocCounter was not started.");

            rec.enabled = false;

#if !UNITY_WEBGL
            rec.CollectFromAllThreads();
#endif

            int result = rec.sampleBlockCount;
            rec = null;
            return result;
        }

        public static int Instrument(Action action) {
            var counter = new AllocCounter();
            int allocs;

            try {
                action();
            }
            finally {
                allocs = counter.Stop();
            }

            return allocs;
        }
    }
}