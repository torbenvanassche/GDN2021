using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nodes;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace NodeEditor
{
    public class Text : State
    {
        [HideLabel] public CharacterData character;
        
        [HideLabel, Multiline(3)] public string text;
        public static UnityEngine.UI.Text OutputField = null;

        private List<GameObject> buttons = new List<GameObject>();

        public override async Task<State> OnEnter()
        {
            OutputField = Graph.Controller.textBoxInstance.GetComponentInChildren<UnityEngine.UI.Text>();
            await new Printer(OutputField, 100).Print(text, true);

            await base.OnEnter();
            AddUserInterface(GetReplies());

            return null;
        }

        private List<Reply> GetReplies()
        {
            var replies = new List<Reply>();

            foreach (var t in GetOutputNodes().ToList())
            {
                if (t is Reply reply)replies.Add(reply);
                else replies.Add(t.GetNext() as Reply);
            }

            return replies;
        }

        private void AddUserInterface(List<Reply> replies)
        {
            buttons.Clear();
            foreach (var reply in replies)
            {
                reply.GenerateButton();
                buttons.Add(reply.button);
                reply.button.GetComponent<Button>().onClick.AddListener(() =>
                {
                    foreach (var button in buttons)
                    {
                        Destroy(button);
                    }

                    buttons.Clear();
                });
            }
        }
    }
}
