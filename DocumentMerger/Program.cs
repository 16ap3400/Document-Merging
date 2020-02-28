using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DocumentMerger
{
    class Program
    {
        private static void ReadWriteDocs(String[] firstDocument, String[] secondDocument)
        {
            Console.WriteLine("Please enter the first document name:\n");
            String firstDocumentPath = Console.ReadLine();

            if(firstDocumentPath != null)
            {
                try
                {
                    firstDocument = File.ReadAllLines(firstDocumentPath + ".txt");
                }
                catch(Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                    Console.WriteLine("The file you entered did not have the extension .txt or was not found. \nPlease enter another file path:\n");
                    ReadWriteDocs(firstDocument, secondDocument);
                }
            }

            Console.WriteLine("\nPlease enter the second document name:\n");
            String secondDocumentPath = Console.ReadLine();

            if(secondDocumentPath != null)
            {
                try
                {
                    secondDocument = File.ReadAllLines(secondDocumentPath + ".txt");
                }
                catch(Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                    Console.WriteLine("The file you entered did not have the extension .txt or was not found. \nPlease enter another file path:\n");
                    ReadWriteDocs(firstDocument, secondDocument);
                }
            }

            String[] combined = firstDocument.Concat(secondDocument).ToArray();
            File.WriteAllLines(firstDocumentPath + secondDocumentPath + ".txt", combined);
            Console.WriteLine("File succesfully saved.\n");
        }


        private static void doAgain()
        {
            String again;
            while(true)
            {
                Console.WriteLine("Would you like to merge two more files? (y/n)\n");
                again = Console.ReadLine();    
                if(again == "y")
                {
                    string[] doc1 = {};
                    string[] doc2 = {};
                    ReadWriteDocs(doc1, doc2);
                }
                else if(again == "n")
                {
                    Console.WriteLine("\nHave a nice day!\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry.\n");
                }
            }

        }


        static void Main(string[] args)
        {
            Console.WriteLine("\n---------- Document Merger -----------\n");
            String[] document1name = {};
            String[] document2name = {};
            ReadWriteDocs(document1name, document2name);
            doAgain();
        }
    }
}
