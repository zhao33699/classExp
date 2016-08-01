using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;


/**
 *20160723 增加读取上次数据配置；修正发布文件夹中名称时间格式错误；修正复制文件为0kb的错误
 *20160801 针对idea拖拽时，开头为file:/ 的问题，做出相应修改
 */
namespace classExp
{
    public partial class Form1 : Form
    {
        String formName = "classExp_160801";

        //1.声明自适应类实例
        AutoSizeFormClass asc = new AutoSizeFormClass();
        String iniPath = "d:\\classExp.ini";
        String keyProDir = "keyProDir";
        String keyClassDir = "keyClassDir";
        String keyRelaseDir = "keyRelaseDir";
        String keyIgnoreDir = "keyIgnoreDir";
        String keyRelaseList = "keyRelaseList";

        public void writeIniData(){
            FileUtil.IOHelper.CreateFile(iniPath);
            WriteIniData("expSection", keyProDir, txtProDir.Text, iniPath);
            WriteIniData("expSection", keyClassDir, txtClassDir.Text, iniPath);
            WriteIniData("expSection", keyRelaseDir, txtReleaseDir.Text, iniPath);
            WriteIniData("expSection", keyIgnoreDir, txtIgnore.Text, iniPath);
            WriteIniData("expSection", keyRelaseList, txtList.Text.Replace("\r\n","$_$"), iniPath);
        }
      
        public Form1()
        {
            InitializeComponent();
        }
        //2. 为窗体添加Load事件，并在其方法Form1_Load中，调用类的初始化方法，记录窗体和其控件的初始位置和大小
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = formName;

