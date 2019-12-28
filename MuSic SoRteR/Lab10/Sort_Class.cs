using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab10
{
    
    class Sort_Class
    {
        
        List<MP3Tag> FirstList;
     
        MP3Reader Reader;
        MP3Tag Tag;
        
        string[] file =new string[] { };
        string[] Folders = new string[] { };
        
        public Sort_Class (string Path) {

                 file = Directory.GetFiles(Path);
           
            FirstList = new List<MP3Tag>();
                 GetFilesInfo();
        } 

        private void GetFilesInfo()
        {     
            foreach (var i in file)
            {

                FileInfo x = new FileInfo(i);   
                Reader = new MP3Reader(i);
                Tag = Reader.getTag();
                Tag.Name = x.Name;
                Tag.Size = x.Length.ToString("#,#");
                FirstList.Add(Tag); 

               
            }

        }
        public void  SortByName()
        {
            FirstList = FirstList.OrderBy(x => x.Name).ToList();
          
            show(0,FirstList.Count);
            Choice();

        }
        private void Choice()
        {
            string FolderName="";
            string path = @"C:\Users\hp\Desktop\MuSic-SoRteR\MuSic SoRteR\Lab10\Sorted Music File\";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Copy Range Of Files press 1 \n Another Sort press 2 \n  Copy All Files press 3\n");


            string choice = Console.ReadLine();
            while (true)
            {
                
                int value;
               
                if (! int.TryParse(FolderName, out value))
                {

                    break;

                }
                else
                {
                    Console.WriteLine("enter a number not letters :");
                     choice = Console.ReadLine();
                    continue;
                }

            }

           

            while (true)
            {

                 
                if (choice == "1" || choice=="3")
                {
                    int value;
                    Console.Write("Pleas Enter Folder Name : ");
                    FolderName = Console.ReadLine();
                    if( int.TryParse(FolderName, out value))
                     {
                         Console.WriteLine("please enter a name not a number");
                         continue;
                         
                     }
                    if (FolderExist(path, FolderName) == true)
                    {
                        Console.WriteLine("The Folder Name Is Exist Please Enter Another One. ");
                        continue;
                    }

                }



                if (choice == "1")
                {
                    Console.Write("Start Number Of Range : ");
                    string FirstNumber = Console.ReadLine();
                     int FirstConvert = Convert.ToInt32(FirstNumber);

                    Console.Write("End Number Of Number : ");
                    string SecondNumber = Console.ReadLine();

                    int SecondConvert = Convert.ToInt32(SecondNumber);
                 
                        if ((FirstConvert < 0) || (SecondConvert < 0) || (FirstConvert > FirstList.Count) || (SecondConvert > FirstList.Count)||(FirstConvert==SecondConvert))
                        {
                            Console.WriteLine("Wrong Values >>> Please Enter Correct Numbers");
                            continue;
                        }

                   
                    
                    show( FirstConvert, SecondConvert+1);
                    WriteComment(FirstConvert, SecondConvert+1);
                    CopyFunc(FirstConvert, SecondConvert+1,path,FolderName);

                    break;
                }
                else if (choice == "2")
                {
                    break;

                }
                else if (choice == "3")
                {

                    WriteComment(0, FirstList.Count);
                    //  Name_Object_Matcher(0, FirstList.Count);
                    CopyFunc(0, FirstList.Count, path, FolderName);
                    break;
                }
                else if (choice!="1" && choice!="2"&& choice!="3")
                {
                    Console.WriteLine("Please Enter Correct Number .");
                    choice = Console.ReadLine();
                    continue;
                }
            }

            foreach (var i in file)
            {
               
                Reader = new MP3Reader(i);
                Reader.RemoveComment();
            }
          //  file = Directory.GetFiles(@"E:\Projects\MuSic SoRteR\Lab10\Sorted");
            
        }
        private bool FolderExist(string path,string FolderName)
        {
            Folders = Directory.GetDirectories(path);
            for (int i = 0; i < Folders.Length; i++)
            {
                string Name = Folders[i].Remove(0, path.Length);
                if(Name==FolderName)
                {
                    return true;
                    break;
                }
            }

            return false;

        }
        public void SortBySize()
        {

            FirstList = FirstList.OrderBy(x => x.Size).ToList();
            FirstList.Reverse();

            //Array.ForEach(Directory.GetFiles(@"E:\Projects\MuSic SoRteR\Lab10\Sorted\"), File.Delete);


            show(0, FirstList.Count);
            Choice();
        }

  
        //private void Name_Object_Matcher(int FirstNumber, int SecondNumber)
        //{
         
        //    for (int i = FirstNumber; i < SecondNumber; i++)
        //    {
        //        for (int k = 0; k < file.Length; k++)
        //        {
        //            FileInfo x = new FileInfo(file[k]);
        //            if (FirstList[i].Name == x.Name)
        //            {
        //                Reader = new MP3Reader(file[k]);
        //                Reader.WriteCommentsOrder(SecondNumber - i);
        //                break;
        //            }
        //        }
              
        //    }
        //}

        private void WriteComment(int FirstNumber, int SecondNumber)
        {
          
            for (int i = FirstNumber; i < SecondNumber; i++)
            {
              
                 //   FileInfo x = new FileInfo(Find_Path(FirstList[i]));
                  
                    
                        Reader = new MP3Reader(Find_Path(FirstList[i]));
                       // Console.WriteLine(Find_Path(FirstList[i]));
                        Reader.WriteCommentsOrder(SecondNumber - i);
                       
                    
            }
           // Console.ReadLine();
        }
        private string Find_Path(MP3Tag mp3)
        {
            int found=0;
            
                for (int k = 0; k < file.Length; k++)
                {
                FileInfo x = new FileInfo(file[k]);
                if (mp3.Name == x.Name)
                    {

                        found = k;
                        break;
                    }
                      
                }
        //    Console.WriteLine(found);
            return file[found];
        }
        public void SortByTitle()
        {

            FirstList = FirstList.OrderBy(x => x.Title).ToList();
            show(0, FirstList.Count);
            Choice();
        }
    
        private void CopyFunc( int FirstNumber, int SecondNumber,string Location,string FolderName)
        {
            string NewLocation = Location + FolderName+@"\" ;
            Directory.CreateDirectory(NewLocation);
            //Console.WriteLine(NewLocation);
                for (int i = FirstNumber; i < SecondNumber; i++)
                {
                    string path = Find_Path(FirstList[i]);
                    string destFile =NewLocation + FirstList[i].Name;
                //  Console.WriteLine(path);
                File.Copy(path, destFile, true);
              //  Console.WriteLine("ASd");
                }            
       
        

            Console.WriteLine("Copy Is Finished ");
            //foreach (var i in mp3)
            //{

            //    string path = Find_Path(i);
            //    string destFile = @"E:\Projects\MuSic SoRteR\Lab10\Sorted\" + i.Name;
            //    //Console.WriteLine(path);
            //    File.Copy(path, destFile, true);

            //}
            Console.ReadLine();
        }

        public void SortByAlbum()
        {
            FirstList = FirstList.OrderBy(x => x.Album).ToList();
            show(0, FirstList.Count);
            Choice();
        }

        public void SortByArtist()
        {
            FirstList = FirstList.OrderBy(x => x.Artist).ToList();
            show(0, FirstList.Count);
            Choice();
        }


        //private void Display(List<string> NameVar, List<string> Sizevar, List<string> Title)
        //{

         
            
        //    for (int i = 0; i < 10; i++)
        //        Console.Write(" ");
        //    Console.Write("Name");

        //    for (int i = 0; i < 40; i++)
        //        Console.Write(" ");
        //    Console.Write("Size");

        //    for (int i = 0; i < 20; i++)
        //        Console.Write(" ");
        //    Console.WriteLine("Title");

        //    for (int i = 0; i < Title.Count(); i++)
        //    {
        //        double sum = 50 -NameVar[i].Length;
 

        //        Console.Write(" "+NameVar[i]);

        //        for (int k = 0; k < sum; k++)
        //            Console.Write(" ");
          
        //        Console.Write( " ( " + Sizevar[i] + " )");

        //        for (int t = 0; t < 10; t++)
        //            Console.Write(" ");

               
        //        Console.WriteLine(" " + Title[i]);
        //    }

           



        //}
        public void show(int FirstNumber, int SecondNumber )
        {
            for (int i = 0; i < 10; i++)
                Console.Write(" ");
            Console.Write("Name");

            for (int i = 0; i < 35; i++)
                Console.Write(" ");
            Console.Write("Size");

            for (int i = 0; i < 20; i++)
                Console.Write(" ");
            Console.Write("Title");

            for (int i = 0; i < 20; i++)
                Console.Write(" ");
            Console.Write ("Artist");


            for (int i = 0; i < 22; i++)
                Console.Write(" ");
            Console.WriteLine("Albume");

            Console.WriteLine();


            for (int i = FirstNumber; i < SecondNumber; i++)
            {
                string CountStr = i.ToString();
                int NumLegnt = 2 - CountStr.Length;

                for (int k   = 0; k < NumLegnt; k++)
                    Console.Write(" ");
                
                int NameLegnth = 40 - (FirstList[i].Name.Length);

                Console.Write(i);
                Console.Write(" " + FirstList[i].Name);

                for (int k = 0; k < NameLegnth; k++)
                    Console.Write(" ");

                Console.Write(" ( " + FirstList[i].Size + " )");

                for (int t = 0; t < 5; t++)
                    Console.Write(" ");


                Console.Write(" " + FirstList[i].Title);

                int TitleLegnth = 35 - FirstList[i].Title.Length;

                for (int k = 0; k < TitleLegnth; k++)
                    Console.Write(" ");

                Console.Write(FirstList[i].Artist);


                int ArtistLegnth = 15 - FirstList[i].Artist.Length;

                for (int k = 0; k < ArtistLegnth; k++)
                    Console.Write(" ");

                Console.WriteLine(FirstList[i].Album);
            }
        }
    }
}
