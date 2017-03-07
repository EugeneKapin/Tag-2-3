using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tag
{
    class Game
    {
        public int side, a = 0, b = 0, Numberone = 0, Numbertwo = 0; 
        public int[,] Numbers;        
        protected Dictionary <int, Tuple<int, int>> dictionary=new Dictionary<int,Tuple<int, int>>();

        public Game(params int[] meaning)
        {
            int count = 0;
            bool existVoid = false;

            if (!CorrectArray(meaning)) throw new ArgumentException("The values ​​in the array is incorrect");
            if (!IntegerSize(meaning.Length)) throw new ArgumentException("Field size data arguments can not exist");

            side = (int)Math.Sqrt(meaning.Length);
            Numbers = new int[side, side];

            for (int i = 0; i < side; i++)
            {
                for (int j = 0; j < side; j++)
                {
                    if (meaning[count] == 0)
                    {
                        a = i;
                        b = j;
                        Numbers[i, j] = meaning[count];
                        var numberof = Tuple.Create(i, j);
                        dictionary.Add(Numbers[i, j], numberof);
                        count++;
                        existVoid = true;

                    }
                    else
                    {
                        Numbers[i, j] = meaning[count];
                        var numberof = Tuple.Create(i, j);
                        dictionary.Add(Numbers[i, j], numberof);
                        count++;
                    }
                }
            }
            if (!existVoid) throw new ArgumentException("These data are not zero");           
        }


        public int this[int x, int y]
        {
            get
            {
                return Numbers[x, y];
            }
            set
            {
                Numbers[x, y] = value;
            }
        }

        public Tuple<int, int> GetLocation(int value)
        {            
            if ((value < Math.Pow(side, 2))&&(value>=0))
            {                
                return dictionary[value];
            }
            else throw new ArgumentException("This number " + value + " could not find");   
        }

        private bool IntegerSize(int size)
        {
            return ((Math.Sqrt(size) % 1) == 0);
        }


        private bool CorrectArray(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (((array[i] == array[j]) || (array[j] > array.Length - 1)) || (array[i] < 0))
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public virtual void Shift(int value)
        {
            bool existValue = false;
            for (int i = 0; i < side; i++)
            {
                for (int j = 0; j < side; j++)
                {
                    if (Numbers[i, j] == value)
                    {
                        existValue = true;
                        Numberone = i;
                        Numbertwo = j;                       
                    }
                }
            }

            if (existValue)
            {
                if (Math.Abs(Numberone - a) + Math.Abs(Numbertwo - b) == 1)
                {
                    Numbers[a, b] = Numbers[Numberone, Numbertwo];
                    dictionary.Remove(0);
                    dictionary.Remove(value);
                    var coorVoid = Tuple.Create(a, b);
                    var coorValue = Tuple.Create(Numberone, Numbertwo);
                    dictionary.Add(value, coorVoid);
                    dictionary.Add(0, coorValue);
                    a = Numberone;
                    b = Numbertwo;
                    Numbers[a, b] = 0;
                }
                //if (dictionary[value] - dictionary[0] == 1)
                //{
                //    Dot positionZero = dictionary[0];
                //    this[dictionary[0].X, dictionary[0].Y] = new int(value);
                //    this[dictionary[value].X, dictionary[value].Y] = new Value(0);
                //    dictionary[0] = dictionary[value];
                //    dictionary[value] = positionZero;
                //}
                else
                {
                    throw new ArgumentException("This number can not be interchanged with zero");
                }
            }
            else
            {            
                throw new ArgumentException("This number " + value + " could not find");     
            }
            
        }

        public static Game FromCSV(string file)
        {
            string[] data = File.ReadAllLines(file);
            List<int> convertedData = new List<int>();
            for (int i = 0; i < data.Count(); i++)
            {
                for (int j = 0; j < data[i].Split(';').Count(); j++)
                {
                    convertedData.Add(Convert.ToInt32(data[i].Split(';')[j]));
                }
            }
            Game game = new Game(convertedData.ToArray<int>());
            return game;
        }

      
    }
}
