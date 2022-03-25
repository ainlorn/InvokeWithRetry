namespace InvokeWithRetry;

public class Invoke
{
    public static bool InvokeWithRetry(Action action, int maxAttempts)
    {
        var isSuccess = false;
        var currentAttempts = 0;

        while (!isSuccess && currentAttempts < maxAttempts)
        {
            try
            {
                action();
                isSuccess = true;
            }
            catch
            {
                currentAttempts++;
            }
        }

        return isSuccess;
    }
}
