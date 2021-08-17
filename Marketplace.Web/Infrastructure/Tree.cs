using System.Collections.Generic;
using System.Linq;

namespace Marketplace.Web.Infrastructure
{
    public interface ITree<T>
    {
        T Data { get; }
        ITree<T> Parent { get; }
        ICollection<ITree<T>> Children { get; }
        bool IsRoot { get; }
        bool IsLeaf { get; }
        int Level { get; }
    }
    
    public class Tree<T> : ITree<T>
    {
        public T Data { get; }
        public ITree<T> Parent { get; private set; }
        public ICollection<ITree<T>> Children { get; }
        public bool IsRoot => Parent == null;
        public bool IsLeaf => Children.Count == 0;
        public int Level => IsRoot ? 0 : Parent.Level + 1;
        private Tree(T data)
        {
            Children = new LinkedList<ITree<T>>();
            Data = data;
        }
        public static Tree<T> FromLookup(ILookup<T, T> lookup)
        {
            var rootData = lookup.Count == 1 ? lookup.First().Key : default(T);
            var root = new Tree<T>(rootData);
            root.LoadChildren(lookup);
            return root;
        }
        private void LoadChildren(ILookup<T, T> lookup)
        {
            foreach (var data in lookup[Data])
            {
                var child = new Tree<T>(data) {Parent = this};
                Children.Add(child);
                child.LoadChildren(lookup);
            }
        }
    }
}