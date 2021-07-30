using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public class Printer
    {
        private GameObject _textBox = null;
        private Text _textComponent = null;
        private int _speed = 0;
        
        public Printer(Text textComponent, int speed, GameObject textBox = null)
        {
            _textBox = textBox;
            _textComponent = textComponent;
            _speed = speed;
        }

        public Task Print(string toPrint, bool clear = false)
        {
            if (_textBox)
            {
                _textBox.SetActive(true);
            }
            if (clear) ClearTextbox();
            return DelayPrint(toPrint, _speed);
        }

        public void ClearTextbox()
        {
            _textComponent.text = string.Empty;
        }

        async Task DelayPrint(string toPrint, int delay)
        {
            foreach (char letter in toPrint)
            {
                _textComponent.text += letter;
                await Task.Delay(delay);
            }
        }
    }
}
