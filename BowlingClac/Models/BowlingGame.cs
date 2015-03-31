using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BowlingCalc.Models
{
    public class BowlingGame
    {
        private int[] _numOfRolls = new int[21];
        private int _currentRollIdnex = 0;

        public void Roll(int numberOfPins)
        {
            if (_currentRollIdnex > 20)
                throw new InvalidOperationException("The game is already over mate. Start a new game :)");

                _numOfRolls[_currentRollIdnex] = numberOfPins;
                _currentRollIdnex++;
        }

        public int CalculateScore()
        {
            int score = 0;
            int frameIndex = 0;
            for (var frame = 0; frame < 10; frame++)
            {
                int frameScore;
                if (IsStrikeFrame(frameIndex))
                {
                    frameScore = 10 + GrantStrikeBonus(frameIndex);
                    frameIndex++;
                }
                else
                {
                    frameScore = SumOfFrame(frameIndex);
                    if (IsSpareFrame(frame))
                    {
                        frameScore += GrantSpareBonus(frameIndex);
                    }

                    frameIndex += 2;
                }

                score += frameScore;
            }

            return score;
        }

        private int SumOfFrame(int frameIndex)
        {
            return _numOfRolls[frameIndex] + _numOfRolls[frameIndex + 1];
        }

        private int GrantSpareBonus(int frameIndex)
        {
            int spareBonus = _numOfRolls[frameIndex + 2];
            return spareBonus;
        }

        private int GrantStrikeBonus(int frameIndex)
        {
            var strikeBonus = _numOfRolls[frameIndex + 1] + _numOfRolls[frameIndex + 2];
            return strikeBonus;
        }

        private bool IsStrikeFrame(int frameIndex)
        {
            return _numOfRolls[frameIndex] == 10;
        }

        private bool IsSpareFrame(int frame)
        {
            return _numOfRolls[frame] + _numOfRolls[frame + 1] == 10;
        }
    }
}