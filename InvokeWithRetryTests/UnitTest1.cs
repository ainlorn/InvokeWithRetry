using System;
using InvokeWithRetry;
using NUnit.Framework;

namespace InvokeWithRetryTests;

public class Tests
{
    [Test]
    public void FixedNumberExceptions_Test()
    {
        var exceptionsLeft = 100000;
        var succeeded = false;
        Invoke.InvokeWithRetry(() =>
        {
            if (exceptionsLeft > 0)
            {
                exceptionsLeft--;
                throw new Exception();
            }
            succeeded = true;
        }, 200000);
        Assert.True(succeeded);
    }
    
    [Test]
    public void NoExcessiveAttempts_Test()
    {
        var countAttempts = 0;
        
        Invoke.InvokeWithRetry(() => countAttempts++, 10);
        Assert.AreEqual(countAttempts, 1);
    }
}
