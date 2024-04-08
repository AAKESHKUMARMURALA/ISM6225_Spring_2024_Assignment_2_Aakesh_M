/* 

YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Determine if the array is empty. If it is, return 0 since there are no elements.
                if (nums.Length == 0)
                    return 0;

                // Set k to 1 because the first element is always considered unique.
                int k = 1;
                // Iterate starting from the second element and compare it with the previous one.
                for (int i = 1; i < nums.Length; i++)
                {
                    // If the current element is different from the previous one (indicating a unique element),
                    // assign it to the k-th position and increment k.
                    if (nums[i] != nums[i - 1])
                    {
                        nums[k] = nums[i];
                        k++;
                    }
                }

                // Return the count of unique elements found in the array.
                return k;
            }
            catch (Exception)
            {
                // If any exception occurs, pass it along.
                throw;
            }
        }


        /*
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */


        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // Ensure that the input array is neither null nor empty. If it is, return an empty list.
                if (nums == null || nums.Length == 0)
                    return new List<int>();

                int nonZeroPointer = 0; // Keep track of the next position for a non-zero element.

                // Iterate through each element in the array.
                for (int i = 0; i < nums.Length; i++)
                {
                    // If the current element is not zero, move it to the position indicated by nonZeroPointer.
                    // This operation effectively relocates all non-zero elements to the beginning of the array while maintaining their original order.
                    if (nums[i] != 0)
                    {
                        nums[nonZeroPointer] = nums[i];
                        nonZeroPointer++; // Advance the nonZeroPointer.
                    }
                }

                // Once all non-zero elements are relocated to the front,
                // populate the remaining part of the array with zeros.
                while (nonZeroPointer < nums.Length)
                {
                    nums[nonZeroPointer] = 0;
                    nonZeroPointer++; // Increment the pointer to insert zeros.
                }

                // Convert the modified array into a list and return it.
                return nums.ToList();
            }
            catch (Exception)
            {
                // If an exception occurs, propagate it to the caller.
                throw;
            }
        }

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Initializing a list to store unique triplets.
                List<IList<int>> result = new List<IList<int>>();
                // Sorting the array to facilitate finding zero-sum triplets.
                Array.Sort(nums);

                // Looping through the array, treating each element as a potential first element of a triplet.
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Skipping duplicates to avoid repetitive triplets.
                    if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                    {
                        // Initializing pointers for the second and third elements of the triplet.
                        int low = i + 1, high = nums.Length - 1, sum = 0 - nums[i];

                        // Using two pointers to find complementary elements that sum up to zero with nums[i].
                        while (low < high)
                        {
                            if (nums[low] + nums[high] == sum)
                            {
                                // Adding the found triplet to the result list.
                                result.Add(new List<int> { nums[i], nums[low], nums[high] });
                                // Skipping duplicates for the second element of the triplet.
                                while (low < high && nums[low] == nums[low + 1]) low++;
                                // Skipping duplicates for the third element of the triplet.
                                while (low < high && nums[high] == nums[high - 1]) high--;
                                // Advancing pointers to the next unique elements.
                                low++;
                                high--;
                            }
                            else if (nums[low] + nums[high] < sum) // If the sum is too small, moving the low pointer upwards.
                                low++;
                            else // If the sum is too big, moving the high pointer downwards.
                                high--;
                        }
                    }
                }
                // Returning the list of all found triplets.
                return result;
            }
            catch (Exception)
            {
                // Rethrowing any caught exceptions.
                throw;
            }
        }

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                // Initialize maxCount to track the maximum number of consecutive 1s found.
                int maxCount = 0;
                // Initialize count to track the current number of consecutive 1s.
                int count = 0;

                // Loop through each number in the array.
                foreach (int num in nums)
                {
                    if (num == 1)
                    {
                        // If the current number is 1, increment the current count of consecutive 1s.
                        count++;
                        // Update maxCount if the current count exceeds the previous maximum.
                        maxCount = Math.Max(maxCount, count);
                    }
                    else
                    {
                        // If the current number is not 1, reset the current count of consecutive 1s.
                        count = 0;
                    }
                }
                // Return the maximum count of consecutive 1s found in the array.
                return maxCount;
            }
            catch (Exception)
            {
                // In case of an exception, rethrow it.
                throw;
            }
        }

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                // Variable to store the resulting decimal value.
                int decimalNumber = 0;
                // Represents the current base value (1, 2, 4, 8, ...) in binary.
                int baseValue = 1;

                // Loop until all digits of the binary number have been processed.
                while (binary > 0)
                {
                    // Extract the last digit (0 or 1) of the binary number.
                    int lastDigit = binary % 10;
                    // Reduce binary number by removing the last digit.
                    binary = binary / 10;
                    // Calculate the decimal value of the current digit and add it to the total decimalNumber.
                    decimalNumber += lastDigit * baseValue;
                    // Update the base value for the next digit, moving left in the binary number.
                    baseValue *= 2;
                }
                // Return the computed decimal value.
                return decimalNumber;
            }
            catch (Exception)
            {
                // In case of an exception, propagate it.
                throw;
            }
        }

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.


        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                // Verify if the array contains fewer than two elements. If it does, return 0 as no gap can occur.
                if (nums.Length < 2) return 0;

                // Rearrange the array to simplify the process of identifying the maximum gap between adjacent elements.
                Array.Sort(nums);

                // Initialize maxGap to monitor the largest difference between adjacent elements.
                int maxGap = 0;

                // Traverse through the array, commencing from the second element.
                for (int i = 1; i < nums.Length; i++)
                {
                    // Revise maxGap if the disparity between the current element and its predecessor surpasses the existing maxGap.
                    maxGap = Math.Max(maxGap, nums[i] - nums[i - 1]);
                }

                // Report the most extensive gap identified among adjacent elements in the arranged array.
                return maxGap;
            }
            catch (Exception)
            {
                // If an exception arises, forward it for external handling.
                throw;
            }
        }

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // Arrange elements in nums in ascending order.
                Array.Sort(nums);

                // Iterate from the largest element backwards to find a potential triangle.
                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    // Check if nums[i], nums[i - 1], and nums[i - 2] can form a triangle.
                    // A triangle is valid if the sum of the two smaller sides is greater than the largest side.
                    if (nums[i] < nums[i - 1] + nums[i - 2])
                        // If a triangle can be formed, return its perimeter.
                        return nums[i] + nums[i - 1] + nums[i - 2];
                }
                // If no valid triangle can be formed, return 0.
                return 0;
            }
            catch (Exception)
            {
                // Rethrow any exception for external handling.
                throw;
            }
        }

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.



        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */


        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Declare an integer variable to keep track of the position of the first occurrence of the 'part' substring within the 's' string.
                int index;
                // Loop until the 'part' substring is found within the 's' string, updating the index of the first occurrence each time.
                while ((index = s.IndexOf(part)) != -1)
                {
                    // Remove the first occurrence of the 'part' substring from the 's' string using the 'Remove' method, specifying the starting position (index) and the length of the substring to remove (part.Length).
                    s = s.Remove(index, part.Length);
                }
                // Return the modified 's' string with all occurrences of the 'part' substring removed.
                return s;
            }
            catch (Exception)
            {
                // If any exception occurs during the execution of the code, rethrow it to be handled by the caller.
                throw;
            }
        }




        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
