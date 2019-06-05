using AspitAktivitet.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace AspitAktivitet.Healpers
{
    public class FileHandler
    {
        public void CreatFileAndOpen(List<Tilmeldt> liste, DateWrapper date)
        {
            string fileName = $"Idræt_oversigt_uge_{date.Week}.docx";

            var doc = DocX.Create(fileName);
            doc.PageLayout.Orientation = Orientation.Landscape;
            //doc.InsertParagraph($"Idræt oversigt uge {date.Week}");

            string title = $"Idræt oversigt uge {date.Week}";
            Formatting titleFormat = new Formatting();
            titleFormat.Size = 20;
            titleFormat.Position = 10;

            Paragraph titleParagraph = doc.InsertParagraph(title, false, titleFormat);
            titleParagraph.Alignment = Alignment.center;

            //tom Linie
            doc.InsertParagraph();


            var ActivitetNavne = liste.GroupBy(test => test.aname)
                   .Select(grp => grp.First())
                   .ToList();

            //tabel med Activiteter og Elever
            Table t = doc.AddTable(liste.Count + 1, ActivitetNavne.Count);
            t.Alignment = Alignment.center;

            Formatting HeaderFormat = new Formatting();
            HeaderFormat.Bold = true;
            HeaderFormat.Size = 14;

            for (int i = 0; i < ActivitetNavne.Count; i++)
            {
                t.Rows[0].Cells[i].Paragraphs.First().Append(ActivitetNavne[i].aname , HeaderFormat).Alignment = Alignment.center;
            }
            

            //del listen på bagrund af activitets navne
            List<List<Tilmeldt>> splitLIst = new List<List<Tilmeldt>>();
            
            for (int i = 0; i < ActivitetNavne.Count; i++)
            {
                var list = (from tm in liste where tm.aname == ActivitetNavne[i].aname select tm).ToList();
                splitLIst.Add(list);
            }

            Formatting nonBoldFormat = new Formatting();
            HeaderFormat.Bold = false;
            for (int i = 0; i < splitLIst.Count; i++)
            {
                List<Tilmeldt> elever = splitLIst[i];
                for (int j = 0; j < elever.Count; j++)
                {
                    t.Rows[j+1].Cells[i].Paragraphs.First().Append(elever[j].uname, nonBoldFormat);
                }
            }

            doc.InsertTable(t);

            doc.Save();
            Process.Start("WINWORD.EXE", fileName);
        }
    }
}
