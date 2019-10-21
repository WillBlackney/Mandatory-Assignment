using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Library
{
    public class Book
    {
        // Variables
        #region
        private string title;
        private string author;
        private string isbnCode;
        private int numberOfPages;
        #endregion
        
        // Properties
        #region
        public string Title
        {
            get { return title; }

            set
            {
                title = value;                   
                
                if (value.Length < 2)
                {
                    throw new ArgumentOutOfRangeException();
                }
                
                else
                {
                    { title = value; }
                }         
               
            }                
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string IsbnCode
        {
            get { return isbnCode; }
            set
            {
                isbnCode = value;                
                
                if (value.Length != 13)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    isbnCode = value;
                }               
                
            }                
        }
        public int NumberOfPages
        {
            get { return numberOfPages; }
            set
            {
                numberOfPages = value;
                
                /*
                if (value < 10 || value > 1000)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    numberOfPages = value;
                }
                */
                
                
            }
        }
        #endregion

        // Contructor
        #region
        public Book(string _title, string _author, string _isbnCode, int _numberOfPages)
        {
            Title = _title;
            Author = _author;
            IsbnCode = _isbnCode;
            NumberOfPages = _numberOfPages;
        }
        #endregion

    }
}
