using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file_explorer
{
    public partial class Form1 : Form
    {
        ListBox SelectedListBox;
        ListBox DestinationListBox;
        TextBox SelectedTextBox;
        DriveInfo[] Drives;
        readonly String ThisPC = "This PC";
        readonly String Root = @"\.";
        readonly String Parent = @"\..";
        DirectoryInfo LeftListDirectory;
        DirectoryInfo RightListDirectory;
        DirectoryInfo SelectedListDirectory;
        DirectoryInfo DestinationListDirectory;
        FileInfo LastSelected;
        String selectedText;
        String RightPath;
        String LeftPath;
        public Form1()
        {
            InitializeComponent();
            this.Text = "File Explorer";
            RightList.Click += AdjustSelDes;
            RightList.DoubleClick += SelectItemHandle;
            RightDirectory.KeyDown += keyDownTextBox;

            MoveToleftBtn.Click += MoveToleftBtnHandler;
            MoveToRightBtn.Click += MoveToRightBtnHandler;

        }

        private void MoveToRightBtnHandler(Object obj, EventArgs e)
        {
            SelectedListBox = LeftList;
            SelectedListDirectory = LeftListDirectory;
            SelectedTextBox = LeftDirectory;
            DestinationListBox = RightList;
            DestinationListDirectory = RightListDirectory;
            //Desti = RightDirectory;
            MoveAndUpdateLists(obj, e);
        }

        private void MoveToleftBtnHandler(Object obj, EventArgs e)
        {
            SelectedListBox = RightList;
            SelectedListDirectory = RightListDirectory;
            SelectedTextBox = RightDirectory;
            DestinationListBox = LeftList;
            DestinationListDirectory = LeftListDirectory;
            MoveAndUpdateLists(obj, e);
        }
        private void MoveHandler(Object obj, EventArgs e)
        {
            if (ValidDirectory())
            {
                if (SelectedListBox.SelectedIndex > -1)
                {
                    try
                    {
                        Console.WriteLine("Moving-----------");

                        object item = SelectedListBox.Items[SelectedListBox.SelectedIndex];
                        if (item.GetType() == typeof(DirectoryInfo))
                        {
                            Console.WriteLine("Moving a Folder");
                            ((DirectoryInfo)item).MoveTo(DestinationListDirectory.FullName);
                            // CopyFolder(((DirectoryInfo)item), DestinationListDirectory.FullName);

                        }
                        else if (item.GetType() == typeof(FileInfo))
                        {
                            Console.WriteLine("Moving a file");
                            FileInfo file = (FileInfo)item;
                            Console.WriteLine(DestinationListDirectory.FullName + @"\" + file.Name);
                            file.MoveTo(DestinationListDirectory.FullName + @"\" + file.Name);
                            Console.WriteLine("Moving Completed");

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }
        private void MoveAndUpdateLists(Object obj, EventArgs e)
        {

            MoveHandler(obj, e);
            ListDirectories(SelectedListBox, SelectedListDirectory.FullName, false);
            ListDirectories(DestinationListBox, DestinationListDirectory.FullName, false);
        }




        private void AdjustSelDes(object sender, EventArgs e)
        {
            Console.WriteLine("AdjustSelDes");
            if (sender.Equals(this.LeftList))
            {
                SelectedListBox = LeftList;
                SelectedListDirectory = LeftListDirectory;
                //Console.WriteLine(SelectedListDirectory.ToString());

                DestinationListBox = RightList;
                DestinationListDirectory = RightListDirectory;
            }
            else if (sender.Equals(this.RightList))
            {
                SelectedListBox = RightList;
                SelectedListDirectory = RightListDirectory;
                DestinationListBox = LeftList;
                DestinationListDirectory = LeftListDirectory;
            }
        }

        private void ListDrives(ListBox LS, TextBox TS)
        {
            Drives = DriveInfo.GetDrives();
            LS.Items.Clear();
            foreach (var drive in Drives)
            {
                LS.Items.Add(drive);
                TS.Text = ThisPC;
                //Console.WriteLine(drive.Name);//imaginary drives also appears
            }

            if (LS.Equals(this.LeftList))
            {
                LeftListDirectory = null;
            }
            else if (LS.Equals(this.RightList))
            {
                RightListDirectory = null;
            }
            AdjustSelDes(LS, null);
        }

        void SelectItemHandle(object sender, EventArgs e)
        {
            //Console.WriteLine(sender);
            //Console.WriteLine(e);
            if (sender.Equals(this.LeftList))
            {
                SelectedListBox = this.LeftList;
                SelectedTextBox = LeftDirectory;
                DestinationListBox = this.RightList;
                //Console.WriteLine("Left");
            }
            else if (sender.Equals(this.RightList))
            {
                //Console.WriteLine("Right");
                SelectedListBox = this.RightList;
                SelectedTextBox = RightDirectory;
                DestinationListBox = this.LeftList;
            }
            //if(selectedlist = ListBox.left)
            //{

            //}

            if (SelectedListBox.SelectedIndex > -1)
            {
                //DirectoryInfo x = ((DriveInfo)(LeftList.Items[LeftList.SelectedIndex]));
                object item = SelectedListBox.Items[SelectedListBox.SelectedIndex];
                Console.WriteLine("the type is : " + item.GetType());
                //check first if it is a drive or directory(folder) or file
                // Console.WriteLine(item.GetType());
                if (item.GetType() == typeof(DriveInfo))
                {
                    //Console.WriteLine("DriveInfo");
                    if (((DriveInfo)item).IsReady)
                    {
                        selectedText = ((DriveInfo)item).Name;
                        ListDirectories(SelectedListBox, selectedText);

                    }
                    else
                    {
                        MessageBox.Show("Device is not ready");
                    }
                }
                else if (item.GetType() == typeof(DirectoryInfo))
                {
                    //Console.WriteLine("DirectoryInfo");
                    selectedText = ((DirectoryInfo)item).FullName;
                    //Console.WriteLine(selectedText);
                    ListDirectories(SelectedListBox, selectedText);
                }
                else if (item.GetType() == typeof(FileInfo))
                {
                    //Console.WriteLine("FileInfo");
                    selectedText = ((FileInfo)item).FullName;
                    //Console.WriteLine(selectedText);
                    FileAction(selectedText);
                }
                else if (SelectedListBox.SelectedIndex == 0)//Root Directory
                {
                    ListDirectories(SelectedListBox, SelectedListDirectory.Root.FullName);
                }
                else if (SelectedListBox.SelectedIndex == 1)//Parent Directory
                {
                    if (SelectedListDirectory.Parent != null)
                    {
                        ListDirectories(SelectedListBox, SelectedListDirectory.Parent.FullName);
                    }
                }

                //Console.WriteLine(x);
            }
            else
            {

            }
        }

        private void ListDirectories(ListBox listBox, string listBoxDirectory, Boolean updateDirectory = true)
        {
            try
            {
                SelectedTextBox.Text = listBoxDirectory;
                DirectoryInfo x = new DirectoryInfo(listBoxDirectory);
                DirectoryInfo[] directories = x.GetDirectories();
                FileInfo[] files = x.GetFiles();
                listBox.Items.Clear();
                listBox.Items.Add(@"\.");
                listBox.Items.Add(@"\..");
                foreach (var directory in directories)
                {
                    listBox.Items.Add(directory);
                    //Console.WriteLine(directory.Name);//imaginary drives also appears
                }
                foreach (var file in files)
                {
                    listBox.Items.Add(file);
                }

                if (updateDirectory)
                {
                    if (SelectedListBox.Equals(this.LeftList))
                    {
                        LeftListDirectory = x;
                        SelectedListDirectory = x;
                    }
                    else if (SelectedListBox.Equals(this.RightList))
                    {
                        RightListDirectory = x;
                        SelectedListDirectory = x;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void keyDownTextBox(object sender, KeyEventArgs e)
        {
            //Console.WriteLine(e.KeyValue);
            //Console.WriteLine(e.KeyCode);
            if (e.KeyCode == Keys.Enter)
            {
                string path;
                if (sender.Equals(this.LeftDirectory))
                {
                    SelectedListBox = this.LeftList;
                    SelectedTextBox = LeftDirectory;
                    DestinationListBox = this.RightList;

                }
                else if (sender.Equals(this.RightDirectory))
                {

                    SelectedListBox = this.RightList;
                    SelectedTextBox = RightDirectory;
                    DestinationListBox = this.LeftList;
                }
                path = SelectedTextBox.Text;
                try
                {
                    if (ThisPC.Equals(path))
                    {
                        ListDrives(SelectedListBox, SelectedTextBox);
                    }
                    else
                    {
                        FileInfo file = new FileInfo(path);
                        if (file.Exists)
                        {
                            //ListDirectories(file.DirectoryName);
                            //SelectedTextBox.Text = file.DirectoryName;
                            FileAction(path);
                        }
                        else
                        {
                            DirectoryInfo folder = new DirectoryInfo(path);
                            if (folder.Exists)
                            {
                                SelectedTextBox.Text = folder.Name;
                                ListDirectories(SelectedListBox, path);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Illegal Path : " + ex.Message);//can be raise if you enter : in path
                }
            }
        }

        private static void FileAction(string path)
        {
            MessageBox.Show("The following file " + path + " -----Exists");
        }

        private void CopyToTheOtherSide_Click(object sender, EventArgs e)
        {


            if (ValidDirectory())
            {
                Console.WriteLine("Both are not This PC");
                if (SelectedListBox.SelectedIndex > -1)
                {
                    Console.WriteLine("item for copying");
                    object item = SelectedListBox.Items[SelectedListBox.SelectedIndex];
                    if (item.GetType() == typeof(DirectoryInfo))
                    {
                        Console.WriteLine("Copying a Folder");
                        CopyFolder(((DirectoryInfo)item), DestinationListDirectory.FullName);

                    }
                    else if (item.GetType() == typeof(FileInfo))
                    {
                        Console.WriteLine("Copying a file");

                        FileInfo file = (FileInfo)item;
                        file.CopyTo(DestinationListDirectory.FullName + @"\" + file.Name);
                        Console.WriteLine("Copying Completed");

                    }
                    ListDirectories(DestinationListBox, DestinationListDirectory.FullName);
                }
            }
        }

        private bool ValidDirectory()
        {
            return SelectedListDirectory != null && DestinationListDirectory != null;
        }

        private void CopyFolder(DirectoryInfo source, String destinationstring)
        {
            String s = destinationstring + @"\" + source.Name;
            DirectoryInfo currentDirectory = new DirectoryInfo(s);
            currentDirectory.Create();
            DirectoryInfo[] directories = source.GetDirectories();
            foreach (DirectoryInfo dir in directories)
            {
                CopyFolder(dir, s);
            }
            FileInfo[] files = source.GetFiles();
            foreach (FileInfo file in files)
            {
                String destinationPath = destinationstring + @"\" + source.Name + @"\" + file.Name;
                try
                {
                    if (File.Exists(destinationPath))
                    {
                        //implement your Confirmation here
                        Console.WriteLine("File Exists {0} : 0 for ignoring ,any other number for overwriting");
                        int Confirm;
                        int.TryParse(Console.ReadLine(), out Confirm);
                        if (Confirm != 0)
                        {
                            file.CopyTo(destinationPath, true);
                        }
                    }
                    else
                    {
                        file.CopyTo(destinationPath);
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void DeleteLastSelected_Click(object sender, EventArgs e)
        {
            if (SelectedListBox.SelectedIndex > -1)
            {
                Console.WriteLine("item for Deleting");
                object item = SelectedListBox.Items[SelectedListBox.SelectedIndex];
                if (item.GetType() == typeof(DirectoryInfo))
                {
                    Console.WriteLine("Deleting a Folder");
                    ((DirectoryInfo)item).Delete();

                }
                else if (item.GetType() == typeof(FileInfo))
                {
                    Console.WriteLine("Deleting a file");

                    FileInfo file = (FileInfo)item;
                    file.Delete();
                    Console.WriteLine("Deleting Completed");
                    

                }
                Task.Delay(100);
                ListDirectories(SelectedListBox, SelectedListDirectory.FullName);
            }
        }
    }
}
