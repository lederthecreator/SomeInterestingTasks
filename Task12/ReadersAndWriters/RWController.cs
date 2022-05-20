using System.Security.Cryptography;

namespace Task12.ReadersAndWriters;

public static class ReadWriteController
{
    private static int _rCount;
    private static int _wCount;
    private static AutoResetEvent _writeEvent = new AutoResetEvent(true);
    private static AutoResetEvent _readEvent = new AutoResetEvent(true);

    public static void RequestRead()
    {
        while (_wCount > 0) _readEvent.WaitOne();
        Interlocked.Increment(ref _rCount);
        //_rCount += 1;
    }

    public static void ReleaseRead()
    {
        Interlocked.Decrement(ref _rCount);
        //_rCount -= 1;
        if (_rCount == 0) _writeEvent.Set();
    }

    public static void RequestWrite()
    {
        while (_rCount > 0 && _wCount > 0) _writeEvent.WaitOne();
        Interlocked.Increment(ref _wCount);
        //_wCount += 1;
    }

    public static void ReleaseWrite()
    {
        Interlocked.Decrement(ref _wCount);
        //_rCount += 1;
        _readEvent.Set();
        _writeEvent.Set();
    }
}