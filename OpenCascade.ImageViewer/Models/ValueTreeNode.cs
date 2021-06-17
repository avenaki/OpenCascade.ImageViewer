using System.Windows.Forms;

namespace OpenCascade.ImageViewer.Models
{
    public interface ITreeNodeValue
    {
        public string NodeName { get; }
    }

    public class ValueTreeNode<TValue> : TreeNode where TValue : ITreeNodeValue
    {
        public ValueTreeNode(TValue entry) : base(entry.NodeName)
        {
            Entry = entry;
        }
        public TValue Entry { get; }
    }

}
