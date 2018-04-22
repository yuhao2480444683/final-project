using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UserLibrary
{
    public class User
    {
        public int Id { get; set; }


        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Note> Notes { get; set; }
    }
    public class Note
    {

        public int  Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Tag> Tags { get; set; }


        public int UserId { get; set; }
        public User User  { get; set; }

    }

    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }


        public int NoteId { get; set; }
        public Note Note { get; set; }

    }

    public class MyDatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=file.db");
        }


    }
}
