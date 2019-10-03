using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Serialization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // "" strings you need to escape some characters with \
            // @"" strings you don't
            var xmlFilePath = @"C:\revature\persons.xml";
            var jsonFilePath = @"C:\revature\persons.json";

            //var data = GetInitialData();

            //var data = DeserializeXmlFromFile(xmlFilePath);
            var data = DeserializeJsonFromFile(jsonFilePath);

            ModifyData(data);

            //SerializeXmlToFile(xmlFilePath, data);
            SerializeJsonToFile(jsonFilePath, data);
        }

        public static void SerializeJsonToFile(string jsonFilePath, List<Person> data)
        {
            // we will do this with JSON.NET aka Newtonsoft Json
            // we use NuGet to get these dependencies
            string json = JsonConvert.SerializeObject(data);

            // exceptions should be handled here, ignored for sake of time
            File.WriteAllTextAsync(jsonFilePath, json);//Async version to save time

            
        }

        public static List<Person> DeserializeJsonFromFile(string jsonFilePath)
        {
            // exceptions should be handled here, ignored for sake of time
            string json = File.ReadAllText(jsonFilePath);

            var data = JsonConvert.DeserializeObject<List<Person>>(json);

            return data;
        }

        public static void ModifyData(List<Person> data)
        {
            var person = data[0];
            person.Id += 10;
        }

        public static List<Person> DeserializeXmlFromFile(string xmlFilePath)
        {
            // XmlSerializer serialization can be configured on the serializer object
            var serializer = new XmlSerializer(typeof(List<Person>));

            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(xmlFilePath, FileMode.Open);

                return (List<Person>)serializer.Deserialize(fileStream);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error while opening {xmlFilePath} for writing: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error while serializing: {ex.Message}");
            }
            finally // finally block always runs whether, no-exception, handled-exception, or unhandled-exception
            {
                // this "do something if not null"
                //if (fileStream != null)
                //{
                //    fileStream.Dispose();
                //}
                fileStream?.Dispose(); // is exact same as commented-out code above
                // null-conditional operator
            }
            return null;
        }

        public static void SerializeXmlToFile(string xmlFilePath, List<Person> data)
        {
            // XmlSerializer was made pre-generics and has not been updated
            var serializer = new XmlSerializer(typeof(List<Person>));

            // "using statement" replaces a try-finally-dispose on an disposable object.

            try
            {
                //using (fileStream = new FileStream(xmlFilePath, FileMode.Create))
                //{
                //    serializer.Serialize(fileStream, data);

                //    // at the end of the using block, the object is disposed automatically (regardless
                //    // of any unhandled exceptions)
                //}

                // from c# 8, we have "using declaration" - instead of having to indent a whole block,
                // the implicit dispose will happen at the end of the current block
                using var fileStream = new FileStream(xmlFilePath, FileMode.Create);

                serializer.Serialize(fileStream, data);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error while opening {xmlFilePath} for writing: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error while serializing: {ex.Message}");
            }
        }

        public static List<Person> GetInitialData()
        {
            return new List<Person>
            {
                new Person
                {
                    Id = 1,
                    Name = "Billy",
                    Address = new Address
                    {
                        Street = "123 Main St",
                        City = "Dallas",
                        State = "TX"
                    }
                },
                new Person
                {
                    Id = 2,
                    Name = "Sam"
                }
            };
        }
    }
}


















/*
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Serialization
{
    class Program
    {
        public static void Main(string[] args)
        {
            var xmlFilePath = @"C:\revature\persons.xml"; //At time of writing this line, persons.xml doesn't exist
            var jsonFilePath = @"C:\revature\yahoo.json";
            var data = DeserializeXmlFromFile(xmlFilePath);

            /*
            ModifyData(data);
            //data = GetInitialData();

            SerializeXmlToFile(xmlFilePath, data);
            */// hidden while working on json
/*SerializeJsonToFile(jsonFilePath,data);
        }

        public static void SerializeJsonToFile(string jsonFilePath, List<Person> data)
        {
            //what the hell happened. he did something with json, adding newtonsoft to dependencies, then wrote code at light speed
        }

        public static void ModifyData(List<Person> data)
        {
            var person = data[0];
            person.ID += 10;
        }
        private static void SerializeXmlToFile(string xmlFilePath, List<Person> data)
        {
            var serializer = new XmlSerializer(typeof(List<Person>));

            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(xmlFilePath, FileMode.Create);

                serializer.Serialize(fileStream, data);
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine($"Sorry, {ex} occured");
            }
            catch(IOException ex)
            {
                Console.WriteLine($"Sorry, {ex} occured");
            }
            finally//always runs whether no-exception,handled exception, or unhandled exception
            {
                if(fileStream != null)
            {
                    fileStream.Dispose();  //See notebook abour idisposable
                }
            }
        }

        private static List<Person> DeserializeXmlFromFile(string xmlFilePath)
        {
            var serializer = new XmlSerializer(typeof(List<Person>));

            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(xmlFilePath, FileMode.Open);

                return (List<Person>) serializer.Deserialize(fileStream);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Sorry, {ex} occured");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Sorry, {ex} occured");
            }
            finally//always runs whether no-exception,handled exception, or unhandled exception
            {
                if (fileStream != null)
                {
                    fileStream.Dispose();  //See notebook abour idisposable
                }
            }
        }

        public static List<Person> GetInitialData()
        {
            return new List<Person>
            {
                new Person
                {
                    ID = 1,
                    Name = "Billy",
                    Address = new Address
                    {
                        Street = "123 Main St",
                        City = "Dallas",
                        State = "TX"
                    }
                },
                new Person
                {
                    ID = 2,
                    Name = "Willy",
                    Address = new Address
                    {
                        Street = "456 Main St",
                        City = "Gonzales",
                        State = "LA"
                    }
                }
            };
        }

    }
}
*/