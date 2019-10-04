using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Serialization
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var xmlFilePath = @"C:\revature\persons.xml";
            var jsonFilePath = @"C:\revature\persons.json";

            var data = GetInitialData();

            SerializeXmlToFile(xmlFilePath, data);
            await SerializeJsonToFileAsync(jsonFilePath, data); //async
        }

        public static async Task SerializeJsonToFileAsync(string jsonFilePath, List<Person> data)
        {
            string json = JsonConvert.SerializeObject(data);

            await File.WriteAllTextAsync(jsonFilePath, json);
        }

        public static async Task<List<Person>> DeserializeJsonFromFileAsync(string jsonFilePath)
        {
            string json = await File.ReadAllTextAsync(jsonFilePath);

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
            finally
            {
                fileStream?.Dispose();
            }
            return null;
        }

        public static void SerializeXmlToFile(string xmlFilePath, List<Person> data)
        {
            var serializer = new XmlSerializer(typeof(List<Person>));

            try
            {
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
                    Name = "Sammy"
                }
            };
        }
    }
}
