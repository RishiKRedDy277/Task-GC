using System;

public class MyDisposableClass : IDisposable
{
    // Some resource that needs to be managed
    private bool isDisposed = false;

    // Constructor
    public MyDisposableClass()
    {
        // Initialize resources or setup
    }

    // Method to do some work
    public void DoWork()
    {
        if (isDisposed)
            throw new ObjectDisposedException(nameof(MyDisposableClass));

        Console.WriteLine("Doing some work...");
    }

    // Implement IDisposable
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Dispose(bool disposing) is called by both Dispose() and the finalizer
    protected virtual void Dispose(bool disposing)
    {
        if (!isDisposed)
        {
            if (disposing)
            {
                // Release managed resources
                // Example: Close a file, release a database connection
            }

            // Release unmanaged resources
            // Example: Release a handle or native resource

            isDisposed = true;
        }
    }

    // Finalizer (destructor) for additional cleanup
    ~MyDisposableClass()
    {
        Dispose(false);
    }
}

class Program
{
    static void Main()
    {
        using (var myObject = new MyDisposableClass())
        {
            // Use the object within the using block
            myObject.DoWork();
        }

        // Explicitly trigger garbage collection
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
