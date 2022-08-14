using System;
using System.IO;

class Program 
{
    static void Main(string[] args) 
    {
        Console.WriteLine("|-------------------------------------|");
        Console.WriteLine("|------ FILE MANAGEMENT TOOL ---------|");
        Console.WriteLine("|-------------------------------------|");
        Console.WriteLine("");
        Console.WriteLine("1 - See files in a directory");
        Console.WriteLine("2 - Move files in a directory");

        string opt = Console.ReadLine();
        int optINT = Int32.Parse(opt);

        // |----------------------------------------------|
        // |--------------- TOOL SELECTION ---------------|
        // |----------------------------------------------|

        // |--------- Read Files in a dir --------------|
        if (optINT == 1)
        {

            Console.WriteLine("|-----------------------------------------------------------------------|");
            Console.WriteLine("|-------------- 1 - Read Files in a directory --------------------------|");
            Console.WriteLine("|------- 2 - Read Files with a specified extension in a directory ------|");
            Console.WriteLine("|-----------------------------------------------------------------------|");

            string scanOPT = Console.ReadLine();
            int optSCAN_trans = Int32.Parse(scanOPT);

            if (optSCAN_trans == 1)
            {
                Console.WriteLine("Please enter the directory you want to search :");
            string seeDir = Console.ReadLine();

            DirectoryInfo d = new DirectoryInfo(seeDir);    
            FileInfo[] Files = d.GetFiles();  
            Console.WriteLine("Files in this directory");  
            Console.WriteLine("-----------------------------------------------------");  
            foreach (FileInfo file in Files)  
            {                  
                Console.WriteLine("File Name : {0}" , file.Name);  
            }  
            Console.ReadKey();
            }

            if (optSCAN_trans == 2)
            {
                Console.WriteLine("Enter the directory you want the files to be scanned from");
                string sourceDir = Console.ReadLine();

                // Document Type
                Console.WriteLine("Please input the type of documents you want to be moved - ie: || .txt || .pdf || .xlsx ||");
                string docType = Console.ReadLine();

                string[] Files = Directory.GetFiles(sourceDir, docType);
                Console.WriteLine("Files in this directory with the " + docType + "extension");
                Console.WriteLine("-----------------------------------------------------");

                foreach(var item in Files)
                {
                    string fileName = item;
                    FileInfo file = new FileInfo(fileName);

                    string fullFileName = file.FullName;
                    Console.WriteLine("File Path && Name: {0}", fullFileName);

                    string extn = file.Extension;
                    Console.WriteLine("File Extension: {0}", extn);

                    bool exists = file.Exists;
                    Console.WriteLine("File Exists: {0}", exists);
                    if (file.Exists)
                    {
                        long size = file.Length;
                        Console.WriteLine("File Size in Bytes: {0}", size);
                    }

                }
            }
        }

        // |---------------- Move Files ----------------------|
        if (optINT == 2) 
        {
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("  ↳ 1 - transfer single file");
            Console.WriteLine("  ↳ 2 - transfer multiple files form a single directory");
            Console.WriteLine("  ↳ 3 - transfer type specific files from one directory to another");
            Console.WriteLine("|---------------------------------------------------------|");

            string trans_opt = Console.ReadLine();
            int transOPT = Int32.Parse(trans_opt);

            if (transOPT == 1) 
            {
                Console.WriteLine("Please enter the directory you want to move files from :");
                string sourceFile = Console.ReadLine();
                Console.WriteLine("Please enter the location where the file will now be placed :");
                string sourceDestination = Console.ReadLine();


                File.Move(sourceFile, sourceDestination);

            }

            if (transOPT == 2) 
            {
                Console.WriteLine("Enter the directory you want the files to be moved from");
                string sourceDir = Console.ReadLine();
                Console.WriteLine("Enter the directory you want to files to be transfered to");
                string Destination = Console.ReadLine();

                string[] allFiles = Directory.GetFiles(sourceDir);

                foreach (var item in allFiles) {
                    File.Move(item,Destination + "\\"+Path.GetFileName(item));
                }

                Console.ReadKey();

            }

            if (transOPT == 3)
            {
                Console.WriteLine("Enter the directory you want the files to be scanned from");
                string sourceDir = Console.ReadLine();

                Console.WriteLine("Enter the directory you want the files to be transfered to");
                string sourceDest = Console.ReadLine();

                // Document Type
                Console.WriteLine("Please input the type of documents you want to be moved - ie: || .txt || .pdf || .xlsx ||");
                string docType = Console.ReadLine();

                string[] Files = Directory.GetFiles(sourceDir, docType);  // originally "*.txt" or "*.bmp"
                Console.WriteLine("Files in this directory with the " + docType + "extension");
                Console.WriteLine("-----------------------------------------------------");

                foreach(var item in Files)
                {
                    // string fileName = item;
                    // FileInfo file = new FileInfo(fileName);

                    // string fullFileName = file.FullName;
                    // Console.WriteLine("File Path && Name: {0}", fullFileName);

                    // string extn = file.Extension;
                    // Console.WriteLine("File Extension: {0}", extn);

                    // bool exists = file.Exists;
                    // Console.WriteLine("File Exists: {0}", exists);
                    // if (file.Exists)
                    // {
                    //     long size = file.Length;
                    //     Console.WriteLine("File Size in Bytes: {0}", size);
                    // }

                    File.Move(item,sourceDest + "\\"+Path.GetFileName(item));
                }

                Console.ReadKey();

            }
        }

    }
}