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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Create an array to store the multiples
        // The size of the array is determined by 'length'.
        double[] multiples = new double[length];

        // Step 2: This will loop through each index of the array
        // For each index 'i', calculate the multiple using (i + 1) * number
        for (int i = 0; i < length; i++)
        {
            // Calculate the i multiple of 'number'
            multiples[i] = number * (i + 1);
        }

        // Step 3: Return the multiples 
        return multiples;
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
         // Step 1: Validate the input
        // This will help to ensure the list is not null or empty, and that the amount is within a valid range.
        if (data == null || data.Count == 0 || amount <= 0 || amount > data.Count)
        {
            return; // No changes needed
        }

        // Step 2: Calculate the effective rotation
        // If 'amount' is greater than the size of the list, use the remainder after division.
        amount = amount % data.Count;

        // Step 3: Use slicing to rotate the list
        // Separate the last 'amount' elements and the rest of the list.
        List<int> rotatedPart = data.GetRange(data.Count - amount, amount);
        List<int> remainingPart = data.GetRange(0, data.Count - amount);

        // Step 4: Clear the original list and append the parts in the correct order
        data.Clear();
        data.AddRange(rotatedPart);
        data.AddRange(remainingPart);
    }
}