using Microsoft.VisualBasic;

namespace ThirdTask{
    abstract class AbstractFactory {
        public abstract AbstractProductA CreateProductA(uint param);
        public abstract AbstractProductB CreateProductB(uint param);
    }
    class ConcreteFactory1 : AbstractFactory {
        public override ProductA1 CreateProductA(uint param){ return new ProductA1(param);}
        public override ProductB1 CreateProductB(uint param){ return new ProductB1(param);}
    }
    class ConcreteFactory2 : AbstractFactory {
        public override ProductA2 CreateProductA(uint param){ return new ProductA2(param);}
        public override ProductB2 CreateProductB(uint param){ return new ProductB2(param);}
    }

    class AbstractProduct {
        protected string ?_info;
        public string Info {get {return _info!;}}
    }
    

    class AbstractProductA : AbstractProduct {
        public virtual void MethodA() {}
    }
    class ProductA1 : AbstractProductA {
        public ProductA1(uint param){
            _info = param.ToString();
        }

        public override void MethodA(){
            uint number = uint.Parse(_info!);
            number *= 2;
            _info = number.ToString();
        }
        
    }
    class ProductA2 : AbstractProductA {
        public ProductA2(uint param){
            _info = param.ToString();
        }
        public override void MethodA(){
            _info += _info;
        }
    }

    class AbstractProductB : AbstractProduct {
        public virtual void MethodB (AbstractProductA abstractProductA) {}
    }
    class ProductB1 : AbstractProductB {
        public ProductB1(uint param){
            _info = param.ToString();
        }
        public override void MethodB(AbstractProductA abstractProductA){
            uint number1 = uint.Parse(_info!), number2 = uint.Parse(abstractProductA.Info);
            _info = (number1 + number2).ToString();
        }
    }
    class ProductB2 : AbstractProductB {
        public ProductB2(uint param){
            _info = param.ToString();
        }
        public override void MethodB(AbstractProductA abstractProductA){
            _info += abstractProductA.Info;
        }
    }
}