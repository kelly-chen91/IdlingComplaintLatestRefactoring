using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using SeleniumUtilities.Base;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.DevTools.V112.Network;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Linq.Expressions;

namespace SeleniumUtilities.Utils
{
    public static class FileUtilities
    {

        /*This method will retrive the data from the file.
            The targetRowIndex and targetColumnIndex are starting from 0;*/
        public static string RetrieveRecordValue(this string filePath, int targetRowIndex, int targetColumnIndex)
        {
            try {
                string[] lines = File.ReadAllLines(filePath);

                if (targetRowIndex >= 0 && targetRowIndex < lines.Length)
                {
                    string row = lines[targetRowIndex];

                    string[] columns = row.Split(' ');

                    if (targetColumnIndex >= 0 && targetColumnIndex <= columns.Length - 1)
                    {
                        string targetValue = columns[targetColumnIndex];

                        return targetValue;

                    }
                    else
                    {
                        throw new IndexOutOfRangeException("Target column index is out of range.");
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException("Target row index is out of range.");
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("An index out of range error occurred " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred " + ex.Message);
            }

            return "";
        }



        public static void ReplaceRecordValue(this string filePath, int targetRowIndex, int targetColumnIndex, string newValue)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                string[] columns = lines[targetRowIndex].Split(' ');
                lines[targetRowIndex] = lines[targetRowIndex].Replace(columns[targetColumnIndex], newValue);
                File.WriteAllLines(filePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot replace into File");
                Console.WriteLine(ex.ToString());
            }
        }

        public static void WriteIntoFile(this string filePath, string[] inputs)
        {
            string inputsToFile = "";
            foreach (string input in inputs)
            {
                inputsToFile += input + " ";
            }
            inputsToFile = inputsToFile.Trim();
            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(inputsToFile);
                    Console.WriteLine("Accessed the file");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while appending the text to the file: {ex.Message}");
                Console.WriteLine("Cannot Write into File");
            }
        }

        //public static void WriteIntoFile(this string filePath, string email, string password, string securityAnswer)
        //{
        //    try
        //    {
        //        using (StreamWriter writer = File.AppendText(filePath))
        //        {
        //            writer.WriteLine(email + " " + password + " " + securityAnswer);
        //            Console.WriteLine("Accessed the file");
        //        }
        //
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred while appending the text to the file: {ex.Message}");
        //        Console.WriteLine("Cannot Write into File");
        //    }
        //}
    }
}
