using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player()
            {
                Name = "Dall",
                Level = 20,
                Score = 1986,
                Coin = 250000
            };
            string filePath = "Data.save";
            dataSerializer ds = new dataSerializer();

            ds.BinarySerialize(player, filePath);

            player = ds.BinaryDeserialize(filePath) as Player;

            Console.WriteLine("First Name : " + player.Name);
            Console.WriteLine("Level : " + player.Level);
            Console.WriteLine("Score : " + player.Score);
            Console.WriteLine("Coin : " + player.Coin);

            Console.ReadLine();
        }
    }

    [Serializable]
    public class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Score { get; set; }
        public int Coin { get; set; }
    }

    class dataSerializer
    {
        public void BinarySerialize(object data, string filePath)
        {
            FileStream fileS;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath)) File.Delete(filePath);
            fileS = File.Create(filePath);
            bf.Serialize(fileS, data);
            fileS.Close();
        }

        public object BinaryDeserialize(string filePath)
        {
            object obj = null;

            FileStream fileS;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                fileS = File.OpenRead(filePath);
                obj = bf.Deserialize(fileS);
                fileS.Close();
            }
            return (obj);
        }
    }
}