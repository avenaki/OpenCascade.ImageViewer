using OpenCascade.ImageViewer.Models.Abstract;
using System.Windows.Forms;

namespace OpenCascade.ImageViewer.Models.Values
{
    public class ValueTreeNode<TValue> : TreeNode where TValue : ITreeNodeValue
    {
        public ValueTreeNode(TValue entry) : base(entry.NodeName)
        {
            Entry = entry;
        }
        public TValue Entry { get; }
    }

}
