// See https://aka.ms/new-console-template for more information
using Interface;
using System.ComponentModel;
using System.Data;
using System.Drawing;

Tempt.Tempt_();
return;

////

string currentUsername = "nobody";
string choosenUser = "nobody";
string choosenObject = "nothing";

Console.WriteLine("enter the \"help\" for more information \n");

Dictionary<string, Person> users = new Dictionary<string, Person>();

Stack<string> states = new Stack<string>();
Dictionary<string, int> priorities = new Dictionary<string, int>() {
    {"start", 1},
    {"logined", 3},
    {"choose user", 2},
    {"choose object", 2},
    {"password", 2}
};

states.Push("start");

Person nik = new Person("some");
users.Add("nik", nik);

Person sanya = new Person("any");
users.Add("sanya", sanya);

Person egor = new Person("how");
users.Add("egor", egor);

Person anya = new Person("shish");
users.Add("anya", anya);

Person maks = new Person();
users.Add("maks", maks);

void StateLogin(string action){
    if(users.ContainsKey(action)){
        currentUsername = action;
        Console.WriteLine("enter your password for login \n");
        states.Push("password");
    }
    else Console.WriteLine("Undefined command\n");
}

void StateEdit(){
    choosenUser = currentUsername;
    states.Push("choose object");
    Console.WriteLine("chose object");
    Console.WriteLine("personal diary");
    Console.WriteLine("bank account \n");
}

void StatePassword(string action){
    if(users[currentUsername].Password == action){
        states.Pop();
        states.Push("logined");
        Console.WriteLine("Access is allowed \n");
    } else{
        currentUsername = "nobody";
        states.Pop();
        Console.WriteLine("Access denied \n");
    }
}

void StateChooseUser(string action){
    if(users.ContainsKey(action)){
        choosenUser = action;
        states.Push("choose object");
        Console.WriteLine("personal diary");
        Console.WriteLine("bank account \n");
    }
    else {
        Console.WriteLine("try again \n");
    }
}

void StateChooseObject(string action){
    if(action == "personal diary" || action == "bank account"){
        choosenObject = action;
        ActionWithObject();
    }
    else{
        Console.WriteLine("try again \n");
    }
}

void ActionWithObject(){
    Console.WriteLine(users[choosenUser].Password);
}

while(true){
    Console.Write(states.Peek() + " || ");
    var action = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(action)) continue;
    else if (action == "exit") break;
    else if (action == "q") {
        if(states.Peek() == "start") break;
        else if(priorities[states.Peek()] == 3){
            while(states.Count() != 1){
                states.Pop();
            }
            currentUsername = "nobody";
        }
        else if(priorities[states.Peek()] == 2) states.Pop();
        continue;
    }

    if(priorities[states.Peek()] != 2){
        if(action == "help"){
            Console.WriteLine("enter your username for login");
            Console.WriteLine("enter \"exit\" for exit from current state");
            Console.WriteLine("enter \"show users\" for get list of users \n");
            continue;
        }
        else if(action == "show users"){
            foreach(string name in users.Keys){
                Console.WriteLine(name);
            }
            states.Push("choose user");
            Console.WriteLine("");
            continue;
        }
        else if(action == "edit" && states.Peek() == "logined"){
            StateEdit();
            continue;
        }

        if(states.Peek() == "start") StateLogin(action);
        continue;
    }

    if(priorities[states.Peek()] == 2){
        if(states.Peek() == "password") StatePassword(action);
        else if(states.Peek() == "choose user") StateChooseUser(action);
        else if(states.Peek() == "choose object") StateChooseObject(action);
        continue;
    }
   
}

