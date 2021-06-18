using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using OpenCascade.ImageViewer.Models.Concrete;
using OpenCascade.ImageViewer.View.Abstract;
using OpenCascade.ImageViewer.Controllers;
using OpenCascade.ImageViewer.Models.Abstract;
using OpenCascade.ImageViewer.Controllers.Concrete;
using OpenCascade.ImageViewer.Models.Values;

namespace OpenCascade.ImageViewer
{
    public partial class MainView : Form, IFileSystemView, IPictureView
    {
        private IFileSystemControl FSControl = new FileSystemControl();
        private IFileSystemModel FSModel = new FileSystemModel();

        private IPictureControl PictureControl = new PictureControl();
        private IPictureModel PictureModel = new OpenCascade.ImageViewer.Models.Concrete.PictureModel();

        public MainView()
        {
            InitializeComponent();
            this.fileToolStripMenuItem.Click += FileToolStripMenuItem_Click;
            WireUp(FSControl, PictureControl, PictureModel, FSModel);
        }

        public void WireUp(IFileSystemControl fileControl,
                           IPictureControl pictureControl,
                           IPictureModel pictureModel,
                           IFileSystemModel fileModel)
        {
            if (FSModel != null)
            {
                FSModel.RemoveObserver(this);
            }
            FSModel = fileModel;
            FSControl = fileControl;
            FSControl.SetModel(FSModel);
            FSControl.SetView(this);
            FSModel.AddObserver(this);

            PictureModel = pictureModel;
            PictureControl = pictureControl;
            PictureControl.SetModel(pictureModel);
            PictureControl.SetView(this);
            PictureModel.AddObserver(this);



        }

        private void FileToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var path = folderBrowserDialog1.SelectedPath;
                FSControl.RequestBuildTree(path);
            }
        }

        private void BuildTreeUI(FileSystemEntryNode entry)
        {
            treeView1.Nodes.Add(Convert(entry));
        }

        private TreeNode Convert(FileSystemEntryNode entry)
        {
            var node = new ValueTreeNode<FileSystemEntityModel>(entry);

            if (entry.Childs != null)
                node.Nodes.AddRange(entry.Childs.Select(Convert).ToArray());

            return node;
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var currentNode = e.Node as ValueTreeNode<FileSystemEntityModel>;

            if(currentNode.Entry.Type == EntryType.Directory)
            {
                return;
            }

            PictureControl.RequestLoadPicture(currentNode.Entry.FullPath);
            showPicture(PictureModel);
        }

        public void Update(IFileSystemModel paramModel)
        {
            
        }

        public void showTreeFolder(IFileSystemModel model)
        {
            BuildTreeUI(model.RootNode);
        }

        public void Update(IPictureModel paramModel)
        {

        }

        public void showPicture(IPictureModel model)
        {
            pictureBox1.Image = model.Image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
