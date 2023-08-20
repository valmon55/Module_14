namespace LINQ.Address_Book
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            int pageNum;
            while (true)
            {
                var key = Console.ReadKey().KeyChar;
                var parsed = Int32.TryParse(key.ToString(), out pageNum);
                Console.Clear();

                IEnumerable<Contact> page = null;

                if (!parsed || pageNum < 1 || pageNum > 3)
                    Console.WriteLine("Page not found!");
                else
                    page = phoneBook.Skip((pageNum - 1) * 2).Take(2);


                if (page != null)
                    foreach (Contact contact in page)
                        Console.WriteLine(contact.Name + " " +
                                          contact.LastName + " - " +
                                          contact.PhoneNumber.ToString() + " " +
                                          contact.Email
                                          );

            }

        }
    }
}