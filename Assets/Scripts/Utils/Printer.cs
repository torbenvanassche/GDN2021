using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Utils
{
    public class Printer
    {
        private TextElement _textBox = null;
        private int _speed = 0;
        
        public Printer(TextElement textComponent, int speed)
        {
            _textBox = textComponent;
            _speed = speed;
        }

        public Task Print(string toPrint, bool clear = false)
        {
            if (clear) ClearTextbox();
            return DelayPrint(toPrint, _speed);
        }

        public void ClearTextbox()
        {
            _textBox.text = string.Empty;
        }

        async Task DelayPrint(string toPrint, int delay)
        {
            foreach (char letter in toPrint)
            {
                _textBox.text += letter;
                await Task.Delay(delay);
            }
        }
    }
}
