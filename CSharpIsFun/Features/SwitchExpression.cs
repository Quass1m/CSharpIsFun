// ToDo: C# 8.0
/*using System;
using System.Collections.Generic;

namespace CSharpIsFun.Features
{
    public class SwitchExpression
    {
        public class Person
        {
            public string FirstName { get; }
            public string LastName { get; }

            public Person(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }
        }

        public class Professor : Person
        {
            public string Subject { get; }

            public Professor(string firstName, string lastName, string subject) 
                : base(firstName, lastName)
            {
                Subject = subject;
            }
        }

        public class Student : Person
        {
            public string Major { get; }

            public Student(string firstName, string lastName, string major) 
                : base(firstName, lastName)
            {
                Major = major;
            }
        }

        private readonly List<Person> people = new List<Person>();

        public SwitchExpression()
        {
            people.Add(new Person("John", "Connor"));
            people.Add(new Professor("Thomas", "Anderson", "C++"));
            people.Add(new Student("Agent", "Smith", "Computer Science"));
        }

        public void Print()
        {
            foreach (var p in people)
                Console.WriteLine(Match(p));
        }

        // ToDo: extend this example
        public static string Match(Person person)
        {       
            return person switch
            {
                Professor p => "Professor",
                Student s => "Student",
                Person pp => "Person",
                _ => "None"
            };
        }
    }
}*/