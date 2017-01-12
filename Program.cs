using System;

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
        intelligence =25;
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
    public Ninja(): base("n"){ 
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
    public Samurai(): base("n") {
        health = 200;
    }

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
        //displays how many Samurai there are
    }

}

    public class Program
    {
        public static void Main(string[] args)
        {
            Human qt = new Human("Amy");
            Wizard liz = new Wizard("Liz");
            System.Console.WriteLine(qt);
            System.Console.WriteLine(liz);
        }
    }
}
