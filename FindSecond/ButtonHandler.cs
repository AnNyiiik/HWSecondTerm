using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSecond
{
    internal class ButtonHandler
    {
        private int _PreviousButton;
        private int _LastButton;

        public void Click(int button)
        {
            _PreviousButton = _LastButton;
            _LastButton = button;
        }

        public bool IsMatch()
        {
            if (_PreviousButton == _LastButton && _LastButton != 0)
            {
                _LastButton = 0;
                _PreviousButton = 0;
                return true;
            }
            return false;
        }
    }
}
