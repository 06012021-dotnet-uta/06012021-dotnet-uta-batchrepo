namespace LinkedListDemo
{
    public class Person
    {
        // public Person Next { get; set; }    // points to the next object in the list
        // public Person Previous { get; set; }// points to the object before this.
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}