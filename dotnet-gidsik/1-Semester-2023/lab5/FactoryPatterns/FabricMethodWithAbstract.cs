using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{

    public abstract class Creator
    {
        public abstract Product FactoryMethod(string info);

        public string AnOperation(string info){
            Product product = FactoryMethod(info);
            product.Transform();
            product.Transform();
            return product.Info;
        }
    }

    class ConcreteCreator1 : Creator
    {
        public override Product FactoryMethod(string info) => new ConcreteProduct1(info); 

    }

    class ConcreteCreator2 : Creator
    {
        public override Product FactoryMethod(string info) { return new ConcreteProduct2(info);}
    }



    public abstract class Product
    {
        protected string ?_info;
        public string Info { get { return _info!; } }
        public abstract void Transform();
    }

    class ConcreteProduct1 : Product
    {
        public ConcreteProduct1(string info){
            _info = info.ToLower();
        }

        public override void Transform()
        {
            int i = 0;
            while(_info!.Length - 1 > i){
                if(_info[i] != ' '){
                    _info = _info.Insert(i + 1, " "); i+=2;
                }
                else i++;
            }
        }
    }

    class ConcreteProduct2 : Product
    {
        public ConcreteProduct2(string info){
            _info = info.ToUpper();
        }

        public override void Transform()
        {
            int i = 0;
            while(_info!.Length - 1 > i){
                if(_info[i] != '*'){
                    _info = _info.Insert(i + 1, "**"); i+=3;
                }
                else i++;
            }
        }
    }


}
