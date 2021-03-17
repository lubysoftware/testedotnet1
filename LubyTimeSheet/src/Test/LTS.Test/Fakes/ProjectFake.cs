using LTS.Domain.Entities;
using System;

namespace LTS.Test.Fakes
{
    public  static class ProjectFake
    {
        public const string Name = "Argos";

        public static Project Default(Guid? id = null)
        {
            var book = new Project(Name);
            book.SetId(id.GetValueOrDefault());
            return book;

        }
    }
}
