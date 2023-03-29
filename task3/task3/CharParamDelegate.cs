using System;

namespace Task3
{
    internal class CharParamDelegate : Delegate
    {
        private Action<char> appendTextToTextBox;

        public CharParamDelegate(Action<char> appendTextToTextBox)
        {
            this.appendTextToTextBox = appendTextToTextBox;
        }
    }
}