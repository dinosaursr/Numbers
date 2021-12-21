using System;

public static void MyParallelFor(
	int inclusiveLowerBound, int exclusiveUpperBound, Action <int> body)
{
	// Determine the number of iterations to be processed, the number of
	// cores to use, and the approximate number of iterations to process
	// in each thread.
	int size =  exclusiveUpperBound - inclusiveLowerBound;
	int numProcs = Environment.ProcessorCount;
	int range = size / numProcs;

	// Use a thread for each partition. Create them all,
	// start them all, wait on them all.
	var threads = new List<Thread>(numProcs);
	for (int p = 0; p < numProcs; p++)
    {
		int start = p * range + inclusiveLowerBound;
		int end = (p == numProcs - 1) ?
			exclusiveUpperBound : start + range;
		threads.Add(new Thread(() =>
		{
			for (int i = start; i < end; i++) body(i);
		}));
    }
	foreach (var thread in threads) thread.Start();
	foreach (var thread in threads) thread.Join();
}
{
	
}
