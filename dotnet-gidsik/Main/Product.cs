using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{

    public abstract class Creator
    {
        public Product FactoryMethod() => new ConcreteProduct1();
    }

    class ConcreteCreator1 : Creator
    {
        Product product = new ConcreteProduct1();
        //Product product { get; set; };
        public override Product FactoryMethod() => new ConcreteProduct1(); 

    }

    class ConcreteCreator2 : Creator
    {
        Product product = new ConcreteProduct2();
        //Product product { get; set; };
        public override Product FactoryMethod() { return new ConcreteProduct2(); }
    }



    public abstract class Product
    {
        protected string _info;
        public string Info { get { return Info; } set { } }
        public abstract void Transform();
    }

    class ConcreteProduct1 : Product
    {
        public override void Transform()
        {
            throw new NotImplementedException();
        }
    }

    class ConcreteProduct2 : Product
    {
        public override void Transform()
        {
            throw new NotImplementedException();
        }
    }


}
