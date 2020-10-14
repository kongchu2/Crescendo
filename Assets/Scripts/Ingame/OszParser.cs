using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
public class OszParser {
    public void ExtractOsz(string oszPath, string destinationPath)
    {
        string zipPath = Path.ChangeExtension(oszPath, ".zip");
        System.IO.File.Move(oszPath, zipPath);
        if (!Directory.Exists(destinationPath))
            Directory.CreateDirectory(destinationPath);
        using (ZipArchive zip = System.IO.Compression.ZipFile.OpenRead(zipPath))
        {
            foreach (ZipArchiveEntry entry in zip.Entries)
            {
                var filepath = Path.Combine(destinationPath, entry.FullName);
                var subDir = Path.GetDirectoryName(filepath);
                if (!Directory.Exists(subDir))
                    Directory.CreateDirectory(subDir);
                entry.ExtractToFile(filepath);
            }
        }
        System.IO.File.Move(zipPath, oszPath);
    }
    public void osuParse(string osuPath, string songName)
    {
        string text = File.ReadAllText(osuPath);
        StringReader strReader = new StringReader(text);
        string[] textSplit;
        string sheetText;

        string artist="";
        string BPM;

        string savePath = songName + ".cre";
        string resultText;

        while(true)
        {
            sheetText = strReader.ReadLine();
            textSplit = sheetText.Split(':');
            if(textSplit[0] == "Artist")
            {
                artist = textSplit[1];
                break;
            }
        }
        while((sheetText = strReader.ReadLine()) != "[TimingPoints]")
        {}
        sheetText = strReader.ReadLine();
        textSplit = sheetText.Split(',');
        float bBPM = 60000 / float.Parse(textSplit[1]);
        BPM = (Math.Round(bBPM)).ToString();
        resultText = "Artist=" + artist + "\n" +
        "BPM=" + BPM + "\n" +
        "[NotesInfo]\n";
        while((sheetText = strReader.ReadLine()) != "[HitObjects]")
        {}
        while((sheetText = strReader.ReadLine()) != null)
        {
            textSplit = sheetText.Split(',');
            int LanePos = Int32.Parse(textSplit[0]);
            string noteLaneNum = ((LanePos-64)/128+1).ToString();
            string PosY = textSplit[2];
            resultText += noteLaneNum + "," + PosY + "," + "0\n";
        }
        File.WriteAllText(savePath, resultText, Encoding.Default);
    }
    public static void Main()
    {
        OszParser parser = new OszParser();
        string songName = "BEXTER_-_Dream_it";
        parser.ExtractOsz(songName + ".osz", songName);
        DirectoryInfo dirInfo = new DirectoryInfo(songName);
        FileInfo[] fileInfo = dirInfo.GetFiles("*.osu"); 
        parser.osuParse(songName+"/"+fileInfo[0].Name, songName);
    }
}