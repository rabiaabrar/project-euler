using System;
using System.Collections.Generic;
using System.Linq;

// This is a basic solution to Project Euler problem called "The Chase"
// https://projecteuler.net/problem=227

// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
{    
    static Random random = new Random();
    
    static void Main(string[] args)
    {        
        int players = 4;
        int p1=1, p2=players/2+1;
        int turns =0;  
        
        while(p1!=p2)
        {
            int d1 = RollDie();
            int d2 = RollDie();
            p1 = (p1+PassDie(d1))%players;
            p2 = (p2+PassDie(d2))%players;            
            
            Console.WriteLine("Dice: {0}, {1}. Players: {2}, {3}", d1, d2, p1, p2);
            
            turns++;            
        }
        Console.WriteLine("Turns: {0}", turns);
        Console.WriteLine("That's all folks.");
    }
    
    static int RollDie()
    {
        return random.Next(1,6);
    }
    
    static int PassDie(int dieRollResult)
    {
        if(dieRollResult==1)
            return -1;
        if(dieRollResult==6)
            return 1;
        else return 0;
    }
}

