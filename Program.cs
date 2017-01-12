using System;
using System.Threading;

namespace ConsoleApplication
{
    public class Human
{
    public string name;

    //The { get; set; } format creates accessor methods for the field specified
    //This is done to allow flexibility
    public int health { get; set; }

    //These properties are all private
    protected int strength { get; set; }
    protected int intelligence { get; set; }
    protected int dexterity { get; set; }

    public Human(string person)
    {
        name = person;
        strength = 3;
        intelligence = 3;
        dexterity = 3;
        health = 100;
    }

    public Human(string person, int str, int intel, int dex, int hp)
    {
        name = person;
        strength = str;
        intelligence = intel;
        dexterity = dex;
        health = hp;
    }

    public void attack(object obj)
    {
        Human enemy = obj as Human;
        if(enemy == null)
        {
            Console.WriteLine("Failed Attack");
        }
        else
        {
            enemy.health -= strength * 5;
        }
    }

    public new string ToString(){
        return "Name: " + name +", strength: " + strength + ", intelligence: " + intelligence + ", dexterity: " + dexterity + ", health: "+ health;
    }
}

public class Wizard : Human{

    //Human constuctor is expecting a string so you don't need to define the parameter as a string here
    public Wizard(string name): base(name){ 
        health = 50;
        intelligence = 25;
    }

    public void heal(){
        health += (intelligence * 10);
    }

    public void fireball(object victim){
        Human enemy = victim as Human; //does this work or does it reset some of the default values??
        Random rnd = new Random();
        int damage = rnd.Next(20,51);
        enemy.health -= damage; //check if object has health??? something
    }
}

public class Ninja : Human{
    public Ninja(string name): base(name){ 
        dexterity = 175;
    }

    public void steal(object victim){
        Human enemy = victim as Human;
        enemy.health -= 10;
        health += 10;
    }

    public void get_away(){
        health -= 15;
    }
}

public class Samurai : Human{
    public Samurai(string name): base(name) {
        health = 200;
        instanceCount = instanceCount + 1;
    }

    public static int instanceCount;


    public void death_blow(object victim){
        Human enemy = victim as Human;
        if(enemy.health < 50){
            enemy.health = 0;
        }
    }

    public void meditate(){
        health = 200;
    }

    public void how_many(){
        Console.WriteLine("There are " + instanceCount + " Samurai!");

    }


}

    public class Program
    {
        public static void Main(string[] args)
        {
            Human qt = new Human("Amy");
            Wizard harry = new Wizard("Harry");
            Ninja liz = new Ninja("Liz");
            Samurai jack = new Samurai("Jack");
            Samurai bill = new Samurai("Bill");
            Samurai allie = new Samurai("Allie");
            Samurai seth = new Samurai("Seth");
            // System.Console.WriteLine(qt.ToString());
            // System.Console.WriteLine(harry.ToString());
            System.Console.WriteLine(jack.ToString());
            // System.Console.WriteLine(jack.ToString());

            harry.fireball(jack);
            System.Console.WriteLine(jack.ToString());
            jack.death_blow(jack);
            jack.meditate();
            jack.how_many();
            // System.Console.WriteLine(Samurai.instanceCount);
            // liz.get_away();
            // System.Console.WriteLine(harry.ToString());
            System.Console.WriteLine(jack.ToString());
            // System.Console.WriteLine(harry.ToString());
            
        }
    }
}
