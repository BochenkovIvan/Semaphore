namespace Semaphore
{
    [TestClass]
    public class MySemaphoreTests
    {
        [TestMethod]
        public void TestAcquire()
        {
            MySemaphore semaphore = new MySemaphore(1);
            semaphore.Acquire();
            
        }

        [TestMethod]
        public void TestTryAcquire()
        {
            MySemaphore semaphore = new MySemaphore(1);
            bool result = semaphore.TryAcquire();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestRelease()
        {
            MySemaphore semaphore = new MySemaphore(2);
            semaphore.Acquire();
            int countBeforeRelease = semaphore.Release(1);
            Assert.AreEqual(1, countBeforeRelease);
        }

        [TestMethod]
        public void TestRelease2()
        {
            int countBeforeRelease = 0;
            MySemaphore semaphore = new MySemaphore(5);
            semaphore.Acquire();
            semaphore.Acquire();
            bool result = semaphore.TryAcquire();
            if (result)
            {
                countBeforeRelease = semaphore.Release(3);
            }
            Assert.AreEqual(2, countBeforeRelease);
        }

        [TestMethod]
        public void TestTryAcquireMonitor()
        {
            MyMonitorSemaphore semaphore = new MyMonitorSemaphore(1);
            bool result = semaphore.TryAcquire();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestReleaseMonitor()
        {

            MyMonitorSemaphore semaphore = new MyMonitorSemaphore(2);
            semaphore.Acquire();
            int countBeforeRelease = semaphore.Release(1);
            Assert.AreEqual(1, countBeforeRelease);
        }

        [TestMethod]
        public void TestRelease2Monitor()
        {
            int countBeforeRelease = 0;
            MyMonitorSemaphore semaphore = new MyMonitorSemaphore(5);
            semaphore.Acquire();
            semaphore.Acquire();
            bool result = semaphore.TryAcquire();
            if (result)
            {
                countBeforeRelease = semaphore.Release(3);
            }
            Assert.AreEqual(2, countBeforeRelease);
        }

    }


    
}