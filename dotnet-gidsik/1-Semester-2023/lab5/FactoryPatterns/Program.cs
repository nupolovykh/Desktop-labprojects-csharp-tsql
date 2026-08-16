//using FirstTask; ///////////////////////////////

// static void ExecuteExample(){
//     List<string> strings = new List<string>{
//         "nika", "nika", "nika", "nika", "nika"
//     };

//     Creator first = new ConcreteCreator1();
//     foreach (string str in strings)
//     {
//         Console.WriteLine(first.AnOperation(str));
//     }

//     Creator second = new ConcreteCreator2();
//     foreach (string str in strings)
//     {
//         Console.WriteLine(second.AnOperation(str));
//     }
// }

// using SecondTask; ///////////////////////////////

// static void ExecuteExample(){
//     List<string> strings = new List<string>{
//         "nika", "nika", "nika", "nika", "nika"
//     };

//     ConcreteCreator1 first = new ConcreteCreator1();
//     foreach (string str in strings)
//     {
//         Console.WriteLine(first.AnOperation(str));
//     }

//     ConcreteCreator1 second = new ConcreteCreator2();
//     foreach (string str in strings)
//     {
//         Console.WriteLine(second.AnOperation(str));
//     }
// }

using ThirdTask; ///////////////////////////////

static void ExecuteExample(FactoryType factoryType){
    uint infoA = 5, infoB = 5;
    string str = "A";
    AbstractFactory factory;
    AbstractProductA productA;
    AbstractProductB productB;

    factory = ((int)factoryType == 1) ? new ConcreteFactory1() : new ConcreteFactory2();
    productA = factory.CreateProductA(infoA);
    productB = factory.CreateProductB(infoB);
    foreach (var letter in str){
        if(letter == 'A') productA.MethodA();
        else productB.MethodB(productA);
    }
    Console.WriteLine(productA.Info);
    Console.WriteLine(productB.Info);

    // Console.WriteLine((int)FactoryType.firstCase);
    // Console.WriteLine((int)FactoryType.secondCase);
}

ExecuteExample(FactoryType.secondCase);

enum FactoryType{
    firstCase = 1,
    secondCase
}