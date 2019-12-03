using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class DllTypeHolder : ATypeRepresentation
    {
        
        public DllTypeHolder(Type type)
        {
            if (type.IsClass)
            {
                
            }
            else
            {
                Console.WriteLine("test");
            }

            

            
        }

        public override string Name
        {
            get { return _string; }
            set { _string = value; }
        }

        public override List<ATypeRepresentation> ReferencedTypes { get; set; }

        public override bool GenerateReferencedTypes()
        {
            throw new NotImplementedException();
        }

        private string _string;
    }
}
