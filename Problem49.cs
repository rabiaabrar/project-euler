using System;
using System.Collections.Generic;
using System.Linq;

// This is a basic solution to Project Euler problem called "Prime permutations"
// https://projecteuler.net/problem=49

// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
{
    static void Main(string[] args)
    {
        int limit = 9999;
        
        for(var i=1000; i<=limit; i++)
        {
            if(IsPrime(i))
            {
                //Console.WriteLine(i);

                int n1 = i;
                for(int? j=GetNextPrime(n1, limit); j.HasValue; j = GetNextPrime(j.Value,limit))
                {
                    int n2 = j.Value;
                    int n3 = n2 + (n2-n1);
                    
                    //if(IsDigitalPermutation(n1, n2))
                      //  Console.WriteLine("{0}, {1}, {2}", n1, n2, n3);
                    
                   // if(IsPrime(n3) 
                     //  && n3<=limit)
                       // Console.WriteLine("Found equidistant primes! {0}, {1}, {2}", n1, n2, n3);

                    if(IsPermutation(n1, n2) 
                       && IsPermutation(n2, n3) 
                       && IsPrime(n3) 
                       && n3<=limit)
                        Console.WriteLine("Found equidistant prime permutations! {0}, {1}, {2}", n1, n2, n3);
                }                    
            }
        }
        
        Console.WriteLine("That's all folks.");
    }    
               
    static int? GetNextPrime(int number, int limit)
    {
        for(int i=number+1; i<=limit; i++)
            if(IsPrime(i))
                return i;
        
        return null;
    }
    
    static List<int> GetDigits(int source)
    {
        var digits = new List<int>();
        while (source > 0)
        {
            var digit = source % 10;
            source /= 10;
            digits.Add(digit);
        }

        return digits;
    }    
    
    static bool IsPermutation(int n1, int n2)
    {
        var digits1 = GetDigits(n1).OrderBy(x=>x).ToList();
        var digits2 = GetDigits(n2).OrderBy(x=>x).ToList();
        
        if(digits1.Count != digits2.Count)
            return false;
        
        for (var i = 0; i < digits1.Count; i++)
        {
            if (digits1[i] != digits2[i])
            {
                return false;
            }
        }

        return true;
    }    

    // The code in this method is copied from here:
    // https://stackoverflow.com/questions/15743192/check-if-number-is-prime-number
    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0)  return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i+=2)
        {
            if (number % i == 0)  return false;
        }

        return true;        
    }
}
