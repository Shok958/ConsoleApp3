using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var ticket = new Ticket { Total = 1000 };
            var repositoryTicket = new RepositoryTicket();
            repositoryTicket.Add(ticket);
        }
    }

   public  abstract class EntityBase {

        public Guid Id { get; set; }
        public static Guid CreateIdentifier() {
            return new Guid();
        }

    }

    public class Ticket : EntityBase
    {
        public Decimal Total { get; set; }
    }

    public class Person : EntityBase
    {
        public string Name { get; set; }
    }

    public class RepositoryTicket:RepositoryGeneric<Ticket> {
        public override void Add(Ticket entity)
        {
            base.Add(entity);
        }
    }

    public class RepositoryPerson:RepositoryGeneric<Person>
    {
       
    }

    public class RepositoryGeneric<T> where T : EntityBase
    {
        public virtual void Add(T entity) {

            entity.Id = EntityBase.CreateIdentifier();
        }
    }
}
