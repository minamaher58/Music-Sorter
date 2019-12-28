using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab10
{
    class MP3Reader
    {
        string fileName;
        FileStream stream;
        const int SIZE = 128;
        byte[] tagData;
        public MP3Reader(string name)
        {
            tagData = new byte[SIZE];
            this.fileName = name;
            this.stream = new FileStream(this.fileName, FileMode.Open);
        }
       
        public MP3Tag getTag()
        {
            MP3Tag tag = new MP3Tag();

            stream.Seek(stream.Length - 128, SeekOrigin.Begin);
            stream.Read(tagData, 0, SIZE);
            stream.Close();

            byte b1 = tagData[0];
            byte b2 = tagData[1];
            byte b3 = tagData[2];

            if ((char)b1 != 'T' || (char)b2 != 'A' || (char)b3 != 'G')
            {
                throw new Exception("Not an MP3 Format File");
            }

            for (int i = 3; i < 33; i++)
            {
                if (tagData[i] != 0)
                    tag.Title += (char)tagData[i];

            }
            for (int i = 33; i < 63; i++)
            {
                if (tagData[i] != 0)
                    tag.Artist += (char)tagData[i];
            }
            for (int i = 63; i < 93; i++)
            {
                if (tagData[i] != 0)
                    tag.Album += (char)tagData[i];
            }
            for (int i = 93; i < 97; i++)
            {
                if (tagData[i] != 0)
                    tag.Year += (char)tagData[i];
            }
            for (int i = 97; i < 127; i++)
            {
                if (tagData[i] != 0)
                    tag.Comment += (char)tagData[i];
            }
            tag.Genere = tagData[127].ToString();

            return tag;
        }

        public void WriteCommentsOrder(int x)
        {

               RemoveCommentText();

            string xChar = x.ToString();
            for (int i = 0; i < xChar.Length; i++)
            {
                stream.WriteByte((byte)xChar[i]);

            }

            stream.Close();
        }
        
        private void RemoveCommentText()
        {
            stream.Seek(stream.Length - 30, SeekOrigin.Begin);

            for (int i = 0; i < 29; i++)
            {
                stream.WriteByte((byte)' ');
            }
            
            stream.Seek(stream.Length - 30, SeekOrigin.Begin);
        }
        public void RemoveComment()
        {
            stream.Seek(stream.Length - 30, SeekOrigin.Begin);

            for (int i = 0; i < 29; i++)
            {
                stream.WriteByte((byte)' ');
            }
            stream.Close();
        }

    }
}
