
using FirstTask;

namespace SecondTask
{
    
    class ConcreteCreator1
    {
        public virtual ConcreteProduct1 FactoryMethod(string info){
            ConcreteProduct1 product = new(info);
            return product;
        }
        public string AnOperation(string info){
            ConcreteProduct1 product = FactoryMethod(info);
            product.Transform();
            product.Transform();
            return product.Info;
        }
    }

    class ConcreteCreator2 : ConcreteCreator1
    {
        public override ConcreteProduct1 FactoryMethod(string info) {
            ConcreteProduct2 product = new(info);
            return product;
        }
    }

    public class ConcreteProduct1
    {
        protected string ?_info;
        public string Info { get { return _info!; } }

        public ConcreteProduct1(string info){
            _info = info;
        }
        
        public virtual void Transform()
        {
            int i = 0;
            while(_info!.Length - 1 > i){
                if(_info[i] != '*'){
                    _info = _info.Insert(i + 1, "*"); i+=2;
                }
                else i++;
            }
        }

    }

    public class ConcreteProduct2 : ConcreteProduct1
    {
        public ConcreteProduct2(string info) : base(info)
        {
            _info = info;
        }

        public override void Transform()
        {
           int i = 0;
            while(_info!.Length - 1 > i){
                if(_info[i] != '*'){
                    _info = _info.Insert(i + 1, "*"); i+=2;
                }
                else i++;
            }
            _info = "==" + _info + "==";
        }
    }
}