            if (new FileInfo(iniPath).Exists) {
                txtProDir.Text = ReadIniData("expSection", keyProDir, "", iniPath);
                txtClassDir.Text = ReadIniData("expSection", keyClassDir, "", iniPath);
                txtReleaseDir.Text = ReadIniData("expSection", keyRelaseDir, "", iniPath);
                txtIgnore.Text = ReadIniData("expSection", keyIgnoreDir, "", iniPath);
                txtList.Text = ReadIniData("expSection", keyRelaseList, "", iniPath).Replace("$_$", "\r\n");
            
            }
        }
        //3.为窗体添加SizeChanged事件，并在其方法Form1_SizeChanged中，调用类的自适应方法，完成自适应
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }


        private void button1_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog openFileDialog = new FolderBrowserDialog();

         
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

               String fName = openFileDialog.SelectedPath;

               txtProDir.Text= fName;
            }
        }

        public static void makeDir(String dirParam, bool isFile)
        {
            
            if (isFile) {
                FileInfo file = new FileInfo(dirParam);
                DirectoryInfo dir = file.Directory;
               
                //创建父目录文件夹
                FileUtil.IOHelper.CreateDir(file.DirectoryName);
                FileUtil.IOHelper.CreateFile(dirParam);
                 
            }
            else
            {
                FileUtil.IOHelper.CreateDir(dirParam);
                 
            }
            
        }

        public static void Copy(FileInfo oldfile, String newPath)
        {
            try
            {
                
                // File oldfile = new File(oldPath);
                if (oldfile.Exists)
                { 
                    oldfile.CopyTo( newPath  ,true);
                }     
            }
            catch (Exception e)
            {
                MessageBox.Show("Message:copyfile  failed:" +e.Message  );
            }
        }

       
        

        public static void contentToTxt(String filePath, String content)
        {
            String s1 = "";//内容更新  
            try
            {
               

                FileUtil.IOHelper.CreateFile(filePath);
                FileInfo f = new FileInfo(filePath);

                s1 = content;
                StreamWriter sw= f.AppendText();
                sw.Write(s1);

                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Message:contentToTxt  failed:" + e.Message);

            }
        }

       
        
        private void btnRelaseDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog = new FolderBrowserDialog();


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                String fName = openFileDialog.SelectedPath;
                txtReleaseDir.Text = fName;
            }
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.label2,"针对原java文件E:\\work\\pro\\src\\main\\java\\cn\\test\\a.java ，\r\n而class文件为E:\\work\\pro\\webroot\\cn\\test\\a.class");
        }

        private void btnRelase_Click(object sender, EventArgs e)
        {
                writeIniData();
            
				txtResult.Text="";
				if ("".Equals(txtList.Text)) {
					txtResult.Text=("发布文件列表不能为空");
					return;
				}

                if ("".Equals(txtProDir.Text))
                {
					txtResult.Text=("项目目录不能为空");
					return;
				}
                if ("".Equals(txtReleaseDir.Text))
                {
                    txtResult.Text = ("发布目录不能为空");
                    return;
                }
                DirectoryInfo file01 = new DirectoryInfo(txtProDir.Text);
            
                 

               //如果项目目录不存在或者不是目录
				if(!file01.Exists||file01.Attributes!=FileAttributes.Directory){
					txtResult.Text=("项目所在目录不存在:"+txtProDir.Text);
					return;
				}
				
             //如果项目编译目录不存在或者不是目录
                DirectoryInfo file02 = new DirectoryInfo(txtProDir.Text + Path.DirectorySeparatorChar + txtClassDir.Text);
				if(!file02.Exists ||file02.Attributes!=FileAttributes.Directory){
					txtResult.Text=("项目编译class所在目录不存在:"+txtProDir.Text+Path.DirectorySeparatorChar+txtClassDir.Text);
					return;
				}
				
				String proName = txtProDir.Text.Substring(
						txtProDir.Text.LastIndexOf("\\"));
                proName = proName.Replace( "\\" , "");
				String releaseDir = txtReleaseDir.Text
						+ Path.DirectorySeparatorChar
						+ proName
						+ "_"
						+ DateTime.Now.ToString("yyyyMMddHHmmss");;
				 txtFinalDir.Text=(releaseDir);
				makeDir(releaseDir,false);
				String textInfo = txtList.Text;
				
				String[] textArr = textInfo.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
				String sourceFile="需要发布的文件共计："+textArr.Length;//源文件
				int suc=0;
				int fail=0;
				int folder=0;
				String destFile=""; //编译文件
				int innerClass=0;
            

				foreach (String strTemp in textArr) {
					String str=strTemp;
					sourceFile+="\r\n"+strTemp;
					 
					if (str.StartsWith("\\src")) {
						str=str.Replace("\\src",  txtProDir.Text+Path.DirectorySeparatorChar+txtClassDir.Text);
						if(str.EndsWith(".java")){
							str=str.Substring(0, str.Length-5)+".class";
							
						}
					}else if (str.StartsWith("/src")) {
						str=str.Replace("/src",  txtProDir.Text+Path.DirectorySeparatorChar+txtClassDir.Text);
						if(str.EndsWith(".java")){
							str=str.Substring(0, str.Length-5)+".class";
							
						}
					}else if (str.StartsWith("src/")) {
						str=str.Replace("src",  txtProDir.Text+Path.DirectorySeparatorChar+txtClassDir.Text);
						if(str.EndsWith(".java")){
							str=str.Substring(0, str.Length-5)+".class";
							
						}
					}else if (str.StartsWith("src\\")) {
						str=str.Replace("src",  txtProDir.Text+Path.DirectorySeparatorChar+txtClassDir.Text);
						if(str.EndsWith(".java")){
							str=str.Substring(0, str.Length-5)+".class";
							
						}
					}else{
						str=txtProDir.Text+Path.DirectorySeparatorChar+str;
					}

					//忽略目录
					if(!"".Equals(txtIgnore.Text.Trim())){
						if(txtIgnore.Text.Trim().Contains(",")){
							String[] ignores=txtIgnore.Text.Trim().Split(',');
							for (int i = 0; i < ignores.Length; i++) {
								if(!"".Equals(ignores[i])&&ignores[i]!=null){
									str=str.Replace(ignores[i], "");
								}
							}
						}else{
							str=str.Replace(txtIgnore.Text.Trim(), "");
						}
					}


                     FileInfo oldfile=null;
                     DirectoryInfo dirFile=null;
                    try
                    {
                          oldfile = new FileInfo(str);
                          dirFile = new DirectoryInfo(str);

                    }
                    catch (Exception ex) 
                    {
                       txtResult.Text = ("错误：：发布文件" + str +"时"+ex.Message+ "\r\n" + txtResult.Text);
                       continue;
                    }

					//获取项目下的发布路径
					String rlPath=str.Replace(txtProDir.Text, releaseDir);
						
                    //文件不存在，则判断这是不是一个文件夹
					if(!oldfile.Exists){
                        if (dirFile.Exists)
                        {
                            txtResult.Text = ("这是一个文件夹：" + str + "\r\n" + txtResult.Text);
                            destFile = "这是一个文件夹：" + str + "\r\n" + destFile;
                            folder++;
                            continue;
                        }
                        else {
                            txtResult.Text = (txtResult.Text + "编译文件不存在：" + str + "\r\n");
                            destFile = "编译文件不存在：" + str + "\r\n" + destFile;
                            fail++;
                            continue;
                        
                        }

						
					}
					
				 
					
					
					//如果该文件是class编译文件
					if(oldfile.Name.EndsWith(".class")){
						String fileName=oldfile.Name.Substring(0, oldfile.Name.Length-6);
						String filePath=oldfile.DirectoryName;
						DirectoryInfo file1=new DirectoryInfo(filePath); 
						FileInfo[] fileList=file1.GetFiles(); //当前目录下
						bool _flag1=false;
						//如果当前目录下存在该编译文件
						foreach (FileInfo tmp in fileList) {
							
                            //有该文件名一直的class
							if(tmp.Name.Equals(fileName+".class")){
								makeDir(rlPath,true);
								txtResult.Text=(txtResult.Text+"发布成功："+tmp.FullName+"\r\n");
								Copy(tmp,rlPath);
								destFile+="\r\n"+"发布成功："+tmp.FullName;
								_flag1=true;
								suc++;
                            }
                            else if (tmp.Name.StartsWith(fileName + "$") && tmp.Name.EndsWith(".class"))
                            {
								makeDir(rlPath,true);
								txtResult.Text=(txtResult.Text+"发布成功："+tmp.FullName+"\r\n");
								Copy(tmp,rlPath);
                                destFile += "\r\n" + "发布成功：" + tmp.FullName;
								_flag1=true;
								suc++;
								innerClass++;
							}
						
						}
						
						if(!_flag1){
							txtResult.Text=(txtResult.Text+"编译文件不存在："+str+"\r\n");
							destFile="编译文件不存在："+str+"\r\n"+destFile;
							fail++;
						}
						continue;
						
					} 
					
					//最后剩下不是class编译文件且肯定存在的文件
					makeDir(rlPath,true);
                    txtResult.Text=(txtResult.Text + "发布成功：" + str + "\r\n");
					Copy(oldfile,rlPath);
					
					destFile+="\r\n"+"发布成功："+str;
					suc++;
				}
				
				//如果最终编译的结果中 还存在.java文件   则需注意是不是有错误引起的
				if(destFile.Contains(".java")){
                    txtResult.Text=("发布文件中有java文件未正确编译，请注意！！！！！" + "\r\n" + txtResult.Text);
					destFile+="\r\n"+"发布文件中有java文件未正确编译，请注意！！！！！";
				}

                txtResult.Text=("预计共发布" + textArr.Length + "个,找到编译文件共" + suc + "(含内部类个数：" + innerClass + ")个" + ",失败" + fail + "个，文件夹" + folder + "个" + "\r\n" + txtResult.Text);
				destFile="预计共发布"+textArr.Length+"个,找到编译文件共"+suc+"(含内部类个数："+innerClass+")个"+",失败"+fail+"个，文件夹"+folder+"个"+"\r\n"+destFile;
				contentToTxt(releaseDir+Path.DirectorySeparatorChar+"发布源文件列表.txt",sourceFile);
				contentToTxt(releaseDir+Path.DirectorySeparatorChar+"发布编译文件列表.txt",destFile);




              
        }

        //打开最终发布目录
        private void btnOpenDir_Click(object sender, EventArgs e)
        {

            if (!"".Equals(txtReleaseDir.Text.Trim()) && !"".Equals(txtFinalDir.Text.Trim()))
            {

                System.Diagnostics.Process.Start("Explorer.exe", txtFinalDir.Text.Trim());
            }
			
        }

        //拖拽结果
        private void txtFileList_DragDrop(object sender, DragEventArgs e)
        {
            if ("".Equals(txtProDir.Text.Trim())
                        || "".Equals(txtReleaseDir.Text.Trim()))
            {
                txtResult.Text="工程目录和发布目录不能为空";
                return;
            }

            string[] files= (string[])e.Data.GetData(DataFormats.FileDrop, false);
            
            MessageBox.Show(files.ToString());
            if (files != null && files.Length>0)
            {

                String containText = txtProDir.Text.Trim();
                for (int i = 0; i < files.Length; i++)
                {
                    if (!files[i].Contains(containText))
                    {
                        txtResult.Text += "\r\n"+"工作空间内不存在："+files[i];
                        continue;
                    }

                    FileInfo file = new FileInfo(files[i]);

                    

                    if (!file.Exists)
                    {
                        txtResult.Text += "\r\n" + "文件不存在：" + files[i];
                        continue;
                    }
                    if (file.Attributes == FileAttributes.Directory)//判断类型是选择的是文件夹还是文件
                    {
                        //文件夹
                        txtResult.Text += "\r\n" + "文件夹：" + files[i];
                        continue;
                    }

                    //idea 拖拽的文件前面都是file:/开头
                    if (files[i].StartsWith("file:/")) {
                        files[i] = files[i].Replace("file:/","");
                    }
                    else if (files[i].StartsWith("file:\\")) {
                        files[i] = files[i].Replace("file:\\", "");
                    }

                    String tempStr = files[i].Replace(containText, "") + "\r\n";
                    if (txtList.Text.Contains(tempStr))
                    {
                        continue;
                    }
                    String textInfo = txtList.Text;
                    txtList.Text=(textInfo + tempStr);
                }

            }

        }

        private void txtFileList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link; //重要代码：表明是链接类型的数据，比如文件路径
            else if (e.Data.GetDataPresent(DataFormats.Text)) {
                e.Effect = DragDropEffects.Move;
            }
            else e.Effect = DragDropEffects.None;
        }

        //帮助描述
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.linkLabel1, "项目目录、编译目录、发布目录的\r\n内容不要以分隔符结尾");
      
        }

        //ctrl+a
        private void txtList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            } 
        }
       
        //ctrl+a
        private void txtResult_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            } 
        }

        #region 读Ini文件

        public static string ReadIniData(string Section, string Key, string NoText, string iniFilePath)
        {
            if (File.Exists(iniFilePath))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, NoText, temp, 1024, iniFilePath);
                return temp.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        #endregion

        #region 写Ini文件

        public static bool WriteIniData(string Section, string Key, string Value, string iniFilePath)
        {
            if (File.Exists(iniFilePath))
            {
                long OpStation = WritePrivateProfileString(Section, Key, Value, iniFilePath);
                if (OpStation == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region API函数声明

        [DllImport("kernel32")]//返回0表示失败，非0为成功
        private static extern long WritePrivateProfileString(string section, string key,
            string val, string filePath);

        [DllImport("kernel32")]//返回取得字符串缓冲区的长度
        private static extern long GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);


        #endregion

        private void txtList_TextChanged(object sender, EventArgs e)
        {
          
            String textInfo = txtList.Text;
            txtList.Text=textInfo.Replace("/","\\");
            if (txtList.Text.StartsWith("file:\\")) { 
                txtList.Text=txtList.Text.Replace("file:\\","");
            }
            txtList.Text = txtList.Text.Replace(txtProDir.Text, "");
            String[] textArr = textInfo.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
           
            if (txtList.Text.IndexOf(":\\") != -1) {
                txtResult.Text += "\r\n 请检查发布列表中的文件的路径有不是项目目录下的！！(根据:\\查询)";
            }

        }

        private void txtProDir_TextChanged(object sender, EventArgs e)
        {
            String textInfo = txtProDir.Text;
            txtProDir.Text = textInfo.Replace("/", "\\");
        }

        private void txtReleaseDir_TextChanged(object sender, EventArgs e)
        {
            String textInfo = txtReleaseDir.Text;
            txtReleaseDir.Text = textInfo.Replace("/", "\\");
        }
    }
}
