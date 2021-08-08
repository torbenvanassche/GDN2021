using System;
using NodeEditor;
using UnityEngine;
using XNode;

namespace Nodes
{
    [CreateAssetMenu(menuName = "Custom/Graph"), RequireNode(typeof(Start))]
    public class Graph : NodeGraph
    {
        [NonSerialized] public Graph graphOnReset = null;
        
        private State _currentNode = null;
        public State CurrentNode
        {
            get => _currentNode;
            set
            {
                if (value == null)
                {
                    Unload();
                }
                
                _currentNode = value;

                if (_currentNode)
                {
#pragma warning disable 4014
                    _currentNode.OnEnter();
#pragma warning restore 4014
                }
            }
        }

        public void Unload()
        {
            _currentNode = null;
            TextManager.Instance.doc.rootVisualElement.visible = false;
            Controls.Instance.Input.Player.LeftMouse.Disable();
        }

        public void Load()
        {
            CurrentNode = (State) nodes.Find(node => node.GetType() == typeof(Start));
            CurrentNode = CurrentNode.GetNext();
            
            Controls.Instance.Input.Player.LeftMouse.Enable();

            Manager.Instance.activeGraph = this;

            //enable printfield
            TextManager.Instance.doc.rootVisualElement.visible = true;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
