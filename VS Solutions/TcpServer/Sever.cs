using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Book_Library;
using System.Linq;

namespace TcpServer
{
    public class Server
    {
        public void Start()
        {
            // Set up listener port
            TcpListener myTCPListener = new TcpListener(IPAddress.Loopback, 4646);

            // Start listening for/accepting clients
            myTCPListener.Start();
            while (true)
            {                
                var socket = myTCPListener.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient tempSocket = socket;
                    DoClient(tempSocket);
                }); ;
            }
        }
        
        public void DoClient(TcpClient socket)
        {
            while (true)
            {
                // Get the stream and store it in a variable for later
                var ns = socket.GetStream();

                // Wrap the stream into reading and writing 
                var streamReader = new StreamReader(ns);
                var streamWriter = new StreamWriter(ns);

                // Read input from the client and save it as a string 
                string line = streamReader.ReadLine();

                // Read the client's input, perform operations based on input, then respond to client
                List<string> serverReply = GetResponseFromServer(line);

                foreach(string replyLine in serverReply)
                {
                    streamWriter.WriteLine(replyLine);
                    streamWriter.Flush();
                }
            }
        }

        public List<string> GetResponseFromServer(string textInput)
        {
            // GetResponseFromServer() returns a list of strings, NOT a single string.
            // this is to make longer responses in the SocketTest app become split across multiple lines, and thus more readable

            // Declare an empty lists of strings that will eventually be returned
            List<string> stringsReturned = new List<string>();

            // If client requests to get data on all books
            if(textInput == "GetAll")
            {
                // The code below is the most efficient and correct, but is difficult to read with socket test as it prints every book on a single line
                /*
                string allBooks = Newtonsoft.Json.JsonConvert.SerializeObject(BookCollection.books);
                stringsReturned.Add(allBooks);
                */
                
                // Code below is not as lightweight as the previous section, but much more readable in SocketTest app
                foreach (Book book in BookCollection.books)
                {
                    string newBookString = Newtonsoft.Json.JsonConvert.SerializeObject(book);                    
                    stringsReturned.Add(newBookString);
                }
                
            }

            // if client requests to get data on a specific book by way of ISBN Code reference
            else if (textInput.Contains("Get"))
            {
                // remove the text "Get " from the input, and isolate the isbn code as a string
                string isbnCode = new String(textInput.Where(Char.IsDigit).ToArray());

                // declare an empty string to hold the book info
                string newBookString = "";

                // iterate over all books in the collection, look for a match
                foreach (Book book in BookCollection.books)
                {
                    if(isbnCode == book.IsbnCode)
                    {
                        newBookString = Newtonsoft.Json.JsonConvert.SerializeObject(book);
                        stringsReturned.Add(newBookString);

                        // prevent unneccessary looping if we find a match
                        break;
                    }
                }

                // if there is no book with an isbn code that matches the clients input
                if(newBookString == "")
                {
                    stringsReturned.Add("No matching book with the corresponding ISBN Code: ''" + isbnCode + "'' was found...");
                }
            }

            // If the client requests to create/save a new book object in the collection
            else if(textInput.Contains("Save"))
            {
                // remove the text "Save" from the input, and isolate the JSON string as string
                string filteredBookDataString = textInput.Replace("Save", "");

                // create a new book object by deserializing the json string
                Book newBook = Newtonsoft.Json.JsonConvert.DeserializeObject<Book>(filteredBookDataString);

                // add the new book to the collection 
                BookCollection.books.Add(newBook);

                // prepare respone to client
                stringsReturned.Add(newBook.Title + " by " + newBook.Author + " added to the collection...");
            }

            // if the client enters text that is invalid, or unrellated to getting or saving functions
            else
            {
                string errorString = "Invalid input from client...";
                stringsReturned.Add(errorString);
            }

            return stringsReturned;
        }

    }
}
