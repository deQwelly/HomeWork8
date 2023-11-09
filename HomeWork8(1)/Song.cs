using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7_1_
{
    internal class Song
    {
        string name;
        string author;
        Song prev;

        public Song(string name, string author)
        {
            this.name = name;
            this.author = author;
            prev = null;
        }

        public Song(string name, string author, Song prev)
        {
            this.name = name;
            this.author = author;
            this.prev = prev;
        }

        public Song() { }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }

        public Song Prev
        {
            get
            {
                return prev;
            }
            set
            {
                prev = value;
            }
        }

        public string Title()
        {
            return name + " - " + author;
        }

        /// <summary>
        /// По полям name и author сравнивает 2 экземпляра класса Song
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Song song = obj as Song;
            if (song != null)
            {
                if (Title() == song.Title())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
