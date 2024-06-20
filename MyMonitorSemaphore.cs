using System;
using System.Threading;

namespace Semaphore
{

    public class MyMonitorSemaphore : ISemaphore
    {
        private readonly object lockObject = new();
        private int m_Count;

        public MyMonitorSemaphore(int count)
        {
            m_Count = count;
        }  
        
        public void Acquire() 
        {
            Monitor.Enter(lockObject);
            while(m_Count == 0)
            {
                Monitor.Wait(lockObject);
            }
            m_Count--;
            Monitor.Exit(lockObject);
        }
        public bool TryAcquire() 
        {
            Monitor.Enter(lockObject);
            if (m_Count > 0)
            {
                m_Count--;
                Monitor.Exit(lockObject);
                return true;
            }
            else
            {
                Monitor.Exit(lockObject);
                return false;
            }
        }
        public int Release(int releaseCount) 
        {
            Monitor.Enter(lockObject);
            m_Count += releaseCount;
            Monitor.PulseAll(lockObject);
            Monitor.Exit(lockObject);
            return m_Count -= releaseCount;
        }

    }
}
