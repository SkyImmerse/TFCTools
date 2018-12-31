using System;
using System.Collections.Generic;
using System.IO;

namespace Game.DAO
{
    public enum AnimationPhase
    {
        AnimPhaseAutomatic = -1,
        AnimPhaseRandom = 254,
        AnimPhaseAsync = 255,
    }

    public enum AnimationDirection
    {
        AnimDirForward = 0,
        AnimDirBackward = 1
    }

    public class Animator
    {
        public Animator()
        {
            _mAnimationPhases = 0;
            _mStartPhase = 0;
            _mLoopCount = 0;
            _mAsync = false;
            _mCurrentDuration = 0;
            _mCurrentDirection = AnimationDirection.AnimDirForward;
            _mCurrentLoop = 0;
            _mLastPhaseTicks = 0;
            _mIsComplete = false;
            _mPhase = 0;
        }

        public void Unserialize(int animationPhases, BinaryReader fin)
        {
            _mAnimationPhases = animationPhases;
            _mAsync = fin.ReadByte() == (byte) 0;
            _mLoopCount = fin.ReadInt32();
            _mStartPhase = fin.ReadSByte();

            for (int i = 0; i < _mAnimationPhases; ++i)
            {
                int minimum = (int) fin.ReadUInt32();
                int maximum = (int) fin.ReadUInt32();
                _mPhaseDurations.Add(new Tuple(minimum, maximum));
            }

            _mPhase = GetStartPhase();

        }

        public void SetPhase(int phase)
        {
            if (_mPhase == phase)
                return;
        }

        private int random_range(int i, int mAnimationPhases)
        {
            return 0;
        }
        public int GetStartPhase()
        {
            if (_mStartPhase > -1)
                return _mStartPhase;
            return (int) random_range(0, (int) _mAnimationPhases);
        }

        public int GetAnimationPhases()
        {
            return _mAnimationPhases;
        }

        public bool IsAsync()
        {
            return _mAsync;
        }

        public bool IsComplete()
        {
            return _mIsComplete;
        }

        public void ResetAnimation()
        {
            _mIsComplete = false;
            _mCurrentDirection = AnimationDirection.AnimDirForward;
            _mCurrentLoop = 0;
            SetPhase((int) AnimationPhase.AnimPhaseAutomatic);
        }

        private int GetPingPongPhase()
        {
            int count = 0; // (m_currentDirection == ((int)AnimationDirection.AnimDirForward != 0 ? 1 : -1);
            int nextPhase = _mPhase + count;
            if (nextPhase < 0 || nextPhase >= _mAnimationPhases)
            {
                //m_currentDirection = m_currentDirection == ((int) AnimationDirection.AnimDirForward) != 0
                //  ? AnimationDirection.AnimDirBackward
                //: AnimationDirection.AnimDirForward;
                count *= -1;
            }
            return _mPhase + count;
        }

        private int GetLoopPhase()
        {
            int nextPhase = _mPhase + 1;
            if (nextPhase < _mAnimationPhases)
                return nextPhase;

            if (_mLoopCount == 0)
                return 0;

            if (_mCurrentLoop < (_mLoopCount - 1))
            {
                _mCurrentLoop++;
                return 0;
            }

            return _mPhase;
        }

        private int GetPhaseDuration(int phase)
        {
//            Tuple data = m_phaseDurations[phase];
//            int min = std.get < 0 > (data);
//            int max = std.get < 1 > (data);
//            if (min == max)
//                return min;
            return 0; // (int) Random.random_range((int) min, (int) max);
        }


        public int _mAnimationPhases;
        private int _mStartPhase;
        private int _mLoopCount;
        private bool _mAsync;
        private List<Tuple> _mPhaseDurations = new List<Tuple>();

        private int _mCurrentDuration;
        private AnimationDirection _mCurrentDirection;
        private int _mCurrentLoop;

        private Int64 _mLastPhaseTicks = new Int64();
        private bool _mIsComplete;

        private int _mPhase;
    }

    public class Tuple
    {
        private int _minimum;
        private int _maximum;

        public Tuple(int minimum, int maximum)
        {
            this._minimum = minimum;
            this._maximum = maximum;
        }
    }
}