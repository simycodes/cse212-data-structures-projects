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

        // MY PLAN TO IMPLEMENT THE MultiplesOf FUNCTION
        // 1.DEFINE AM ARRAY TO HOLD THE COLLECTION OF MULTIPLES
        //   NOTE: MULTIPLE IS A NUMBER OBTAINED WHEN GIVEN A NUMBER IS MULTIPLIED BY OTHER INTEGER
        //   USUALLY (A NATURAL NUMBER) STARTING FROM 1 GOING UP(MULTIPLYING THIS BY STARTING NUMBER)
        // 2.USE A FOR LOOP TO GET THE NEEDED MULTIPLES AND STORE THEM IN A LIST IN EACH ITERATION
        //   LIMIT COUNTER WILL BE EQUAL TO length PASSED
        //   number WILL BE USED TO GET THE NEEDED MULTIPLE BY MULTIPLYING IT WITH THE ITERATION 
        //   VALUE IN EACH ITERATION CYCLE
        // 3.AFTER THE CALCULATION BY THE FOR LOOP, RETURN THE LIST HOLDING ALL THE MULTIPLES

        // DEFINE AM ARRAY TO HOLD THE COLLECTION OF MULTIPLES
        double[] multiplesOfANumber = new double[length];
        // DEFINE FOR LOOP TO CALCULATE AND STORE THE MULTIPLES
        for(int i = 1; i <= length; i++) 
        {
            double multipleNumber = number * i;
            multiplesOfANumber[i-1] = multipleNumber;
        }
        
        // return []; // replace this return statement with your own
        return multiplesOfANumber;
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

        // MY PLAN TO IMPLEMENT THE RotateListRight FUNCTION
        // 1.ENSURE WRAPPING AROUND THE INDEX NUMBER TO 0 INCASE THE AMOUNT TO WRAP IS
        // GREATER THAN THE SIZE OF THE LIST
        // 2. GET THE FIRST PART SET OF NUMBERS FROM THE LIST USING THE FUNCTION & STORE 
        // IN A NEW LIST USING THE METHOD GetRange(0, data.Count - amount);
        // 3. GET THE LAST PART SET OF NUMBERS (NEEDED NUMBERS TO MOVE) FROM THE LIST
        // & STORE IN A NEW LIST USING THE METHOD data.GetRange(data.Count - amount, amount);
        // 4. CLEAR THE ACTUAL LIST
        // 5. ADD THE LAST SET OF NUMBERS AND THE ADD THE FIRST SET OF NUMBERS

        // ENSURE WRAPPING AROUND THE INDEX NUMBER TO 0 INCASE THE AMOUNT TO WRAP IS 
        // GREATER THAN THE SIZE OF THE LIST
        amount %= data.Count;
        if (amount == 0) 
        {
            return;
        }
        // NOTE: from data = <List>{1,2,3,4,5}, data.GetRange(0, 3) will give you a new list 
        // <List>{1,2,3}
        // GET THE FIRST PART SET OF NUMBERS FROM THE LIST
        List<int> beginningNumbers = new List<int>();
        beginningNumbers = data.GetRange(0, data.Count - amount);

        // GET THE LAST PART SET OF NUMBERS (NEEDED NUMBERS TO MOVE) FROM THE LIST
        List<int> endingNumbers = new List<int>();
        endingNumbers = data.GetRange(data.Count - amount, amount);

        // CLEAR THE ARRAY BEFORE INSERTING ROTATED DATA
        data.Clear();
        // MAKE THE ROTATION BY FIRST ADDING THE SET OF endingNumbers FIRST 
        data.AddRange(endingNumbers);
        // ADD THE SET OF beginningNumbers NUMBERS 
        data.AddRange(beginningNumbers);
    }
}
