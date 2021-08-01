using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Utils
{
    public class Printer : MonoBehaviour
    {
        private TextElement _textBox = null;
        private float _speed = 0f;

        public void Initialize(TextElement textComponent, int speed)
        {
            _textBox = textComponent;
            _speed = speed;
        }

        public void Print(string toPrint, bool clear = false)
        {
            if (clear) ClearTextbox();
            StartCoroutine(DelayPrint(toPrint));
        }

        public void ClearTextbox()
        {
            _textBox.text = string.Empty;
        }

        IEnumerator DelayPrint(string toPrint)
        {
            foreach (char letter in toPrint)
            {
                _textBox.text += letter;
                yield return new WaitForSeconds(_speed / 1000);
            }
            
            //draw the buttons here
            TextManager.finishPrintDelegate.Invoke();
            TextManager.finishPrintDelegate = delegate {  };
            
        }
    }
}