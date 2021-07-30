using System;
using NodeEditor;
using UnityEngine;
using XNode;

namespace Nodes
{
    [CreateAssetMenu(menuName = "Dialogue graph"), RequireNode(typeof(Start))]
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

        [NonSerialized] public GraphController Controller = null;

        public void Unload()
        {
            Controller.graph = graphOnReset;

            graphOnReset = null;
            _currentNode = null;
            
            Destroy(Controller.textBoxInstance);
        }

        public void Load(GraphController runner)
        {
            Controller = runner;
            
            CurrentNode = (State) nodes.Find(node => node.GetType() == typeof(Start));
            CurrentNode = CurrentNode.GetNext();
        }

        public override string ToString()
        {
            return name;
        }
    }
}
