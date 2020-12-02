using System;
using System.Collections.Generic;
using System.Text;

namespace LifeGame
{
    class Cell
    {

        public bool _isAlive
        {
            get {return isAlive; }
            set { isAlive = value; }
        }

        private bool isAlive;

        private bool nextState;
        public bool _nextState
        {
            get { return nextState; }
            set { nextState = value; }
        }

        public Cell(bool state)
        {
            _isAlive = state;
        }

        public void ComeAlive()
        {
            _nextState = true;
        }

        public void PassAway()
        {
            _nextState = false;
        }

        public void Update()
        {
            _isAlive = _nextState;
        }

    }
}
