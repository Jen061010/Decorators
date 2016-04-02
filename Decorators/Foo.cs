using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//añadir en referencias: System.ComponentModel.DataAnnotations(Botón derecho en proyecto=>añadir referencia)
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorators
{
    public class Foo
    {   
  //      using(var foo=new Foo()){
  //          Console.WriteLine("Hello");
     //   }
        public int Id { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage="La longitud del nombre no es correcta")]
       
        public string Name { get; set; }

    
    }
}
