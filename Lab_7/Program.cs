using System;
using System.Xml.Linq;
using System.IO;
using System.Linq;

namespace Lab_7
{

    public partial class Apartment
    {
        private int id;
        private String name;
        private String quantity;
        private long price;
        


        public int GetId()
        {
            return id;
        }
        
        public string GetName()
        {
            return name;
        }
        public string GetQuantity()
        {
            return quantity;
        }
        public long GetPrice()
        {
            return price;
        }
    }

    class Program
    {

        public static void GetInfo()
        {
            Console.Clear();
            XDocument xdoc = XDocument.Load("apartment.xml");
            foreach (XElement apartmentElement in xdoc.Element("apartment").Elements("apartment"))
            {
                XAttribute idElement = apartmentElement.Attribute("id");
                XElement nameAttribute = apartmentElement.Element("name");
                XElement quantityElement = apartmentElement.Element("quantity");
                XElement priceElement = apartmentElement.Element("price");

                if (idElement != null && nameAttribute != null && quantityElement != null && priceElement != null)
                {
                    Console.WriteLine($"Id: {idElement.Value}");
                    Console.WriteLine($"Квартира: {nameAttribute.Value}");
                    Console.WriteLine($"Кол-во комнат: {quantityElement.Value}");
                    Console.WriteLine($"Цена: {priceElement.Value}");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        public static void AddApartment()
        {
            Console.Write("Название id: ");
            int id = System.Int32.Parse(Console.ReadLine());
            Console.Write("Квартира: ");
            string name = Console.ReadLine();
            Console.Write("Кол-во комнат: ");
            string quantity = Console.ReadLine();
            Console.Write("Стоимость квартиры: ");
            long price = System.Int64.Parse(Console.ReadLine());
            Apartment apartment = new Apartment(id, name, quantity, price);

            XDocument xdoc = XDocument.Load("apartment.xml");
            XElement root = xdoc.Element("apartment");
            root.Add(new XElement("apartment",
                new XAttribute("id", apartment.GetId()),
                new XElement("name", apartment.GetName()),
                new XElement("quantity", apartment.GetQuantity()),
                new XElement("price", apartment.GetPrice()))
                );
            xdoc.Save("apartment.xml");
        }

        public static void DeleteApartment()
        {
            Console.Clear();
            Console.WriteLine("Айди квартиры:");
            XDocument xdoc = XDocument.Load("apartment.xml");
            XElement root = xdoc.Element("apartment");
            int id = System.Int32.Parse(Console.ReadLine());
            foreach (XElement xe in root.Elements("apartment").ToList())
            {


                if (xe.Attribute("id").Value == id.ToString())

                {
                    xe.Remove();
                }
            }
            Console.Write("Квартира удалена из базы");
            xdoc.Save("apartment.xml");
        }


        public static void UpdateApartment()
        {
            Console.Clear();
            Console.WriteLine("Айди квартиры:");

            XDocument xdoc = XDocument.Load("apartment.xml");
            XElement root = xdoc.Element("apartment");
            int id = System.Int32.Parse(Console.ReadLine());
            Console.WriteLine("Название квартиры:");
            String name = Console.ReadLine();
            Console.WriteLine("Цена:");
            long price = System.Int64.Parse(Console.ReadLine());
            Console.WriteLine("Кол-во комнат:");
            String quantity = Console.ReadLine();

            foreach (XElement xe in root.Elements("apartment").ToList())
            {
                // изменяем название и цену
                if (xe.Attribute("id").Value == id.ToString())
                {
                    xe.Element("name").Value = name;
                    xe.Element("price").Value = price.ToString();
                    xe.Element("quantity").Value = quantity;
                }

            }
            xdoc.Save("apartment.xml");
        }

        static void Main(string[] args)
        {

            int choise = 0;
            while (choise != 5)
            {

                Console.Clear();
                Console.WriteLine("1)Просмотреть файл");
                Console.WriteLine("2)Добавить");
                Console.WriteLine("3)Удаление");
                Console.WriteLine("4)Изменение");
                Console.WriteLine("5)Выход");
                choise = System.Int32.Parse(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        {
                            GetInfo();
                            break;
                        }
                    case 2:
                        {
                           AddApartment();
                            break;
                        }
                    case 3:
                        {
                            DeleteApartment();
                            break;
                        }
                    case 4:
                        {
                            UpdateApartment();
                            break;
                        }
                }

            }            
        }
    }
}
