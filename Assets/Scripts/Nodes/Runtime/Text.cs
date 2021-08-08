using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nodes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NodeEditor
{
    public class Text : State
    {
        [HideLabel] public CharacterData character;
        
        [HideLabel, Multiline(3)] public string text;

        private List<GameObject> buttons = new List<GameObject>();

        public override async Task<State> OnEnter()
        {
            TextManager.Instance.UpdateUI(character, text, GetReplies());
            await base.OnEnter();

            return null;
        }

        public override State GetNext()
        {
            var nodes = GetOutputNodes().ToList();
            if (nodes.Count > 0)
            {
                return nodes[0];
            }

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
    }
}
