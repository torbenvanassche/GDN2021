using System.Collections;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Utils
{
    public class Printer : MonoBehaviour
    {
        private TextElement _textBox = null;
        private int _speed = 0;

        public void Initialize(TextElement textComponent, int speed)
        {
            _textBox = textComponent;
            _speed = speed;
        }

        public Task Print(string toPrint, bool clear = false)
        {
            if (clear) ClearTextbox(); 
            return DelayPrint(toPrint);
        }

        private void ClearTextbox()
        {
            _textBox.text = string.Empty;
        }

        async Task DelayPrint(string toPrint)
        {
            foreach (char letter in toPrint)
            {
                _textBox.text += letter;
                await UniTask.DelayFrame(_speed);
            }
        }
    }
}