using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    internal class Day21 : Day
    {

        private int[] StartingPositions = new int[2]; 

        private int FixedDieValue = 1; 

        //----------------------------------------------------------------------------------------------
        public override void ParseInput()
        {
            string inputFile = "inputs/21d.txt"; 
            List<string> lines = Util.ReadFileToLines(inputFile); 

            StartingPositions[0] = int.Parse( lines[0].Split(':')[1] ); 
            StartingPositions[1] = int.Parse( lines[1].Split(':')[1] ); 
        }

        //----------------------------------------------------------------------------------------------
        private int RollFixedDie()
        {
            int retValue = FixedDieValue; 
            ++FixedDieValue; 
            if (FixedDieValue > 100)
            {
                FixedDieValue -= 100; 
            }

            return retValue; 
        }

        private int RollFixedDie( int count )
        {
            int result = 0; 
            for (int i = 0; i < count; ++i)
            {
                result += RollFixedDie(); 
            }

            return result; 
        }

        //----------------------------------------------------------------------------------------------
        public override string RunA()
        {
            int[] place = new int[2]; 
            int[] scores = new int[2]; 
            int winningScore = 1000; 

            Int64 turnNumber = 0; 
            place[0] = StartingPositions[0];
            place[1] = StartingPositions[1]; 

            while ((scores[0] < winningScore) && (scores[1] < winningScore))
            {
                int playerTurn = (int)(turnNumber % 2L); 
                int roll = RollFixedDie(3); 

                place[playerTurn] += roll; 
                while (place[playerTurn] > 10)
                {
                    place[playerTurn] -= 10; 
                }
                scores[playerTurn] += place[playerTurn]; 

                ++turnNumber; 
            }

            Int64 player2Turns = turnNumber / 2; 
            Int64 player1Turns = turnNumber - player2Turns; 
            
            Int64 answer; 
            if (scores[0] >= 1000)
            {
                answer = scores[1] * turnNumber * 3L; 
            }
            else
            {
                answer = scores[0] * turnNumber * 3L; 
            }

            return answer.ToString(); 
        }

        //----------------------------------------------------------------------------------------------
        public override string RunB()
        {
            int[] diceDistribution = { 1, 3, 6, 7, 6, 3, 1 }; // dice rolls for the day

            int targetScore = 21; 
            ScorePotential[] potential = { new ScorePotential(), new ScorePotential() }; 
            potential[0].SetStartPosition( StartingPositions[0], targetScore ); 
            potential[1].SetStartPosition( StartingPositions[1], targetScore ); 

            int turnNumber = 0; 
            while (!potential[0].IsFinished(targetScore) && !potential[1].IsFinished(targetScore) )
            {
                int player = turnNumber % 2; 
                turnNumber++; 

                if (player == 0)
                {
                    potential[player].ApplyDay( diceDistribution, targetScore ); 
                }
            }

            int winningPlayer = (turnNumber - 1) % 2; 
            Int64 numUniverses = potential[winningPlayer].GetUniverseSum(); 
            return numUniverses.ToString();
        }
    }

    public class ScorePotential
    {
        // keeps track the number of universes have this score on a particular day
        private Int64[,] ScorePossibilities = new long[10,21]; 
        private Int64[] BoardPossibilities = new Int64[10]; 
        private Int64 FinishedUniverses = 0; 

        public void SetStartPosition( int pos, int targetScore )
        {
            BoardPossibilities[pos - 1] = 1; 

            // every board state has one possible universe at 0
            ScorePossibilities = new Int64[10,targetScore]; 
            ScorePossibilities[pos - 1,0] = 1; 
        }

        public void ApplyDay( int[] distribution, int targetScore )
        {
            Int64[] newBoardPossibilities = new Int64[10]; 
            Int64[,] newScores = new Int64[10,targetScore]; 

            // Update board state
            for (int j = 0; j < distribution.Length; ++j)
            {
                int roll = 3 + j; 
                Int64 probability = distribution[j]; 

                // update potential board state
                for (int i = 0; i < BoardPossibilities.Length; ++i)
                {
                    int newBoardPos = i + roll; 
                    if (newBoardPos >= 10)
                    {
                        newBoardPos -= 10; 
                    }

                    for (int scoreIdx = 0; scoreIdx < targetScore; ++scoreIdx) 
                    {
                        int newScore = scoreIdx + newBoardPos + 1; 
                        Int64 universesInThisState = ScorePossibilities[i,scoreIdx]; 
                        Int64 newUniverses = universesInThisState * probability;

                        if (newScore >= targetScore)
                        {
                            FinishedUniverses += newUniverses; 
                        }
                        else 
                        { 
                            newBoardPossibilities[newBoardPos] += newUniverses; 
                            newScores[newBoardPos, newScore] += newUniverses; 
                        }
                    }
                }
            }
            BoardPossibilities = newBoardPossibilities; 
            ScorePossibilities = newScores; 

            DebugCheck(); 
        }

        private bool DebugCheck()
        {
            Int64 boardPossibilityCount = BoardPossibilities.Sum(); 

            Int64 scoreCount = 0; 
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 21; ++j) 
                { 
                    scoreCount += ScorePossibilities[i,j]; 
                }
            }

            return boardPossibilityCount == scoreCount; 
        }

        public bool IsFinished( int targetScore )
        {
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < targetScore; ++j)
                {
                    if (ScorePossibilities[i,j] > 0)
                    {
                        return false; 
                    }
                }
            }
            return true; 
        }

        public Int64 GetUniverseSum()
        {
            return FinishedUniverses;
        }
    }
}
