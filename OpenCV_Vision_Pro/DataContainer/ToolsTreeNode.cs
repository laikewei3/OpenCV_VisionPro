using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_Vision_Pro
{
    public class ToolsTreeNode : TreeNode, IDisposable
    {
        public ITool tool { get; set; }

        public ToolsTreeNode(ITool tool)
        {
            this.tool = tool;
        }

        public void Dispose()
        {
            tool?.Dispose();
        }
    }
}
