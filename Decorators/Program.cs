using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorators
{
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo() { Name = "01234567891" };
            var propierty = foo.GetType().GetProperty("Name");

            var attributes=propierty.GetCustomAttributes(true);

           // foreach (var atributos in attributes) {
                
                /* así no se puede hacer el cast.....
                 * 
                 * var attr=(MaxLengthAttribute)atributos
                 * 
                 * porque si sale required el código no compila.*/


                /*Evitar esto: por alto rendimiento:
                 * 
                 * if(attribute is MaxLengthAttribute){
                 *  var attr=(MaxLengthAttribute)attribute;
                 * }
                 * 
                 * 
                /*Éste es correcto en cuanto a rendimiento y robustez*/
             /* var attr = atributos as MaxLengthAttribute; //si atributo es Maxlength lo pone a la izquierda, si no lo es, es null.
            //Es hacer un cast sin romper código.
               
            if (null != attr) { 
                 var value = propierty.GetValue(foo)
              * if ((value != null) && value.ToString().Length > attr.Length) {
                    throw new Exception(attr.ErrorMessage);
                 }
             }*/


                /*Forma aun más eficiente y corta y para cualquier decorador, para cualquier validation*/

                var value=propierty.GetValue(foo);
                foreach(var attribute in attributes){
                    var attr=attribute as ValidationAttribute;
                    if(null!=attr){
                        if(!attr.IsValid(value)){
                            throw new Exception(attr.ErrorMessage);
                        }
                    }
                }
            }
        }
    
}
