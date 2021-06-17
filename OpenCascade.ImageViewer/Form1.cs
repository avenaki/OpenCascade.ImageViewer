using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using OpenCascade.ImageViewer.Models;

namespace OpenCascade.ImageViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.fileToolStripMenuItem.Click += FileToolStripMenuItem_Click;
        }

        private void FileToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var path = folderBrowserDialog1.SelectedPath;
                var entry = BuildTreeWithRoot(path, true);
                BuildTreeUI(entry);
            }
        }

        private void BuildTreeUI(FileSystemEntryNode entry)
        {
            treeView1.Nodes.Add(Convert(entry));
        }

        private TreeNode Convert(FileSystemEntryNode entry)
        {
            var node = new ValueTreeNode<FileSystemEntry>(entry);

            if (entry.Childs != null)
                node.Nodes.AddRange(entry.Childs.Select(Convert).ToArray());

            return node;
        }

        private FileSystemEntryNode BuildTreeWithRoot(string path, bool isDir)
        {
            var directoryInfo = new DirectoryInfo(path);
            var dirs = directoryInfo.EnumerateDirectories();
            var files = directoryInfo.EnumerateFiles();
            var childs = new List<FileSystemEntryNode>();

            childs.AddRange(files.Select(f => new FileSystemEntryNode()
            {
                Childs = null,
                Name = f.Name,
                Path = f.Directory.FullName,
                Type = EntryType.File
            }));

            childs.AddRange(dirs.Select(d => BuildTreeWithRoot(d.FullName, true)).AsEnumerable());

            var entry = new FileSystemEntryNode
            {
                Name = directoryInfo.Name,
                Path = path,
                Type = isDir ? EntryType.Directory : EntryType.File,
                Childs = childs
            };

            return entry;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var currentNode = e.Node as ValueTreeNode<FileSystemEntry>;

            if(currentNode.Entry.Type == EntryType.Directory)
            {
                return;
            }

            pictureBox1.Image = Image.FromFile(currentNode.Entry.FullPath);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
