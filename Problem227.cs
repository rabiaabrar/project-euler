using System;
using System.Collections.Generic;
using System.Linq;

// This is a basic solution to Project Euler problem called "The Chase"
// It isn't really a full solution because I've just written code to play the game a number of times and take avg of number of turns from each game
// This would be correctly solved by use of statistics
// https://projecteuler.net/problem=227

// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
{    
    static Random random = new Random();
    
    static void Main(string[] args)
    {        
        int players = 100;
        int trials = 10000;
        int totalTurns = 0;
        //int[] results = new int[trials];
        
        for (int i=0; i<trials; i++)
        {            
            int p1 = 0, p2 = players/2;
            int turns = 0;
            
            while(p1!=p2)
            {
                //Roll two dice, one for each current player
                int d1 = RollDie();
                int d2 = RollDie();
                
                //Pass the dice to either left, right or keep it
                //The output from PassDie is ether -1, 0 or 1
                //We add "players" before taking modulus to account for a potential -1 value
                p1 = (p1+PassDie(d1)+players) % players;
                p2 = (p2+PassDie(d2)+players) % players;
                turns++;
                
                //Console.WriteLine("Dice: {0}, {1}. Players: {2}, {3}", d1, d2, p1, p2);
            }            
            //Record number of turns in an array to take average of in the end
            //results[i]=turns;
            totalTurns+=turns;
        }
        Console.WriteLine("Average turns: {0}", (double)totalTurns/trials);
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
