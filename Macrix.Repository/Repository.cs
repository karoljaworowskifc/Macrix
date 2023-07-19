using Macrix.Contract;
using Macrix.Contract.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Macrix.Repository
{
    public class Repository : IRepository
    {
        private List<Person> _data;
        private readonly string _filePath;
        private FileStream _stream;

        public Repository(IOptions<DataConfiguration> options)
        {
            _data = new List<Person>();
            _filePath = options.Value.FilePath;
            if (string.IsNullOrEmpty(_filePath))
            {
                if (!File.Exists(_filePath))
                {
                    File.Create(_filePath).Dispose();
                    //_stream = File.Open(_filePath, FileMode.
                }
            }
        }

        private async Task ReadAll()
        {
            if (_filePath == null)
            {
                throw new Exception();
            }
            
            using (FileStream stream = File.OpenRead(_filePath))
            {
                try
                {
                    _data = await JsonSerializer.DeserializeAsync<List<Person>>(stream);
                }
                catch (Exception ex)
                {
                    _data = new List<Person>();
                    Console.WriteLine(ex);
                }

                stream.Close();
            }
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            await ReadAll();
            return _data;
        }

        public Person GetById(Guid id)
        {
            return _data.FirstOrDefault(person => person.Id == id);
        }

        public async Task< bool> Add(Person person)
        {
            try
            {
                _data.Add(person);
                await Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> RemoveById(Guid personId)
        {
            try
            {
                var personToDelete = _data.FirstOrDefault(person => person.Id == personId);
                if(personToDelete != null)
                {
                    _data.Remove(personToDelete);
                    await Save();
                }
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }            
        }

        public async Task Save()
        {
            using (FileStream stream = File.OpenWrite(_filePath))
            {
                await JsonSerializer.SerializeAsync(stream, _data);
                stream.Close();
            }
        }
    }
}