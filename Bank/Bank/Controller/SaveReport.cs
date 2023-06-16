using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Bank
{
    public class SaveReport<T> where T : TablesBD
    {
        public string FilePath { get; set; } = null;

        public SaveReport(List<T> list)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Текстовый документ | *.txt";

            if(saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
            }
            else
            {
                return;
            }

            StreamWriter streamWriter = new StreamWriter(FilePath);

            if (list.Count == 0) return;
            
            streamWriter.WriteLine(list[0].GetTableName());
            streamWriter.WriteLine(list[0].GetHeadersName());
            streamWriter.WriteLine();
            foreach (T item in list)
            {
                streamWriter.WriteLine(item.GetValues());
            }

            streamWriter.Close();
        }
    }
}
