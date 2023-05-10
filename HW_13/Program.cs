int x = 1;

Mutex mutex = new();

Thread thread1 = new(PrintNumbers);
Thread thread2 = new(PrintNumbers);

thread1.Start();
thread2.Start();

void PrintNumbers()
{
    for (; x < 100; x++)
    {
        mutex.WaitOne();
        Console.WriteLine($"ThreadID: {Thread.CurrentThread.ManagedThreadId}: {x}");
        Thread.Sleep(1000);
        mutex.ReleaseMutex();
    }
}