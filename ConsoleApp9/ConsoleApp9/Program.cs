using System;
using System.Collections.Generic;
using System.Linq;
//user clasata so id name age
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public User(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }
}
//static classot za user sto se vika user databaseot
public static class UserDatabase
{
    public static List<User> Users = new List<User>
    {
        //tuka dole se usersot
        new User(1, "Alice", 25),
        new User(2, "Bob", 30),
        new User(3, "Charlie", 25)
    };
    //search method by id
    public static List<User> SearchById(int id)
    {
        return Users.Where(u => u.Id == id).ToList();
    }
    //search method by name
    public static List<User> SearchByName(string name)
    {
        return Users.Where(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    //search method by age
    public static List<User> SearchByAge(int age)
    {
        return Users.Where(u => u.Age == age).ToList();
    }
}
