using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Directory = LogicLayer.Directory;

namespace JsonStorage
{
    /// <summary>
    /// Classe de ockage utilisant le format JSON
    /// </summary>
    public class StorageJson : IStorage
    {
        #region--attributs--
        /// <summary>
        /// nom du fichier de stockage
        /// </summary>
        private string file;
        /// <summary>
        /// Directory en mémoire
        /// </summary>
        private LogicLayer.Directory directory;
        #endregion

        #region---constructeur--
        /// <summary>
        /// Constructeur du stockage JSON
        /// </summary>
        /// <param name="path">chemin du fichier</param>
        public StorageJson(string path)
        {
            this.file = path;
            this.directory = new LogicLayer.Directory();
        }
        #endregion

        #region--Méthodes--
        public Directory Load()
        {
            if (File.Exists(file) && new FileInfo(file).Length > 0)
            {
                try
                {
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(LogicLayer.Directory), new Type[] { typeof(Person) });
                        var d = (LogicLayer.Directory)serializer.ReadObject(fs);
                        if (d != null)
                        {
                            this.directory = d;
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }


            return directory;
        }

        private void Save()
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(LogicLayer.Directory), new Type[] { typeof(Person) });
                    serializer.WriteObject(ms, directory);

                    string jsonString = Encoding.UTF8.GetString(ms.ToArray());
                    File.WriteAllText(file, jsonString);
                }

            }
            catch (Exception ex)
            {
                throw new StorageError();
            }
        }

        public IPerson Create()
        {
            return new Person("?", "");
        }

        public void Delete(IPerson p)
        {
            Save();
        }

        public void Update(IPerson p)
        {
            Save();
        }
        #endregion
    }
}
