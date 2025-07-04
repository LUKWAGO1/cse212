public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array of doubles with the specified length.
        // Step 2: Loop from 0 to length-1.
        // Step 3: For each index i, calculate the multiple as number * (i + 1).
        // Step 4: Assign the calculated value to the array at index i.
        // Step 5: After the loop, return the array.

        double[] result = new double[length]; // Step 1

        for (int i = 0; i < length; i++) // Step 2
        {
            result[i] = number * (i + 1); // Steps 3 and 4
        }

        return result; // Step 5
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
    
    
{
    // Step 1: Determine the split point. The last 'amount' elements will move to the front.
    // Step 2: Use GetRange to get the last 'amount' elements as a new list.
    // Step 3: Use GetRange to get the first 'data.Count - amount' elements as another list.
    // Step 4: Clear the original list.
    // Step 5: Add the last 'amount' elements to the list.
    // Step 6: Add the first 'data.Count - amount' elements to the list.
    // Step 7: The list is now rotated to the right by 'amount'.

    int n = data.Count; // Step 1
    List<int> lastPart = data.GetRange(n - amount, amount); // Step 2
    List<int> firstPart = data.GetRange(0, n - amount); // Step 3

    data.Clear(); // Step 4
    data.AddRange(lastPart); // Step 5
    data.AddRange(firstPart); // Step 6
    // Step 7 done
}
    }
}