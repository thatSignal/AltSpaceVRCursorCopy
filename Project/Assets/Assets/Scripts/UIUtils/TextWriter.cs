using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UIUtils
{
    public class TextWriter : MonoBehaviour
    {
        public Text field;
        public string SavedText { get { return _cachedText; } }

        private string _cachedText;

        void Awake()
        {

            _cachedText = field.text;

        }

        public void Write(string message, float letterDelay, string prefix = "", string suffix = "", float initialDelay = 0.0f)
        {
            TextWriterArgs args = new TextWriterArgs();
            args.message = message;
            args.letterDelay = letterDelay;
            args.prefix = prefix;
            args.suffix = suffix;
            args.initialDelay = initialDelay;

            StopCoroutine("WriteMessage");
            StartCoroutine("WriteMessage", args);
        }

        public void Clear()
        {
            field.text = "";
        }

        private IEnumerator WriteMessage(TextWriterArgs args)
        {
            Clear();

            if (args.initialDelay > 0.0f)
            {
                yield return new WaitForSeconds(args.initialDelay);
            }

            string targetMessage = args.prefix + args.message + args.suffix;

            while (field.text.Length < targetMessage.Length)
            {
                for (int i = 0; i < targetMessage.Length; i++)
                {
                    field.text += targetMessage[i];
                    yield return new WaitForSeconds(args.letterDelay);
                }
            }   

        }

    }

}

